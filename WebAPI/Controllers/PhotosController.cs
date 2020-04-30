using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public PhotosController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
        {
            return await _context.Photos.ToListAsync();
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int id, Photo photo)
        {
            if (id != photo.PhotoId)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       
         [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
            var post = await _context.Posts.FindAsync(photo.CurPostID);
            photo.CurrPost = post;
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();

          return CreatedAtAction("GetPhoto", new { id = photo.PhotoId }, photo);
        }
      
        //[HttpPost, DisableRequestSizeLimit]
      //  public IActionResult Upload()
      //  {
        //    try
        //    {
          //      var file = Request.Form.Files[0];
          //      var folderName = Path.Combine("Resources", "Images");
          //      var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

           //     if (file.Length > 0)
           //     {
            //        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
              //      var fullPath = Path.Combine(pathToSave, fileName);
              //      var dbPath = Path.Combine(folderName, fileName);

             //       using (var stream = new FileStream(fullPath, FileMode.Create))
              //      {
              //          file.CopyTo(stream);
              //      }
               //     Photo newPhoto = new Photo();
               //      newPhoto.ImgPath = dbPath;
                //     _context.Photos.Add(newPhoto);
                //     _context.SaveChanges();
               //     return Ok(new { dbPath });
              //  }
             //   else
             //   {
              //      return BadRequest();
           //     }
           // }
          //  catch (Exception ex)
          //  {
           //     return StatusCode(500, $"Internal server error: {ex}");
        //    }
      //  }


        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Photo>> DeletePhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return photo;
        }

        private bool PhotoExists(int id)
        {
            return _context.Photos.Any(e => e.PhotoId == id);
        }
    }
}
