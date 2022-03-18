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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIMEFavor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResenasController : ControllerBase
    {
        private IReseñaRepo Repo { get; set; }

        private readonly FimeContext _context;

        public ResenasController (IReseñaRepo repo, FimeContext context)
        {
            Repo = repo;
            _context = context;
        }
        // GET: api/<ReseñasController>
        [HttpGet]
        public IEnumerable<Reseña> Get() => Repo.GetAll();

        // GET api/<ReseñasController>/5
        [HttpGet("{cuentaId}")]
        public IActionResult Get(int id)
        {
            var item = Repo.GetReseñasCuenta(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<ReseñasController>
        [HttpPost]
        public async Task<ActionResult<Reseña>> PostReseña(Reseña reseña)
        {
            _context.Reseñas.Add(reseña);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = reseña.Id }, reseña);
        }

        // PUT api/<ReseñasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReseñasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
