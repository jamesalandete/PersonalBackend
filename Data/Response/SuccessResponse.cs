using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Response
{
    public partial class SuccessResponse<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public List<T>? Result { get; set; }
    }
}
