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
    public class ProductosController : ControllerBase
    {
        private IProductoRepo Repo { get; set; }

        private readonly FimeContext _context;


        public ProductosController(IProductoRepo repo, FimeContext context)
        {
            Repo = repo;
            _context = context;
        }

        // GET: api/<ProductosController>
        /*[HttpGet]
        public IEnumerable<Producto> Get() => Repo.GetAll();*/

        [HttpGet]
        public IEnumerable<ProductoYCategoriaBase> GetAll() => Repo.GetAllWithCategoryName();

        /*[HttpGet("product", Name = "Primer Prodcuto")]
        public Producto GetProducto() => Repo.GetLast();*/

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.GetOneWithCategoryName(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("/api/Productos/vendedor/{VendedorId}", Name = "VendedorId")]
        public IEnumerable<ProductoYCategoriaBase> GetProductosOneVendedor(int VendedorId)
            => Repo.GetAllOneVendedor(VendedorId).ToList();

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = producto.Id }, producto);
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

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

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
