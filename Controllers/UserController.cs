using Final_youtube.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IncidentDbContext _context;



        public UserController(IncidentDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetIncidents()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }



        // GET api/<UserController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        [HttpGet("GetByid")]
        public async Task<ActionResult<User>> GetIncident(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var incident = await _context.Users.FindAsync(id);



            if (incident == null)
            {
                return NotFound();
            }



            return incident;
        }



        // POST api/<UserController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }*/


        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> PostIncident(User incident)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'IncidentDbContext.Incidents'  is null.");
            }
            _context.Users.Add(incident);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetIncident", new { id = incident.UserId }, incident);
        }





        // PUT api/<UserController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, User incident)
        {
            if (id != incident.UserId)
            {
                return BadRequest();
            }



            _context.Entry(incident).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
            }



            return NoContent();
        }



        // DELETE api/<UserController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteIncident(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var incident = await _context.Users.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }



            _context.Users.Remove(incident);
            await _context.SaveChangesAsync();



            return NoContent();
        }



        private bool IncidentExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }


}

