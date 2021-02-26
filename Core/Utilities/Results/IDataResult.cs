using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult //Success and message
    {
        T Data { get; }//Senin içinde mesaj ve işlem sonucu dışında T türünde bir data da olur.
    }
}
