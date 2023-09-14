using Final_youtube.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Final_youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IncidentDbContext _context;



        public IncidentController(IncidentDbContext context)
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
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents()
        {
            if (_context.Incidents == null)
            {
                return NotFound();
            }
            return await _context.Incidents.ToListAsync();
        }



        // GET api/<UserController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        [HttpGet("GetByid")]
        public async Task<ActionResult<Incident>> GetIncident(int id)
        {
            if (_context.Incidents == null)
            {
                return NotFound();
            }
            var incident = await _context.Incidents.FindAsync(id);



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


        [HttpPost("AddIncident")]
        public async Task<ActionResult<Incident>> PostIncident(Incident incident)
        {
            if (_context.Incidents == null)
            {
                return Problem("Entity set 'IncidentDbContext.Incidents'  is null.");
            }
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetIncident", new { id = incident.IncidentId }, incident);
        }





        // PUT api/<UserController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, Incident incident)
        {
            if (id != incident.IncidentId)
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
            if (_context.Incidents == null)
            {
                return NotFound();
            }
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }



            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();



            return NoContent();
        }



        private bool IncidentExists(int id)
        {
            return (_context.Incidents?.Any(e => e.IncidentId == id)).GetValueOrDefault();
        }
    }
}
