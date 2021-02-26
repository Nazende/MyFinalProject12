using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message)//ctor
        {

        }
        public SuccessDataResult(T data):base(data,true)//ctor
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
            //default:Data'ya karşılık geliyor return tipi int'tir. ama siz orada bir şey döndürmek istemiyorsunuz.
        {

        }
        public SuccessDataResult():base(default,true)//Bunlar kullanabileceğimiz versiyonlar(9,13.17 ve 21. satır)
        {

        }
    }
}
