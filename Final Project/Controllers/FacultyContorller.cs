using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacultyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFaculty()
        {
            return Ok(_context.Faculty.ToList());
        }

        [HttpGet("{id?}")]
        public IActionResult GetFacultyMember(int? id)
        {
            if (id == null || id == 0)
            {
                var facultyMember = _context.Faculty.Take(5).ToList();
                return Ok(facultyMember);
            }
            Faculty facultyMemeber = _context.Faculty.Find(id);
            if (facultyMemeber == null)
                return NotFound();
            return Ok(facultyMemeber);

        }

        [HttpPost]
        public IActionResult PostFaculty(Faculty faculty)
        {
            _context.Faculty.Add(faculty);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFacultyMember(int id)
        {
            Faculty facultyMember = _context.Faculty.Find(id);
            if (facultyMember == null)
                return NotFound();

            try
            {
                _context.Faculty.Remove(facultyMember);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult PutFacultyMember(Faculty facultyMember)
        {
            try
            {
                _context.Entry(facultyMember).State = EntityState.Modified;
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

