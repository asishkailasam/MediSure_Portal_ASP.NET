using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace MediSure
{
    public partial class Edit_Product : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_Grid();
            }
        }
        public void Bind_Grid()
        {
            string str = "select * from Product_Table";
            DataSet ds = obj.Fn_Dataset(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind_Grid();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind_Grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            //if (i < 0 || i >= GridView1.DataKeys.Count)
            //{
            //    // Optionally log the error
            //    System.Diagnostics.Debug.WriteLine("Invalid row index: " + i);

            //    // Optionally show a message to the user (e.g., using a label)
            //    Label5.Text = "An error occurred while updating. Please try again.";

            //    // Cancel the update and reset the edit index
            //    GridView1.EditIndex = -1;
            //    Bind_Grid(); // Rebind the data to refresh the GridView
            //    return;
            //}
            //else
            //{
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtprice = (TextBox)GridView1.Rows[i].FindControl("TextBox_Price");
            TextBox txtspec = (TextBox)GridView1.Rows[i].FindControl("TextBox_Description");
            FileUpload newimg = (FileUpload)GridView1.Rows[i].FindControl("FileUpload_newimg");
            TextBox txtstock = (TextBox)GridView1.Rows[i].FindControl("TextBox_Stock");
            string p = "";
            if (newimg.HasFile)
            {
                p = "~/img/" + newimg.FileName;
                newimg.SaveAs(MapPath(p));
            }
            else
            {
                string oldimg = "select Product_Image from Product_Table where Product_ID=" + getid + "";
                DataSet ds = obj.Fn_Dataset(oldimg);
                ds.Tables[0].Rows[0]["Product_Image"].ToString();
            }

            DropDownList ddlstatus = (DropDownList)GridView1.Rows[i].FindControl("DropDownList_status");

            string str = "update Product_Table set Product_Price=" + txtprice.Text + ",Product_Image='" + p + "',Product_Description='" + txtspec.Text + "',Stock='" + txtstock.Text + "',Product_Status='" + ddlstatus.SelectedItem.Text + "' where Product_ID=" + getid + "";
            obj.Fun_Non_Query(str);
            GridView1.EditIndex = -1;
            //Label5.Text = "Successfully Updated";
            Bind_Grid();
            //}
        }
    }
}