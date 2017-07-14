using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odev.Api.Models
{
    public class Result
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}