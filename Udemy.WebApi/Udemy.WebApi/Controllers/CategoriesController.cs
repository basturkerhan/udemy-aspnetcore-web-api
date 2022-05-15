using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Udemy.WebApi.Controllers.Data;

namespace Udemy.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public CategoriesController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [Authorize(Roles = "Admin")] // rolü admin olan girebilir
        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id)
        {
            var data = _productContext.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);
            return Ok(data);
        }

    }
}
