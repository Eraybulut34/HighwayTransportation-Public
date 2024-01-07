using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Common
{
    public abstract class ApiResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
