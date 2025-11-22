using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MediSure
{
    public partial class DoctorRegistration : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "SELECT MAX([lg_RegID]) FROM Login_Table2";
            string maxregid = obj.Fun_scalar(sel);
            int reg_id = 0;
            if (maxregid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;
            }
            string ins = "INSERT INTO User_Reg_Table VALUES(" + reg_id + ", '" + TextBox1.Text + "', '" + TextBox2.Text + "')";
            int i = obj.Fun_Non_Query(ins);

            if (i == 1)
            {
                string inslog = "INSERT INTO Login_Table2 VALUES(" + reg_id + ", '" + TextBox3.Text + "', '" + TextBox4.Text + "', 'user', 'active')";
                int j = obj.Fun_Non_Query(inslog);
                // Optionally show success message here
                if (i == 1 && j == 1)
                {
                    Label5.Text = "Successfully Registered";
                }
            }
            else
            {
                Label5.Text = "Invalid Entry";

            }








            //string sel = "SELECT MAX([Reg_Id]) FROM Login_tab";
            //string maxregid = obj.Fun_scalar(sel);
            //int reg_id = 0;
            //if (maxregid == "")
            //{
            //    reg_id = 1;
            //}
            //else
            //{
            //    int newregid = Convert.ToInt32(maxregid);
            //    reg_id = newregid + 1;
            //}
            //string ins = "INSERT INTO User_Reg_tab VALUES(" + reg_id + ", '" + TextBox1.Text + "', '" + TextBox2.Text + "')";
            //int i = obj.Fun_Non_Query(ins);

            //if (i == 1)
            //{
            //    string inslog = "INSERT INTO Login_tab VALUES(" + reg_id + ", '" + TextBox3.Text + "', '" + TextBox4.Text + "', 'user', 'active')";
            //    int j = obj.Fun_Non_Query(inslog);
            //    // Optionally show success message here
            //    if (i == 1 && j == 1)
            //    {
            //        Label5.Text = "Successfully Registered";
            //    }
            //}
            //else
            //{
            //    Label5.Text = "Invalid Entry";

            //}










        }
    }
}