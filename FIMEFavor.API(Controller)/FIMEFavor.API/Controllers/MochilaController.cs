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
    public class MochilaController : ControllerBase
    {
        private IMochilaRepo Repo { get; set; }

        private readonly FimeContext _context;

        public MochilaController(IMochilaRepo repo, FimeContext context)
        {
            Repo = repo;
            _context = context;
        }
        // GET: api/<MochilaController>

        [HttpGet(Name = "GetMochila")]
        public IEnumerable<MochilaConInfoProducto> GetShoppingCart(int cuentaId)
            => Repo.GetShoppingCartRecords(cuentaId).ToList();



        [HttpPost] //required even if method name starts with "Post"
        public IActionResult Create(int cuentaId, [FromBody] Mochila item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            item.FechaCreacion = DateTime.Now;
            item.CuentaId = cuentaId;
            Repo.Add(item);
            //Location: http://localhost:8477/api/ShoppingCart/0 (201)
            return CreatedAtRoute("GetShoppingCart",
                new { controller = "CarritoRecord", agenteId = cuentaId });
        }
        
        // PUT api/<MochilaController>/5
        [HttpPut("{mochilaId}")] //Required even if method name starts with Put
        public IActionResult Update(int agenteId, int shoppingCartRecordId, [FromBody] Mochila item)
        {
            if (item == null || item.Id != shoppingCartRecordId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            item.FechaCreacion = DateTime.Now;
            Repo.Update(item);
            //Location: http://localhost:8477/api/ShoppingCart/0 (201)
            return CreatedAtRoute("GetShoppingCart", new { agenteId = agenteId });
        }

        // DELETE api/<MochilaController>/5
        [HttpDelete("{mochilaId}/{timeStamp}")] //Required even if method name starts with Delete
        public IActionResult Delete(int agenteId, int carritoRecordId, string timeStamp, Mochila mochila)
        {
            if (!timeStamp.StartsWith("\""))
            {
                timeStamp = $"\"{timeStamp}\"";
            }
            var ts = JsonConvert.DeserializeObject<byte[]>(timeStamp);
            Repo.Delete(mochila);
            return NoContent();
        }

        [HttpPost("ordenar")]
        public IActionResult Ordenar([FromBody] Orden orden)
        {
            int cotizacionId;

            cotizacionId = Repo.Ordenar(orden.ClienteId, orden.LugarDeEntrega, orden.Comentarios, orden.MetodoDePago);

            //Location: http://localhost:8477/api/Orders/1
            return CreatedAtRoute("GetShoppingCart", 1);
        }
    }
}
