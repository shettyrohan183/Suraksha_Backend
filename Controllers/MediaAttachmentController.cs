using Final_youtube.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaAttachmentController : ControllerBase
    {
        private readonly IncidentDbContext _context;

        public MediaAttachmentController(IncidentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaAttachment>>> GetMediaAttachments()
        {
            if (_context.MediaAttachments == null)
            {
                return NotFound();
            }

            var mediaAttachments = await _context.MediaAttachments.ToListAsync();
            return mediaAttachments;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<MediaAttachment>> GetMediaAttachment(int id)
        {
            if (_context.MediaAttachments == null)
            {
                return NotFound();
            }

            var mediaAttachment = await _context.MediaAttachments.FindAsync(id);

            if (mediaAttachment == null)
            {
                return NotFound();
            }

            return mediaAttachment;
        }

        [HttpPost("AddMediaAttachment")]
        public async Task<ActionResult<MediaAttachment>> PostMediaAttachment(MediaAttachment mediaAttachment)
        {
            if (_context.MediaAttachments == null)
            {
                return Problem("Entity set 'IncidentDbContext.MediaAttachments' is null.");
            }

            _context.MediaAttachments.Add(mediaAttachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediaAttachment", new { id = mediaAttachment.AttachmentId }, mediaAttachment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaAttachment(int id, MediaAttachment mediaAttachment)
        {
            if (id != mediaAttachment.AttachmentId)
            {
                return BadRequest();
            }

            _context.Entry(mediaAttachment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaAttachmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaAttachment(int id)
        {
            if (_context.MediaAttachments == null)
            {
                return NotFound();
            }

            var mediaAttachment = await _context.MediaAttachments.FindAsync(id);
            if (mediaAttachment == null)
            {
                return NotFound();
            }

            _context.MediaAttachments.Remove(mediaAttachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaAttachmentExists(int id)
        {
            return _context.MediaAttachments.Any(e => e.AttachmentId == id);
        }
    }
}
