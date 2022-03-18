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
    public class CuentasController : ControllerBase
    {
        private ICuentasRepo Repo { get; set; }

        private readonly FimeContext _context;

        public CuentasController (ICuentasRepo repo, FimeContext context)
        {
            Repo = repo;
            _context = context;
        }

        // GET: api/<CuentasController>
        [HttpGet]
        public IEnumerable<Cuentas> Get() => Repo.GetAll();

        [HttpGet("{searchCuenta}", Name = "SearchCuenta")]
        public IEnumerable<Cuentas> Search(string searchCuenta)
            => Repo.GetCuenta(searchCuenta);

        // GET api/<CuentasController>/5
        /*[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }*/

        // POST api/<CuentasController>
        [HttpPost]
        public async Task<ActionResult<Cuentas>> PostCuenta(Cuentas cuentas)
        {
            _context.Cuentas.Add(cuentas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cuentas.Id }, cuentas);
        }

        // PUT api/<CuentasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(int id, Cuentas cuentas)
        {
            if (id != cuentas.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuentas).State = EntityState.Modified;

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

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            var agente = await _context.Cuentas.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }

            _context.Cuentas.Remove(agente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
