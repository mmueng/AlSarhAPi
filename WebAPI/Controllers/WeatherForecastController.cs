﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private AuthenticationContext dbContext;
        public WeatherForecastController(AuthenticationContext context)
        {
            dbContext = context;
        }
        [HttpPost]
        public async Task<ActionResult<MainDep>> PostMainDep(MainDep model)
        {
            dbContext.MainDeps.Add(model);
            try
            {
              await   dbContext.SaveChangesAsync();

                return CreatedAtAction("GetMainDepDetail", new { id = model.MainDepID }, model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
       // [HttpPost]
      //  public void Post([FromBody] string value)
      //  {
      //  }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       // private static readonly string[] Summaries = new[]
       // {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
       // };

       // private readonly ILogger<WeatherForecastController> _logger;

      //  public WeatherForecastController(ILogger<WeatherForecastController> logger)
       // {
       //     _logger = logger;
      //  }

     //   [HttpGet]
      //  public IEnumerable<WeatherForecast> Get()
     //   {
       //     var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
         //       TemperatureC = rng.Next(-20, 55),
         //       Summary = Summaries[rng.Next(Summaries.Length)]
         //   })
         //   .ToArray();
       // }
    }
}
