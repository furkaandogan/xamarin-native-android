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
    public abstract class BaseModel
    {
        const string BASE_API_URL = "http://api.exlinetr.com/odev/live";

        protected static string CreateUrl(string url)
        {
            return BASE_API_URL + url;
        }
    }
}