using Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete
{
    public class DataResult<T> : Result ,IDataResult<T>
    {
        public bool Success { get; }

        public string Message { get; }

        public T Data { get; }
        public DataResult(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }
        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }
        public DataResult(bool success, string message) : base(success,message) 
        {
            
        }
        public DataResult(bool success) : base(success)
        {
            
        }
    }
}
