using System.Collections.Generic;
using Udemy.WebApi.Controllers.Data;

namespace Udemy.WebApi.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
