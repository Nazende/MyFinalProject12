using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{   
    public class InMemoryProductDal: IProductDal
    {
        List<Product> _products; //Bütün metodların dışında tanımladık bu nedenle alt çizgiyle belirledik.
        //Global değişken, veri varmış gibi davranmak 
        public InMemoryProductDal() //ctor(Constructor);Bellekte referans aldığı zaman çalışacak olan blok.
        {
            //Oracle, Sql Server, Postgres, MongoDb den geliyor gibi simule ediyoruz
            _products = new List<Product> // İçinde bir sürü ürün barındıran demek
            {
                // Süslü parantezler içindeyken, alanları görmek için ctrl+sapace yaptık
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak",UnitPrice=15, UnitsInStock=15}, 
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera",UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon",UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare",UnitPrice=85, UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ: Language Integrated Query ile liste bazlı yapıları aynen SQL gibi filtreleyebiliriz.

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);//Foreach
           
            _products.Remove(productToDelete); //Biz ürünleri silerken onların primary keylerini kullanırız.
        }

        public List<Product> GetAll()
        {
            return _products; //Listenin tümünü döndürüyorum
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();//
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
