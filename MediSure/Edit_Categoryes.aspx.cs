using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MediSure
{
    public partial class Edit_Categoryes : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-J1L5ATQ\SQLEXPRESS; database=MediSureDB; Integrated Security=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        void BindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CategoryTable", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string name = ((TextBox)row.Cells[1].Controls[0]).Text;
            string description = ((TextBox)row.Cells[2].Controls[0]).Text;

            FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
            Label lblPath = (Label)row.FindControl("lblImagePath");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

            string imagePath = lblPath.Text;
            if (fileUpload.HasFile)
            {
                string fileName = System.IO.Path.GetFileName(fileUpload.FileName);
                fileUpload.SaveAs(Server.MapPath("~/img/") + fileName);
                imagePath = "~/Images/" + fileName;
            }

            string status = ddlStatus.SelectedItem.Text;

            SqlCommand cmd = new SqlCommand("UPDATE CategoryTable SET Name=@name, Description=@desc, Image=@img, Status=@status WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.Parameters.AddWithValue("@img", imagePath);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            BindGrid();
        }
    }
}
