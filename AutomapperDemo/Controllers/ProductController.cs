using AutoMapper;
using AutomapperDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Create a variable to holder mapper instance
        private readonly IMapper _mapper;

        //Framework will inject the instance using Constructor
        public ProductController(IMapper mapper)
        {
            //Initialize the variable with the injected mapper instance
            _mapper = mapper;
        }

        private List<Product> listProducts = new List<Product>()
        {
            new Product { Id = 1001, Name="Laptop", Category="Electronics", Price = 1000, InStock = true},
            new Product { Id = 1002, Name="T-Shirt", Category="Merchandise", Price = 2000, InStock = true},
            new Product { Id = 1003, Name="Desktop", Category="Electronics", Price = 1000, InStock = false},
            new Product { Id = 1003, Name="Jacket", Category="Merchandise", Price = 2000, InStock = false}
        };


        [HttpGet]
        public ActionResult<ProductDTO> GetProdcuts()
        {
            // AutoMapper uses the pre-condition to decide if Price should be mapped
            //var productDTO = _mapper.Map<List<Product>, List<ProductDTO>>(listProducts);
            var productDTO = _mapper.Map<List<ProductDTO>>(listProducts);
            return Ok(productDTO);
        }
    }
}
