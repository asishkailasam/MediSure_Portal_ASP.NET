//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data.SqlClient;
//using System.Reflection.Emit;

//namespace MediSure
//{
//    public partial class Add_Product : System.Web.UI.Page
//    {
//        ConnectionClass obj = new ConnectionClass();
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                string sel = "SELECT id,Name FROM CategoryTable";
//                DropDownList1.DataSource = obj.Fun_Non_Query(sel);
//                DropDownList1.DataTextField = "Name";
//                DropDownList1.DataValueField = "id";
//                DropDownList1.DataBind();
//                DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
//            }
//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            string p = "img/" + FileUpload1.FileName;
//            FileUpload1.SaveAs(Server.MapPath(p));

//            //string ins = "INSERT INTO ProductTable ('"+DropDownList1.SelectedItem.Value+"','"+TextBox1.Text+"','"+TextBox2.Text+","+TextBox3.Text+"','"+p+"','"+TextBox4.Text')";
//            string ins = "INSERT INTO ProductTable VALUES ('" + DropDownList1.SelectedItem.Value + "', '" +TextBox1.Text + "', '" +TextBox2.Text + ", " + TextBox3.Text + "', '" +p + "', '" +TextBox4.Text + "')";

//            int i = obj.Fun_Non_Query(ins);

//            if (i == 1)
//            {
//                //Label8.Visible = true;
//                //Label8.Text = "Successfully Inserted";
//            }
//            else
//            {
//                //Label8.Visible = true;
//                //Label8.Text = "Invalid entry";
//            }
//        }
//    }

//}



//--------------------------------------------------Test---------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace MediSure
{
    public partial class Add_Product : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string sel = "SELECT id,Name FROM CategoryTable";
            //    DropDownList1.DataSource = obj.Fun_Non_Query(sel);
            //    DropDownList1.DataTextField = "Name";
            //    DropDownList1.DataValueField = "id";
            //    DropDownList1.DataBind();
            //    DropDownList1.Items.Insert(0,"-Select-");
            //}

            if (!IsPostBack)
            {
                string sel = "SELECT id, Name FROM CategoryTable";
                DataSet ds = obj.Fn_Dataset(sel);
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(p));

            //string ins = "INSERT INTO ProductTable ('"+DropDownList1.SelectedItem.Value+"','"+TextBox1.Text+"','"+TextBox2.Text+","+TextBox3.Text+"','"+p+"','"+TextBox4.Text')";
            //string ins = "INSERT INTO ProductTable VALUES ('" + DropDownList1.SelectedItem.Value + "', '" + TextBox1.Text + "', '" + TextBox2.Text + ", " + TextBox3.Text + "', '" + p + "', '" + TextBox4.Text + "')";
            //string ins = "insert into Product_Table values('" + DropDownList1.SelectedItem.Value + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + p + "','" + TextBox4.Text + "','Available') ";
            string ins = "INSERT INTO Product_Table (Category_ID, Product_Name, Product_Price, Product_Description, Product_Image, Stock, Product_Status) " + "VALUES ('" + DropDownList1.SelectedItem.Value + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + p + "', '" + TextBox4.Text + "', 'Available')";

            int i = obj.Fun_Non_Query(ins);

            if (i == 1)
            {
                //Label8.Visible = true;
                //Label8.Text = "Successfully Inserted";
            }
            else
            {
                //Label8.Visible = true;
                //Label8.Text = "Invalid entry";
            }
        }
    }

}