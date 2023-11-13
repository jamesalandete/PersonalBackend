using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Response
{
    public partial class ErrorResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }
    }
}
