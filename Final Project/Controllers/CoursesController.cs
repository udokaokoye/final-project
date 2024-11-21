using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCourse()
        {
            return Ok(_context.Course.ToList());
        }

        [HttpGet("{id?}")]
        public IActionResult GetCourseItem(int? id)
        {
            if (id == null || id == 0)
            {
                var courses = _context.Course.Take(5).ToList();
                return Ok(courses);
            }
            Course course = _context.Course.Find(id);
            if (course == null)
                return NotFound();
            return Ok(course);

        }

        [HttpPost]
        public IActionResult PostCourse(Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Course course = _context.Course.Find(id);
            if (course == null)
                return NotFound();

            try
            {
                _context.Course.Remove(course);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult PutCourse(Course course)
        {
            try
            {
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

    
}
}
