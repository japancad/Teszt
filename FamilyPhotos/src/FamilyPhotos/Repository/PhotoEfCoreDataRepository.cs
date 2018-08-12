using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyPhotos.Data;
using FamilyPhotos.Models;

namespace FamilyPhotos.Repository
{
    public class PhotoEfCoreDataRepository : IPhotoRepository
    {
        private FamilyPhotosContext context;

        public PhotoEfCoreDataRepository(FamilyPhotosContext context)
        {
            this.context = context;
        }
        public void AddPhoto(PhotoModel model)
        {
            context.Photos.Add(model);
            context.SaveChanges();
        }

        public void DeletePhoto(int id)
        {
            var toRemovePhoto = Find(id);
            if (toRemovePhoto == null) { return; }
            context.Photos.Remove(toRemovePhoto);
            context.SaveChanges();
        }

        public IEnumerable<PhotoModel> GetAllPhotos()
        {
            return context.Photos.ToList();
        }

        public PhotoModel GetPicture(int photoId)
        {
            //TODO itt még null-al is visszatérhet
            return Find(photoId);
        }

        private PhotoModel Find(int photoId)
        {
            return context.Photos
                          .SingleOrDefault(x => x.Id == photoId);
        }

        public void UpdatePhoto(PhotoModel model)
        {
            var toUpdatePhoto = Find(model.Id);
            if (toUpdatePhoto == null) { return; }
            //TODO erre nézni nem beégetett kodot
            toUpdatePhoto.Name = model.Name;
            toUpdatePhoto.Description = model.Description;
            toUpdatePhoto.Company = model.Company;
            toUpdatePhoto.FaceBookProfil = model.FaceBookProfil;
            toUpdatePhoto.Picture = model.Picture;
            toUpdatePhoto.ContentType = model.ContentType;
            context.Photos.Update(toUpdatePhoto);
            context.SaveChanges();


            //bemutatjuk az ef - nek a modelt
            //context.Entry(model);

            //context.Photos.Update(model);
            //context.SaveChanges();
        }
    }
}
