using Entities.Concrete;
using System.Collections.Generic;
using System;
using System.Text;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    //Veri taabanında yapacağım operasyonları içeren interface(IProductDal),
    //Ekle,sil, güncelle, listele,filtrele,getir...
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();// Burayı oluşturduktan sonra EfProductDal'a kodlarımızı yazdık(Ders9)
    }
}
//Code Refactoring: Kodun İyileştirilmesi denir.
