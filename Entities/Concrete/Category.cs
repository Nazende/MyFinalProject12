using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category: IEntity //Bu işaretlemeyi görümce anlıyoruz ki 
    //category bir veritabanı tablosudur ve IEntity Category'nin referansını tutuyor.
    {
        //Çıplak class kalmasın: Eğerki bir class herhangi bir inheritanse ve interface implementasyonu almıyorsa anlıyoruz ki
        //ileride sorun yaşayacağız.Concrete klasöründeki sınıflar bir veritabanı tablosuna karşılık geliyor.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
