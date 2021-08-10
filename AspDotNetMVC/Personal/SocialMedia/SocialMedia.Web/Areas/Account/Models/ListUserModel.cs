using Autofac;
using SocialMedia.Account.Services;
using SocialMedia.Web.Models;
using System.Linq;

namespace SocialMedia.Web.Areas.Account.Models
{
    public class ListUserModel
    {
        private readonly IUserService _userService;
        public ListUserModel()
        {
            _userService = Startup.AutofacContainer.Resolve<IUserService>();
        }
        public ListUserModel(IUserService userService)
        {
            _userService = userService;
        }

        internal object GetUsers(DataTablesAjaxRequestModel dataTableModel)
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
                           record.DateOfBirth.ToString(),
                           record.Address,
                           record.Id.ToString()
                       }).ToArray()
            };
        }

        internal void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
