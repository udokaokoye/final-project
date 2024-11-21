using Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            return Ok(_context.Team.ToList());
        }

        [HttpGet("{id?}")]
        public IActionResult GetTeamMember(int? id)
        {
            if (id == null || id == 0)
            {
                var teamMember = _context.Team.Take(5).ToList();
                return Ok(teamMember);
            }
            Team teamMemeber = _context.Team.Find(id);
            if (teamMemeber == null)
                return NotFound();
            return Ok(teamMemeber);

        }

        [HttpPost]
        public IActionResult PostTeam(Team team)
        {
            _context.Team.Add(team);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(int id)
        {
            Team teamMember = _context.Team.Find(id);
            if (teamMember == null)
                return NotFound();

            try
            {
                _context.Team.Remove(teamMember);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult PutTeamMember(Team teamMember)
        {
            try
            {
                _context.Entry(teamMember).State = EntityState.Modified;
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
