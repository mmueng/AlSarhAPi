using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainDepsController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        private UserManager<ApplicationUser> _userManager;
        public MainDepsController(AuthenticationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/MainDeps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainDep>>> GetMainDeps()
        {   
            List<MainDep> AllList = _context.MainDeps
                //.Include(p => p.DepartmentList).ThenInclude(i=>i.CategoriesList).ThenInclude(p=>p.CategPostList).ToList();
               // .Include(p => p.DepartmentList).ThenInclude(p=>p.DepPostList)
               //=== .ThenInclude(i => i.CategoriesList).ThenInclude(p => p.CategPostList)
               // .ToListAsync();
            //return await _context.MainDeps.ToListAsync(); ;
          //  .Include(a => a.DepartmentList).ThenInclude(cs => cs.DepPostList)
 .Include(d => d.DepartmentList).ThenInclude(c => c.CategoriesList).ThenInclude(ca => ca.CategPostList).ThenInclude(ph=>ph.PhotoList).ToList();
             return  Ok( AllList);

        }

        // GET: api/MainDeps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainDep>> GetMainDep(int id)
        {
            var mainDep = await _context.MainDeps.FindAsync(id);

            if (mainDep == null)
            {
                return NotFound();
            }

            return mainDep;
        }

        // PUT: api/MainDeps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainDep(int id, MainDep mainDep)
        {
            if (id != mainDep.MainDepID)
            {
                return BadRequest();
            }

            _context.Entry(mainDep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainDepExists(id))
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

        // POST: api/MainDeps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<MainDep>> PostMainDep(MainDep mainDep)
        {
            //mainDep.DepartmentList = new List<Department>();
            _context.MainDeps.Add(mainDep);
          
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMainDep", new { id = mainDep.MainDepID }, mainDep);
          
               }


        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
         [Route("PostDep/{id}")]
        public async Task<ActionResult<Department>> PostDepartment(Department department,int id)
        {
           // MainDep d = _context.MainDeps.FirstOrDefault(m => m.MainDepID == id);
            var mainDep = await _context.MainDeps.FindAsync(id);
            if(mainDep.DepartmentList==null)
            {
                mainDep.DepartmentList = new List<Department>();
            }
            Department dep = new Department();
            dep = department;
            Console.WriteLine("*********************");
            Console.WriteLine("*********************");
            Console.WriteLine("*********************");
            Console.WriteLine(dep.DepID+" - " + dep.Name);
            Console.WriteLine(mainDep.MainDepID+" - " + mainDep.DepartmentList);
            // Newdep.CurrMainDepID = mainId; 
            //   department.CurrMainDep = d;
            _context.Departments.Add(dep);
            mainDep.DepartmentList.Add(dep);

            _context.Entry(mainDep).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.DepID }, department);
        }

        // DELETE: api/MainDeps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MainDep>> DeleteMainDep(int id)
        {
            var mainDep = await _context.MainDeps.FindAsync(id);
            if (mainDep == null)
            {
                return NotFound();
            }

            _context.MainDeps.Remove(mainDep);
            await _context.SaveChangesAsync();

            return mainDep;
        }

        private bool MainDepExists(int id)
        {
            return _context.MainDeps.Any(e => e.MainDepID == id);
        }
    }
}
