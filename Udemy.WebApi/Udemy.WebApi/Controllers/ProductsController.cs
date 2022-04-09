using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        // route içini [Route("api/[controller]/[action]")] yapmazsan aşağıdaki metod isimlerinin bir önemi yok
        // rest e uygun olması için de öyle olması lazım, yani;
        // /api/products/getproducts olarak değil de;
        // /api/products demek yeterli olmalı. Böyle bir durumda aynı anda 2 GET motodu olursa çakışma olur
        // aşağıda bunu engellemek için birisi [HttpGet] içinde id alıyor.
        // çünkü bu hangi istek atılıyorsa onunla eşleştirme yapılıyor
        // aşağıdaki durumda;
        // /api/products denildiği zaman tüm ürünler
        // /api/products/2 dediğin zaman 2 id li ürün gelecek şekilde bir konfigürasyon yapıyoruz

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new object[]
            {
                new
                {
                    Name="Bilgisayar",
                    Price=15000
                },
                new
                {
                    Name="Telefon",
                    Price=5000
                },
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(new
            {
                Name="Bilgisayar",
                Price=15000
            });
        }

    }
}
