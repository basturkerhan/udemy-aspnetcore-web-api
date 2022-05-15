using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Udemy.WebApi.Controllers.Data;
using Udemy.WebApi.Interfaces;

namespace Udemy.WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // route içini [Route("api/[controller]/[action]")] yapmazsan aşağıdaki metod isimlerinin bir önemi yok
        // rest e uygun olması için de öyle olması lazım, yani;
        // /api/products/getproducts olarak değil de;
        // /api/products demek yeterli olmalı. Böyle bir durumda aynı anda 2 GET motodu olursa çakışma olur
        // aşağıda bunu engellemek için birisi [HttpGet] içinde id alıyor.
        // çünkü bu hangi istek atılıyorsa onunla eşleştirme yapılıyor
        // aşağıdaki durumda;
        // /api/products denildiği zaman tüm ürünler
        // /api/products/2 dediğin zaman 2 id li ürün gelecek şekilde bir konfigürasyon yapıyoruz

        [Authorize] // jwt uazdıktan sonra bunu dediğin an iş bitti, login olmayan artık buraya giremez benden token almalı ki girebilsin
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Ok()=>200    NotFound()=>404 NoContent()=>204 Created()=>201 BadRequest()=>400
            List<Product> result = await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var addedProduct = await _productRepository.CreateAsync(product);
            return Created(string.Empty, addedProduct); // ilk parametre created olduktan sonra bir yere yönlendirme yapılsın mı
            // diye var. Genelde boş bırakılır.
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product) 
        {
            var checkProduct = await _productRepository.GetByIdAsync(product.Id);
            if(checkProduct == null)
            {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var checkProduct = await _productRepository.GetByIdAsync(id);
            if (checkProduct == null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

        // api/products/upload
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create); // path ve filemode istiyor
            await formFile.CopyToAsync(stream);
            return Created(String.Empty, formFile);
        }


        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    return Ok(new object[]
        //    {
        //        new
        //        {
        //            Name="Bilgisayar",
        //            Price=15000
        //        },
        //        new
        //        {
        //            Name="Telefon",
        //            Price=5000
        //        },
        //    });
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    return Ok(new
        //    {
        //        Name="Bilgisayar",
        //        Price=15000
        //    });
        //}

    }
}
