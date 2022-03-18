using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FIMEFavor.DAL.Repos.Interfaces;
using FIMEFavor.Models.ViewModels;
using FIMEFavor.DAL.EF;
using FIMEFavor.Models.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIMEFavor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private IOrdenRepo Repo { get; set; }

        private readonly FimeContext _context;

        public OrdenController (IOrdenRepo repo, FimeContext context)
        {
            Repo = repo;
            _context = context;
        }


        // GET: api/<OrdenController>
        [HttpGet]
        public IEnumerable<Orden> Get() => Repo.GetAll();

        [HttpGet("/sinRepartidor")]
        public IEnumerable<Orden> GetOrdenesSinRepartidor()
            => Repo.GetOrdenesSinRepartidor().ToList();

        [HttpGet("/api/orden/Repartidor/{repartidorId}")]
        public IEnumerable<Orden> GetOrdenesRepartidor(int repartidorId)
            => Repo.GetOrdenesRepartidor(repartidorId).ToList();

        [HttpGet("/JustOne/{id}")]
        public IEnumerable<Orden> GetJustOne(int id)
            => Repo.GetJustOne(id).ToList();

        // GET api/<OrdenController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrdenWithDetails(int id)
        {
            var OrdenWithDetails = Repo.GetOneWithDetails(id);
            return OrdenWithDetails == null ? (IActionResult)NotFound() : new ObjectResult(OrdenWithDetails);
        }

        // POST api/<OrdenController>
        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = orden.Id }, orden);
        }

        // PUT api/<OrdenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, Orden orden)
        {
            if (id != orden.Id)
            {
                return BadRequest();
            }

            _context.Entry(orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CotizacionesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var factura = await _context.Ordenes.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
