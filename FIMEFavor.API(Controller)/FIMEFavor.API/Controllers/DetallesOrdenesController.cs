using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FIMEFavor.DAL.Repos.Interfaces;
using FIMEFavor.Models.ViewModels.Base;
using FIMEFavor.DAL.EF;
using FIMEFavor.Models.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIMEFavor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesOrdenesController : ControllerBase
    {

        private IDetallesOrdenesRepo Repo { get; set; }

        private readonly FimeContext _context;

        public DetallesOrdenesController(IDetallesOrdenesRepo repo, FimeContext context)
        {
            Repo = repo;
            _context = context;
        }
        // GET: api/<DetallesOrdenesController>
        [HttpGet]
        public IEnumerable<DetallesOrden> Get() => Repo.GetAll();

        // GET api/<DetallesOrdenesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DetallesOrdenesController>
        [HttpPost]
        public IActionResult Create(int agenteId, [FromBody] DetallesOrden item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            Repo.Add(item);
            return CreatedAtRoute("Get",
                new { controller = "CotizacionDetalles" });

        }

        // PUT api/<DetallesOrdenesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetallesOrdenesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
