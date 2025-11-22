using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MediSure
{
    public partial class LoginForm : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(lg_RegID) from Login_Table2 where lg_UserName='" + TextBox1.Text + "' and lg_Password='" + TextBox2.Text + "'";
            string cid = obj.Fun_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select lg_RegID from Login_Table2 where lg_UserName='" + TextBox1.Text + "' and lg_Password='" + TextBox2.Text + "'";
                string regid = obj.Fun_scalar(str1);
                Session["userid"] = regid;

                string str2 = "select lg_LogType from Login_Table2 where lg_UserName='" + TextBox1.Text + "' and lg_Password='" + TextBox2.Text + "'";
                string logtype = obj.Fun_scalar(str2);

                if (logtype == "admin")
                {
                    Response.Redirect("AdminPortal1.aspx");
                }
                else if (logtype == "user")
                {
                    Response.Redirect("DoctorsPortal.aspx");
                }
            }
            else
            {
                Label1.Text = "Invalid username or password";
            }










            //string str = "select count(Reg_Id) from Login_tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            //string cid = obj.Fun_scalar(str);
            //int cid1 = Convert.ToInt32(cid);
            //if (cid1 == 1)
            //{
            //    string str1 = "select Reg_Id from Login_tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            //    string regid = obj.Fun_scalar(str1);
            //    Session["userid"] = regid;

            //    string str2 = "select Log_type from Login_tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            //    string logtype = obj.Fun_scalar(str2);

            //    if (logtype == "admin")
            //    {
            //        Response.Redirect("AdminHome.aspx");
            //    }
            //    else if (logtype == "user")
            //    {
            //        Response.Redirect("UserHome.aspx");
            //    }
            //}
            //else
            //{
            //    Label1.Text = "Invalid username or password";
            //}

        }
    }
}