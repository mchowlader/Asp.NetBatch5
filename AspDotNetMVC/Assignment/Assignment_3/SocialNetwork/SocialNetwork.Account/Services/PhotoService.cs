using SocialNetwork.Account.BusinessObjects;
using SocialNetwork.Account.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Account.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IAccountUnitOfWork  _accountUnitOfWork;

        public PhotoService(IAccountUnitOfWork accountUnitOfWork)
        {
            _accountUnitOfWork = accountUnitOfWork;
        }
        public void CreatePhoto(Photo photo)
        {
            if (IsValidMember(photo.MemberId))
            {
                _accountUnitOfWork.Photos.Add(
                new Entities.Photo()
                {
                    MemberId = photo.MemberId,
                    PhotoFileName = photo.PhotoFileName
                });
                _accountUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Invalid member");
          
        }

        public void DeletePhoto(int id)
        {
            _accountUnitOfWork.Photos.Remove(id);
            _accountUnitOfWork.Save();
        }

        public (IList<Photo> records, int total, int totalDisplay) GetPhotos(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var photoData = _accountUnitOfWork.Photos.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null: x => x.MemberId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from photo in photoData.data
                         select new Photo()
                         {
                             MemberId = photo.MemberId,
                             PhotoFileName = photo.PhotoFileName,
                             Id = photo.Id
                         }).ToList();

            return (result, photoData.total, photoData.totalDisplay);
            
        }

        public Photo GetPhotos(int id)
        {
            var photoEntity = _accountUnitOfWork.Photos.GetById(id);
            if (photoEntity == null) return null;

            return new Photo()
            {
                Id = photoEntity.Id,
                PhotoFileName = photoEntity.PhotoFileName,
                MemberId = photoEntity.MemberId
            };

        }

        public void UpdatePhoto(Photo photo)
        {
            if (photo == null)
                throw new InvalidOperationException("missing photo");
            if(IsValidEdit(photo.MemberId, photo.Id))
                throw new InvalidOperationException("Couldn't change user id");

            var photoEntity = _accountUnitOfWork.Photos.GetById(photo.Id);

            if(photoEntity != null)
            {
                photoEntity.Id = photo.Id;
                photoEntity.MemberId = photo.MemberId;
                photoEntity.PhotoFileName = photo.PhotoFileName;

                _accountUnitOfWork.Save();
            }

            else
                throw new InvalidOperationException("missing photo");
        }

        private bool IsValidMember(int memberId) =>
          _accountUnitOfWork.Members.GetCount(x => x.Id == memberId) > 0;
        private bool IsValidEdit(int memberId, int id) =>
          _accountUnitOfWork.Photos.GetCount(x => x.MemberId != memberId && x.Id == id) > 0;

    }
}
