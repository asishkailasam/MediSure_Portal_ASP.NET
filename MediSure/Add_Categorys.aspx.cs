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
    public partial class Add_Categorys : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string p = "~/img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string ins = "INSERT INTO CategoryTable VALUES('" + TextBox1.Text + "', '" + p +"','"+TextBox2.Text+"','Avaiable')";
            int i = obj.Fun_Non_Query(ins);

            if (i == 1)
            {
                //Label1.Visible = true;
                Label5.Text = "Successfully Inserted";
            }
            else
            {
                
            }

        }
    }
}