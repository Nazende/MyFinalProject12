using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel void'ler için başlangıç, bir şey döndürmeyecek sadece işlem sonucu ve mesajı döndürecek
   public interface IResult
    {
        bool Success { get; }//Sadece okunabilir. İşlem başarılı mı başarısız mı(True, False)
        string Message { get; }// Ürün eklendi vs yölendirme mesajı
    }
}
