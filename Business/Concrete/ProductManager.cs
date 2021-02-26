using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //Ampulden Generate Constructor... dedik. Gevşek bağımlılık

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //[LogAspect]: Git bu methodu logla-->AOP: Bir methodun önünde, sonunda, bir method hata verdiğinde çalışan kod parçacıklarını AOP mimarisiyle yazarız. Business'ın içinde Business 
        //[Validate]
        //[Performance]
        [ValidationAspect(typeof(ProductValidator))]//Core/Autofac/Validation/class1 'den sonra yazdık
        public IResult Add(Product product) //IProductService' e methodu ekleyince buradan implemente ettik ve burası geldi.
            //Süslü parantez içine kodları yazdık.
        {
            // Business codes(İş kuralları):Kişiye kredi verilirken uygun olup olmaması
            //Validation(Doğrulama):Eklenmesi istediğimiz nesnenin yapısıyla alakalı kodları buraya yazarız.

            //var context = new ValidationContext<Product>(product); //Bu kodları buradan kestik "ValidationTool" a yapıştırdık.
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //ValidationTool.Validate(new ProductValidator(), product);//Validation klasörünü oluşturduktan sonra yazdık.Core/Autofac/Validation/class1 'den sonra sildik.

            //if (product.ProductName.Length<2)//10.ders
            //{
            //    //Magic strings: Stringleri ayrı ayrı yazmak. kötü bir şey
            //    return new ErrorResult(Messages.ProductNameInvalid);//Geçici kodların içine bu şk stringler yazmayacağız
            //}

            _productDal.Add(product); //ProductDal'dan Add Metodunu çağırıp parametre olarak verdiğimiz product'ı verdik. 

            return new SuccessResult(Messages.ProductAdded);// (true, "Ürün eklendi") true silindi, Result, SuccessResult'a döndü 10. ders
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 13)//10. ders/
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);// 10. ders, MaintenanceTime:Bakım zamanı, sistem bakımda
            }
            //İş kodları
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();//Bir iş sınıfı başka sınıfları new'lemez.
            //Bu yüzden bunu sildik.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);//10.ders
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)// interface'de yazınca yukarıdaki IProductServise kızdı, implemente edince de burası geldi//10.ders kod değişti

        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));//return _productDal.GetAll(p => p.CategoryId == id)
        }

        public IDataResult<Product> GetById(int productId)//IProductService' e methodu ekleyince buradan implemente ettik ve burası geldi.
       //Süslü parantez içine kodları yazdık.
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));//2 fiyat aralığındaki datayı getirecektir.
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }      
    }
}
