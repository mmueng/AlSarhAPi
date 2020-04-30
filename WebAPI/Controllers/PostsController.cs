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

            if (post == null)
            {
                return NotFound();
            }

            return post;
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
            foreach (var a in photoLists)
            {
                var photo = await _context.Photos.FindAsync(a.ImgPath);

                photo.CurPostID = post.PostID;
                photo.CurrPost = post;
                // newPhoto.CurPostID = post.PostID;
                // newPhoto.CurrPost = post;
                //await _PhotosController.PostPhoto(newPhoto);
                 post.PhotoList.Add(photo);
                await _context.SaveChangesAsync();
            }

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            Console.WriteLine("****************************");
            Console.WriteLine("****************************");
            Console.WriteLine("POst ID => " + post.PostID);
            Console.WriteLine("****************************");
            foreach (var a in photoLists)
            {
                var photo = await _context.Photos.FindAsync(a.ImgPath);

                photo.CurPostID = post.PostID;
                photo.CurrPost = post;

                await PutPhoto(photo.PhotoId, photo);
              _context.Entry(photo).State = EntityState.Modified;
                // newPhoto.CurPostID = post.PostID;
                // newPhoto.CurrPost = post;
                //await _PhotosController.PostPhoto(newPhoto);
                // post.PhotoList.Add(newPhoto);
                await _context.SaveChangesAsync();
            }
            foreach (var a in photoLists)
            {
                Photo newPhoto = new Photo();
                newPhoto.ImgPath = a.ImgPath;
                // newPhoto.CurPostID = post.PostID;
                // newPhoto.CurrPost = post;
                //await _PhotosController.PostPhoto(newPhoto);

                _context.Photos.Add(newPhoto);
                await _context.SaveChangesAsync();
            }
             _context.SaveChanges();

             return CreatedAtAction("GetPost", new { id = post.PostID }, post);
           // return Ok(new { post.PostID });
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
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