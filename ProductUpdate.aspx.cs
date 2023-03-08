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
    public partial class ProductUpdate : System.Web.UI.Page
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
            string strsel = "select * from Product_Table";
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
            int Product_Id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtdesc = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            TextBox txtstatus = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            TextBox txtstock = (TextBox)GridView1.Rows[i].Cells[8].Controls[0];

            string strup = "update Product_Table set Product_Description='" + txtdesc.Text + "',Product_Price='" + txtprice.Text + "',Product_Status='" + txtstatus.Text + "',Product_Stock='" + txtstock.Text + "' where Product_Id='" + Product_Id + "'";
            int s = obj.Fun_exenonquery(strup);
            GridView1.EditIndex = -1;
            Bind_Grid();
        }
    }
}