using ManageSD_WebApi.Models;

namespace ManageSD_WebApi.Interfaces
{
    public interface ICourseRepo
    {
        List<Course> GetAll();

        Course GetById(int id);

        Course GetByName(string name);

        void Add(Course course);
        void Update(int id,Course course);

        void Delete(int id);
    }
}
