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
    public class SearchProductoController : ControllerBase
    {
        private IProductoRepo Repo { get; set; }

        public SearchProductoController(IProductoRepo repo)
        {
            Repo = repo;
        }

        [HttpGet("{searchString}", Name = "SearchProducts")]
        public IEnumerable<ProductoYCategoriaBase> Search(string searchString) => Repo.Search(searchString).ToList();
    }
}
