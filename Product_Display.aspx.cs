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
    public partial class Product_Display : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select * from Product_Table where Category_Id="+Session["Category_Id"]+"";
                DataSet ds = obj.Fun_exeadapter(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int pid = Convert.ToInt32(e.CommandArgument);
            Session["Product_Id"] = pid;
            Response.Redirect("ProductView.aspx");
        }
    }
}