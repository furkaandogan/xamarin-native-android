using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Odev.Api.Models
{
    public class Ev
    {
        public int? ID { get; set; }
        public string Il { get; set; }
        public string EmlakTip { get; set; }
        public int? Alan { get; set; }
        public int? OdaSayisi { get; set; }
        public int? BinaYasi { get; set; }
        public int? BulunduguKat { get; set; }
        public decimal? Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string MainResimYolu { get; set; }

        public List<Resim> Resimler { get; set; }


        public static List<Ev> GetList(int pageIndex, int pageSize)
        {
            List<Ev> result = new List<Ev>();
            SqlCommand command = new SqlCommand("spGetListEv");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pageIndex", pageIndex);
            command.Parameters.AddWithValue("@pageSize", pageSize);
            DataTable dt = new SqlManager(Config.Current.MainDbConnectionString).GetSource(ref command);
            if (dt != null)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    result.Add(new Ev()
                    {
                        ID = Functions.ToInt(dtRow["evID"]),
                        EmlakTip = dtRow["evEmlakTip"].ToString(),
                        Il = dtRow["evIL"].ToString(),
                        Fiyat = Functions.ToDecimal(dtRow["evFiyat"]),
                        MainResimYolu = dtRow["resimYol"].ToString()
                    });
                }
            }
            return result;
        }

        public static Ev GetDetay(int Id)
        {
            Ev result = new Ev();
            SqlCommand command = new SqlCommand("spGetListEv");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@evID", Id);
            DataSet dtSet = new SqlManager(Config.Current.MainDbConnectionString).GetDataSet(ref command);
            if (dtSet.Tables != null && dtSet.Tables.Count > 0)
            {
                DataTable dt = dtSet.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];
                    result = new Ev()
                    {
                        ID = Functions.ToInt(dtRow["evID"]),
                        EmlakTip = dtRow["evEmlakTip"].ToString(),
                        Il = dtRow["evIL"].ToString(),
                        Fiyat = Functions.ToDecimal(dtRow["evFiyat"]),
                        MainResimYolu = dtRow["resimYol"].ToString()
                    };
                    if (dtSet.Tables.Count > 1)
                    {
                        dt = dtSet.Tables[1];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            result.Resimler = new List<Resim>();
                            foreach (DataRow dtRowItem in dt.Rows)
                            {
                                result.Resimler.Add(new Resim()
                                {
                                    Yol = dtRowItem["resimYol"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}