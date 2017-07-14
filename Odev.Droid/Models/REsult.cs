using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Odev.Droid.Models
{
    public class Result<T>
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}