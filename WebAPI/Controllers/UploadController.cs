using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        private readonly AuthenticationContext _context;

        public UploadController(AuthenticationContext context)
        {
            _context = context;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                   // file.FileName.Insert(0, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                   var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                 fileName= fileName.Insert(0, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                       
                      //  string newFileName = stream.Name+ DateTime.Now.ToString();
                       file.CopyTo(stream);
                     //  file.Move(oldFileName, newFileName);

                    }
                   // string oldFileName = dbPath;
                  //  string newFileName = dbPath + DateTime.Now.ToString();
                  //  file.Move(oldFileName, newFileName);
                    //Photo newPhoto = new Photo();
                    // newPhoto.ImgPath = dbPath;
                    // _context.Photos.Add(newPhoto);
                    // _context.SaveChanges();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}