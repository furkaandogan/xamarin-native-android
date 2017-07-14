
using Android.Net;
using Java.IO;
using Java.Lang;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Impl.Client;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Odev.Droid
{
    class Requester
    {
        protected string Url { get; set; }
        protected Dictionary<string, string> Params { get; set; }

        private Requester() : base()
        {
            Url = string.Empty;
            Params = new Dictionary<string, string>();
        }
        protected Requester(string url) : this()
        {
            Url = url;
        }

        public static Requester Create(string url)
        {
            return new Requester(url);
        }
        public Requester AddParam(string name, object value)
        {
            //Type valueType = value.GetType();
            if (value is string || value is int || value is double || value is float || value is bool || value is char)
                Params.Add(name, value.ToString());
            else if (value is IEnumerable || value is object)
                Params.Add(name, Newtonsoft.Json.JsonConvert.SerializeObject(value));
            return this;
        }
        public T HttpGet<T>()
        {
            T result = default(T);
            string webResponse = string.Empty;
            try
            {
                if ((int)Android.OS.Build.VERSION.SdkInt > 9)
                {
                    Android.OS.StrictMode.ThreadPolicy policy = new Android.OS.StrictMode.ThreadPolicy.Builder().PermitAll().Build();
                    Android.OS.StrictMode.SetThreadPolicy(policy);
                }
                using (var httpclient = new DefaultHttpClient())
                {
                    using (var request = new HttpGet())
                    {
                        request.URI = new Java.Net.URI(Url+GetParams());
                        using (var response = httpclient.Execute(request))
                        {
                            webResponse = StreamToString(response.Entity.Content).Replace("https:", "http:").ToString();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                webResponse = string.Empty;
            }

            if (string.IsNullOrEmpty(webResponse))
                webResponse = "{}";

            result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(webResponse);
            return result;
        }

        protected string StreamToString(Stream stream)
        {
            if (stream == null)
                return string.Empty;

            BufferedReader buffer = new BufferedReader(new InputStreamReader(stream));
            return buffer.ReadLine();
        }

        protected string GetParams()
        {
            string paramsUrl = string.Empty;

            foreach (var item in Params)
                paramsUrl += item.Key + "=" + item.Value;

            if (this.Url.Contains("?"))
                paramsUrl = "&" + paramsUrl;
            else
                paramsUrl = "?" + paramsUrl;

            return paramsUrl;
        }

    }
}