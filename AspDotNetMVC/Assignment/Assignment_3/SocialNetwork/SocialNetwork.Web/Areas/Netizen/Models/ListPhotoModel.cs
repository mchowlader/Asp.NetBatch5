using Autofac;
using SocialNetwork.Account.Services;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Netizen.Models
{
    public class ListPhotoModel
    {
        private readonly IPhotoService _photoService;

        public ListPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public ListPhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        internal object GetPhotos(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _photoService.GetPhotos(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "MemberId", "PhotoFileName" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,

                data = (from record in data.records
                       select new string[]
                       {
                           record.MemberId.ToString(),
                           record.PhotoFileName.ToString(),
                           record.Id.ToString()
                       }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _photoService.DeletePhoto(id);
        }
    }
}
