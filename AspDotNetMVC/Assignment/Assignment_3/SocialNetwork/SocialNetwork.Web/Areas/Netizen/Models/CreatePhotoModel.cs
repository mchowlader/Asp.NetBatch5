using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Account.BusinessObjects;
using SocialNetwork.Account.Services;

namespace SocialNetwork.Web.Areas.Netizen.Models
{
    public class CreatePhotoModel
    {
        [Required]
        public string PhotoFileName { get; set; }
        [Required, Range(1,100000)]
        public int MemberId { get; set; }

        private readonly IPhotoService  _photoService;

        public CreatePhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public CreatePhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        internal void CreatePhoto()
        {
            var photo = new Photo()
            {
                MemberId = MemberId,
                PhotoFileName = PhotoFileName
            };

            _photoService.CreatePhoto(photo);
        }
    }
}
