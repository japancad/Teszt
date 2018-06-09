using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day1.API.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Day1.API.Controllers
{
    public class CourseDataController : Controller
    {
        private readonly ICourseRepository _repository;

        public CourseDataController(ICourseRepository repository)
        {
            //nameof szövegként irnád
            if (repository == null)
            { throw new ArgumentNullException(nameof(repository)); }

            _repository = repository;
        }

        // GET: /<controller>/
        [Route("api/courses")]
        //[HttpGet("api/courses")]

        public IActionResult GetCourses()
        {
            //var repo = new CourseMockRepository();
            //return new JsonResult(repo.GetCourses());

            return new JsonResult(_repository.GetCourses());

        }

        //[HttpPost]
        //public IActionResult AddCourses()
        //{
        //    return new JsonResult(new { Name = "Postba jött" });
        //}

    }
}
