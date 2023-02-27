using System;
using System.Collections.Generic;
using System.Text;

namespace KTS.Framework.Models
{
    public class ErrorResponseModel<T>

    {
        public string? Name { get; set; }
        public int Status { get; set; }
        public string? Message { get; set; }
        public T Details { get; set; } 
        public string? RequestId { get; set; }
    }
}

