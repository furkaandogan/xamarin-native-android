using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Odev.Api.Controllers
{
    public class EvController : BaseApiController
    {

        public Models.Result GetList(int pageIndex = 0, int pageSize = 20)
        {
            Models.Result result = new Models.Result();
            result.IsOk = true;
            result.Data = Models.Ev.GetList(pageIndex, pageSize);
            return result;
        }

        public Models.Result GetDetay(int Id)
        {
            Models.Result result = new Models.Result();
            result.IsOk = true;
            result.Data = Models.Ev.GetDetay(Id);

            return result;
        }

    }
}