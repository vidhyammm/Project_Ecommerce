using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project_Ecommerce1
{
    public partial class UserProfileview : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind_Grid();
            }
        }
        public void Bind_Grid()
        {
            string strsel = "select User_Table.User_Id,User_Table.User_Name,Login_Table.Username,Login_Table.Status from User_Table join Login_Table on User_Table.User_Id=Login_Table.Reg_Id";
            DataSet ds = obj.Fun_exeadapter(strsel);
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
            int Reg_Id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox ststxt = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            string strup = "update Login_Table set Status='" + ststxt.Text + "' where Reg_Id='" + Reg_Id + "'";
            int s = obj.Fun_exenonquery(strup);
            GridView1.EditIndex = -1;
            Bind_Grid();
        }
    }
}