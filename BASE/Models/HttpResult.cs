using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Models
{
    public class HttpResult
    {
        public bool success { get; set; }
        public object? data { get; set; }
        public string message { get; set; }
    }
}
