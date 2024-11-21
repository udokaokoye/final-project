using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibraryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLibrary()
        {
            return Ok(_context.Library.ToList());
        }

        [HttpGet("{id?}")]
        public IActionResult GetLibraryMember(int? id)
        {
            if (id == null || id == 0)
            {
                var libraryMember = _context.Library.Take(5).ToList();
                return Ok(libraryMember);
            }
            Library libraryMemeber = _context.Library.Find(id);
            if (libraryMemeber == null)
                return NotFound();
            return Ok(libraryMemeber);

        }

        [HttpPost]
        public IActionResult PostLibrary(Library library)
        {
            _context.Library .Add(library);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibraryMember(int id)
        {
            Library libraryMember = _context.Library.Find(id);
            if (libraryMember == null)
                return NotFound();

            try
            {
                _context.Library.Remove(libraryMember);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult PutLibraryMember(Club libraryMember)
        {
            try
            {
                _context.Entry(libraryMember).State = EntityState.Modified;
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

