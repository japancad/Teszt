using FamilyPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Repository
{
    public class PhotoTestDataRepository : IPhotoRepository
     {
        //private List<PhotoModel> data = new List<PhotoModel> { new PhotoModel { Id = 1, Title = " egy kép" } };
        private List<PhotoModel> data = new List<PhotoModel>();
        int id = 0;

        public IEnumerable<PhotoModel> GetAllPhotos()
        {
            return data;
        }

        public PhotoModel GetPicture(int photoId)
        {
            return data.SingleOrDefault(x=>x.Id == photoId);
            
        }

        public void AddPhoto(PhotoModel model)
        {
            model.Id = id++;
            data.Add(model);
        }

        public void UpdatePhoto(PhotoModel model)
        {
            var oldModel = data.SingleOrDefault(x => x.Id == model.Id);
            if (oldModel != null)
            {
                //TODO: Megcsinálni normálisan
                data.Remove(oldModel);
                data.Add(model);
            }

            
        }

        public void DeletePhoto(int id)
        {
            var oldModel = data.SingleOrDefault(x => x.Id == id);
            if (oldModel != null)
            {
                //TODO: Megcsinálni normálisan
                data.Remove(oldModel);
            }

               
            
        }
    }
}
