using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClubController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClub()
        {
            return Ok(_context.Club.ToList());
        }

        [HttpGet("{id?}")]
        public IActionResult GetClubMember(int? id)
        {
            if (id == null || id == 0)
            {
                var clubMember = _context.Club.Take(5).ToList();
                return Ok(clubMember);
            }
            Club clubMemeber = _context.Club.Find(id);
            if (clubMemeber == null)
                return NotFound();
            return Ok(clubMemeber);

        }

        [HttpPost]
        public IActionResult PostClub(Club club)
        {
            _context.Club.Add(club);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClubMember(int id)
        {
            Club clubMember = _context.Club.Find(id);
            if (clubMember == null)
                return NotFound();

            try
            {
                _context.Club.Remove(clubMember);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult PutClubMember(Club clubMember)
        {
            try
            {
                _context.Entry(clubMember).State = EntityState.Modified;
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

