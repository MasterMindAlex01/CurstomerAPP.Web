using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurstomerAPP.Core
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public int Count { get; set; }
        public int Code { get; set; }
        public object Object { get; set; } = null!;
        public Exception Error { get; set; } = null!;
    }
}
