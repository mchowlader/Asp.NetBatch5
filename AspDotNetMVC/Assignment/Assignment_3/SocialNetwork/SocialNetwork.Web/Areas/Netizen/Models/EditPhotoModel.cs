using Autofac;
using SocialNetwork.Account.BusinessObjects;
using SocialNetwork.Account.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Netizen.Models
{
    public class EditPhotoModel
    {
        public int? Id { get; set; }
        [Required]
        public string PhotoFileName { get; set; }
        [Required, Range(1, 100000)]
        public int? MemberId { get; set; }

        private readonly IPhotoService _photoService;

        public EditPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public EditPhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        internal void LoadModelData(int id)
        {
            var photo = _photoService.GetPhotos(id);

            Id = photo?.Id;
            PhotoFileName = photo?.PhotoFileName;
            MemberId = photo?.MemberId;
        }

        internal void Update()
        {
            var photo = new Photo()
            {
                Id = Id.HasValue? Id.Value : 0,
                MemberId = MemberId.HasValue? MemberId.Value : 0,
                PhotoFileName = PhotoFileName
            };

            _photoService.UpdatePhoto(photo);
        }
    }
}
