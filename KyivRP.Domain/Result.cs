using System;
using System.Collections.Generic;
using System.Text;

namespace KyivRP.Domain
{
    public class Result<T> where T : class
    {
        public T Value { get; set; }

        public string Error { get; set; }
    }
}
