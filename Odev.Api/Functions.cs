using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odev.Api
{
    public class Functions
    {
       public static int  ToInt(object val)
        {
            if (val==null)
                return 0;

            if (val is DBNull)
                return 0;
            try
            {
                return Convert.ToInt32(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal ToDecimal(object val)
        {
            if (val == null)
                return 0;

            if (val is DBNull)
                return 0;
            try
            {
                return Convert.ToDecimal(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}