using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
namespace MediSure
{

    public class ConnectionClass
    {
        SqlConnection con;
        SqlCommand cmd;
        public ConnectionClass()
        {
            con = new SqlConnection(@"server=DESKTOP-J1L5ATQ\SQLEXPRESS; database=MediSureDB; Integrated Security=true;");
            //con = new SqlConnection(@"server=DESKTOP-J1L5ATQ\SQLEXPRESS; database=MultiUser_DB; Integrated Security=true;");
        }

        public int Fun_Non_Query(string sql)
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public string Fun_scalar(string sql)
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }

        //public DataSet Fn_Dataset(string sqlquery)
        //{
        //    if (con.State == ConnectionState.Open)
        //    {
        //        con.Close();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;
        //}


        public DataSet Fn_Dataset(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



    }
}

//----------------------------------------------Chat gpt -------------------------------------------------------

