using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

using System.Net.Http.Headers;
namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private readonly PhotosController _PhotosController;
        public PostsController(AuthenticationContext context, PhotosController photosController)
        {
            _context = context;
            _PhotosController = photosController;

        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            var list = _context.Posts.Include(p => p.PhotoList);
            var a = await list.FirstOrDefaultAsync(a => a.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return a;
           // return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.PostID)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            var photoLists = post.PhotoList;
            //post.PhotoList = null;
            var maindep = await _context.MainDeps.FindAsync(post.pMainDepID);
            post.CurrMainDep = maindep;
            var dep = await _context.Departments.FindAsync(post.CurrDepID);
            post.CurrDepartment = dep;
            var categ = await _context.Categories.FindAsync(post.CurrCategoryID);
            post.CurrCategory = categ;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetPost", new { id = post.PostID }, post);
            return Ok(new { post.PostID });
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            var list = _context.Posts.Include(p => p.PhotoList);
                var ph = _context.Photos.Where(p => p.CurPostID==id).ToList();
            foreach(var photo in ph)
            {
                if (System.IO.File.Exists(photo.ImgPath))
                {
                    System.IO.File.Delete(photo.ImgPath);
                }
                _context.Photos.Remove(photo);
            }
            var a = await list.FirstOrDefaultAsync(a => a.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

          //  _context.Posts.Remove(post);
            _context.Posts.Remove(a);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostID == id);
        }


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
                
            }

            return NoContent();
        }
    }
}