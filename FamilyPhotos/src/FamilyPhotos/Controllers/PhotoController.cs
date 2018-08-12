using AutoMapper;
using FamilyPhotos.Models;
using FamilyPhotos.Repository;
using FamilyPhotos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoRepository repository;
        private readonly IMapper mapper;

        public PhotoController(IPhotoRepository repository, IMapper mapper )
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;

            if(mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }
            this.mapper = mapper;

        }

        public IActionResult Index()
        {
            var pics = repository.GetAllPhotos(); //TODO: itt még a model megy ki a view-ra

            return View(pics);
        }

        public IActionResult Details(int id)
        {
            var model = repository.GetPicture(id);

            var viewModel = mapper.Map<PhotoViewModel>(model);

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = repository.GetPicture(id);

            var viewModel = mapper.Map<PhotoViewModel>(model);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(PhotoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var model = mapper.Map<PhotoModel>(viewModel);
            
            repository.UpdatePhoto(model);
            
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = repository.GetPicture(id);

            var viewModel = mapper.Map<PhotoViewModel>(model);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(PhotoViewModel viewModel)
        {
           

            repository.DeletePhoto(viewModel.Id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new PhotoViewModel());
        }

        [HttpPost]
        public IActionResult Create(PhotoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

           var model = mapper.Map<PhotoModel>(viewModel);

            // Több profile betöltése
            //var autoMApperCfg = new AutoMapper.MapperConfiguration(
            //    cfg =>
            //    {
            //        cfg.AddProfile(new PhotoProfile());
            //        cfg.AddProfile(new PhotoProfile());
            //        cfg.AddProfile(new PhotoProfile());
            //        cfg.AddProfile(new PhotoProfile());
            //    });

            
            repository.AddPhoto(model);
            //return View(model);
            return RedirectToAction("Index");

        }

        public FileContentResult GetImage(int photoId)
        {
            var pic = repository.GetPicture(photoId);
            //TODO: a pic nem lehet null
            if (pic == null || pic.Picture == null)
            {
                return null;
            }


            return File(pic.Picture, "image/jpeg"); //TODO: Lecserélni
        }


        public IActionResult EzEgyHibasKod()
        {
            try
            {
                throw new Exception("Hiba");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }
    }
}
