using ManageSD_WebApi.Interfaces;
using ManageSD_WebApi.Models;

namespace ManageSD_WebApi.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        private readonly SdContext _sdContext;

        public CourseRepo(SdContext sdContext)
        {
            _sdContext = sdContext;
        }

        public List<Course> GetAll()
        {
            return _sdContext.Courses.ToList();
            
        }

        public Course GetById(int id)
        {
            return _sdContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public Course GetByName(string name)
        {
           return _sdContext.Courses.FirstOrDefault(c => c.Name == name);
        }
        public void Add(Course course)
        {
            _sdContext.Courses.Add(course);
            _sdContext.SaveChanges();
        }

        public void Delete(int id)
        {
           Course crs = GetById(id);
            if (crs != null)
            {
                _sdContext.Courses.Remove(crs);
                _sdContext.SaveChanges();
            }
        }

      

        public void Update(int id, Course course)
        {
           Course oldCrs = GetById(id);
            if (oldCrs != null)
            {
                oldCrs.Name = course.Name;
                oldCrs.Description = course.Description;
                oldCrs.Duration = course.Duration;
                _sdContext.SaveChanges();
            }
        }
    }
}
