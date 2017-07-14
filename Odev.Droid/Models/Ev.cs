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
using System.Net;

namespace Odev.Droid.Models
{
    public class Ev : BaseModel
    {
        private const string GetListApiUrl = "/ev/getlist";
        private const string GetDetayApiUrl = "/ev/getdetay";

        public int ID { get; set; }
        public string Il { get; set; }
        public string EmlakTip { get; set; }
        public int Alan { get; set; }
        public int OdaSayisi { get; set; }
        public int BinaYasi { get; set; }
        public int BulunduguKat { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string MainResimYolu { get; set; }

        public List<Resim> Resimler { get; set; }

        public static Result<List<Ev>> GetList(int pageIndex, int pageSize)
        {
            Result<List<Ev>> resutls = new Result<List<Ev>>();

            resutls = Requester.Create(CreateUrl(GetListApiUrl))
                .AddParam("pageIndex", pageIndex)
                .AddParam("pageSize", pageSize)
                .HttpGet<Result<List<Ev>>>();

            return resutls;
        }

        public static Result<Ev> GetDetay(int Id)
        {
            Result<Ev> resutls = new Result<Ev>();

            resutls = Requester.Create(CreateUrl(GetDetayApiUrl))
                .AddParam("Id", Id)
                .HttpGet<Result<Ev>>();

            return resutls;
        }
    }
}