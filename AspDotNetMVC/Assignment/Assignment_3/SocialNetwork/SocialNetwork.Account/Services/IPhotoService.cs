using SocialNetwork.Account.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.Services
{
    public interface IPhotoService
    {
        void CreatePhoto(Photo photo);
        (IList<Photo> records, int total, int totalDisplay) GetPhotos(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Photo GetPhotos(int id);
        void UpdatePhoto(Photo photo);
        void DeletePhoto(int id);
    }
}
