using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]// Bu isteği yaparken insanlar size nasıl ulaşsın? api/Controller'ın ismi
    [ApiController] //Attribute:Bir class ile ilgili bilgi verir
    public class ProductsController : ControllerBase
    {
        //Loosely coupled(Gevşek bağımlılık)

        IProductService _productService;//Ampulden Generate Constructor yaptık

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() //public List<Product> Get()
        {
            //Depedency chain(Bağımlılık zinciri) var burada
            //ProductManager içine gidip GetAll methodunun if bloğunu açıklama satırı yaptık
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();//var result=productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); //return result.Data; //return BadRequest(result.Message);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
