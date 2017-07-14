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
    public class Resim
    {
        public int? ID { get; set; }

        public string Yol { get; set; }

        public int? EvID { get; set; }
    }
}