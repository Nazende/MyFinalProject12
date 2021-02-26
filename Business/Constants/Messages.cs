using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages // static: Sürekli new'lememek için sabit tutmak için. newlemekle uğraşmamak için
    {
        public static string ProductAdded = "Ürün eklendi";//ProductAdded ve ProductNameInvalid değişken olmalarına rağmen büyük harfle(Pascal Case) yazdık çünkü public'ler pascal case yazılır.
        public static string ProductNameInvalid = "Ürün ismi geçersiz"; //Bunları yaptıktan sonra ProductManager'a git, stringlerden kurtul.
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
    }
}
