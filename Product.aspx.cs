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
    public partial class Product : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select Category_Id,Category_Name from Category_Table";
                DataSet ds = obj.Fun_exeadapter(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Category_Name";
                DropDownList1.DataValueField = "Category_Id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select--");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            string k = DropDownList1.SelectedItem.Value;
            string img = "~/Pro_img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(img));
            string ins = "insert into Product_Table values('" + k + "','" + TextBox1.Text + "','" + img + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            int i = obj.Fun_exenonquery(ins);
            if(i!=0)
            {
                Label2.Text = "SUCCESSFULLY INSERTED";
            }

        }
    }
}