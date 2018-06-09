using Day1.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day1.API.Repositories
{
    public class CourseMockRepository : ICourseRepository
    {
        public IEnumerable<CourseModel> GetCourses()
        {
            return new List<CourseModel>
            {
                new CourseModel { id=1, Name="name1", Info="info1"},
                new CourseModel { id=2, Name="name2", Info="info2"},
                new CourseModel { id=3, Name="name3", Info="info3"},
                new CourseModel { id=4, Name="name4", Info="info4"},
                new CourseModel { id=5, Name="name5", Info="info5"},
                new CourseModel { id=6, Name="name6", Info="info6"}
            };
        }
    }
}
