using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Odev.Api
{
    public class SqlManager:IDisposable

    {
        protected SqlConnection Connection { get; set; }
        public SqlManager(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        protected void Connect()
        {
            if (Connection.State!=ConnectionState.Open)
                Connection.Open();

        }
        public DataTable GetSource(ref SqlCommand command)
        {
            Connect();
            command.Connection = Connection;
            DataTable dt = new DataTable();
            SqlDataAdapter dtAdapter = new SqlDataAdapter(command);
            dtAdapter.Fill(dt);

            command.Dispose();
            Dispose();

            return dt;
        }
        public void Execute(ref SqlCommand command)
        {
            Connect();
            command.Connection = Connection;
            command.ExecuteNonQuery();
            command.Dispose();
            Dispose();
        }
        public DataSet GetDataSet(ref SqlCommand command)
        {
            Connect();
            command.Connection = Connection;
            DataSet dtSet = new DataSet();
            SqlDataAdapter dtAdapter = new SqlDataAdapter(command);
            dtAdapter.Fill(dtSet);
            command.Dispose();
            Dispose();
            return dtSet;
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}