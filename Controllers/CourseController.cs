using ManageSD_WebApi.Interfaces;
using ManageSD_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageSD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepo _courseRepo;

        public CourseController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            List<Course> crs = _courseRepo.GetAll();
            if (crs.Count == 0)
            {
                return NotFound();
            }
            return Ok(crs);
        }

        [HttpGet("{id:int}", Name = "CourseDetailsRoute")]
        public IActionResult GetCourseById(int id)
        {

            Course crs = _courseRepo.GetById(id);
            if (crs != null) {
                return Ok(crs);

            }
            return NotFound();

        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetCourseByName(string name)
        {
            Course crs = _courseRepo.GetByName(name);
            if (crs != null)
            {
                return Ok(crs);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult PostCourse(Course newcourse)
        {
            if (newcourse != null)
            {
                _courseRepo.Add(newcourse);
                string url = Url.Link("CourseDetailsRoute", new { id = newcourse.Id });
                return Created(url, newcourse);
            }
            return BadRequest();
        }

        [HttpDelete]

        public IActionResult DeleteCourse(int id)
        {

            try
            {
                _courseRepo.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course crs)
        {
            if (ModelState.IsValid)
            {

               _courseRepo.Update(id, crs);
                return StatusCode(204);

            }
            return BadRequest(ModelState);

        }
    }
}
