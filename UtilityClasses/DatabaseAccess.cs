using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLAppDemo
{
    internal class ProcessDatabase
    {
        string strcon;
        SqlConnection con;
        public ProcessDatabase()
        {
            strcon = "Data Source=HieuToTMa;Initial Catalog=winform_test;Integrated Security=True";//Connection string
        }
        public void Connect()
        {
            con = new SqlConnection(strcon);
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
        }
        public void Close()
        {
            if (con.State != System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }

        public DataTable ReadTable(string sql)
        {
            DataTable tb = new DataTable();
            Connect();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(tb);
            Close();
            return tb;
        }
        public void UpdateData(string sql)
        {
            Connect();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = sql;
            cm.Connection = con;
            cm.ExecuteNonQuery();
            cm.Dispose();
        }
        public int GetIntResult(string sql)
        {
            Connect();
            SqlCommand com = new SqlCommand(sql, con);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                reader.Read();
                com.Dispose();
                return reader.GetInt32(0);
            }
        }
        public double GetRealResult(string sql)
        {
            Connect();
            SqlCommand com = new SqlCommand(sql, con);
            using (SqlDataReader reader = com.ExecuteReader())
            {
                reader.Read();
                com.Dispose();

                return reader.GetDouble(0);



            }
        }
    }
}
