using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odev.Api
{
    public class Config
    {
        private static Config _current;
        public static Config Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new Config();
                }
                return _current;
            }
            private set
            {
                _current = value;
            }
        }
        public Config()
        {
            MainDbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mainDb"].ToString();
        }
        public string MainDbConnectionString { get; set; }
    }
}