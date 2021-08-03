using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Account.Services;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.Areas.Netizen.Models
{
    public class ListMemberModel
    {
        private readonly IMemberService _memberService;

        public ListMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public ListMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        internal object GetMembers(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _memberService.GetMembers(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "Name", "Address", "DateOfBirth" }));

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
                       }
                    ).ToArray()
            };

        }

        internal void Delete(int id)
        {
            _memberService.DeleteMember(id);
        }
    }
}
