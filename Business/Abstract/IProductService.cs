using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //Bütün ürünleri listeleyecek bir ortam oluşturduk.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);//Tek başına bir ürün döndürüyor.
        IResult Add(Product product);//Bunu ekleyince ProductManager' daki IProductService kızar, der ki 
        //beni implemente etmen gerek çünkü sen IProductService'nin içine yeni bir method koydun.

    }
}
