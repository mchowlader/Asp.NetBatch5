using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeChallenge.User.Services;
using TimeChallenge.Web.Models;
using BO = TimeChallenge.User.BusinessObjects;

namespace TimeChallenge.Web.Areas.Admin.Models
{
    public class DataUserModel
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DataUserModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _userService = Startup.AutofacContainer.Resolve<IUserService>();
        }

        public DataUserModel(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        internal object GetUsersData(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _userService.GetUsers(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] {"Name","Address","DateOfBirth" }));

            return new 
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                       select new string[]
                       {
                           record.Name,
                           record.Address,
                           record.DateOfBirth.ToString(),
                           record.Id.ToString()
                       }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
