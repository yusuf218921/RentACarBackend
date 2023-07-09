using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(false)
        {
        }

        public ErrorDataResult(string message, T data) : base(false, message, data)
        {
        }

        public ErrorDataResult(T data) : base(false, data)
        {
        }

        public ErrorDataResult(string message) : base(false, message)
        {
        }
    }
}
