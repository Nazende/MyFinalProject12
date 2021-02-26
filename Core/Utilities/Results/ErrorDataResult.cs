using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)//ctor
        {

        }
        public ErrorDataResult(T data) : base(data, false)//ctor
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
            //default:Data'ya karşılık geliyor return tipi int'tir. ama siz orada bir şey döndürmek istemiyorsunuz.
        {

        }
        public ErrorDataResult() : base(default, false)//Bunlar kullanabileceğimiz versiyonlar(9,13.17 ve 21. satır)
        {

        }
    }
}
