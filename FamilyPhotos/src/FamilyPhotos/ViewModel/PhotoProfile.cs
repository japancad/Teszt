using AutoMapper;
using FamilyPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.ViewModel
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {

            //viewmodelbol modelt
            //azonos nevü propertik konfigurálása
            CreateMap<PhotoViewModel, PhotoModel > ()  //azonos nevü propertik konfigurálása
                // ContentType konfigurálás
                .ForMember(dest => dest.ContentType,
                        options => options.MapFrom(
                            src=>src.PictureFromBrowser == null 
                            ? null 
                            : src.PictureFromBrowser.ContentType))
                //picture konfigurálás
                .AfterMap((viewModel, model)=> {
                    model.Picture = new byte[viewModel.PictureFromBrowser.Length];
                    // megnyitjuk és átmásoljuk a feltöltött állomny stream-jét a tömbbe
                    using (var stream = viewModel.PictureFromBrowser.OpenReadStream())
                    {
                        //ez helyett a cast helyett buffer + ciklus , ez csak demo
                        stream.Read(model.Picture, 0, (int)viewModel.PictureFromBrowser.Length);
                    }

                })
                
              
                ;
            //var model = new PhotoModel();
            //model.Description = viewModel.Description;
            //model.Title = viewModel.Title;
            //model.ContentType = viewModel.PictureFromBrowser.ContentType;
            ////átirni az adatokat a model.PicturefromBrowser --> model.Pictuer
            ////Készitunk egy fogadó byte tömböt, amiben a kép elfér
            //model.Picture = new byte[viewModel.PictureFromBrowser.Length];
            //// megnyitjuk és átmásoljuk a feltöltött állomny stream-jét a tömbbe
            //using (var stream = viewModel.PictureFromBrowser.OpenReadStream())
            //{
            //    //ez helyett a cast helyett buffer + ciklus , ez csak demo
            //    stream.Read(model.Picture, 0, (int)viewModel.PictureFromBrowser.Length);
            //}


            //Modelbol viewmodelt

            CreateMap<PhotoModel, PhotoViewModel>()
                ;

            //Update konfigurálás
            CreateMap<PhotoModel, PhotoViewModel>()
                ;

        }
    }
}
