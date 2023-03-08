using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Ecommerce1
{
    public partial class Category : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string img = "~/Cat_img/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(img));
            string ins = "insert into Category_Table values('" + TextBox1.Text + "','" + img + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = obj.Fun_exenonquery(ins);
            if(i!=0)
            {
                Label1.Text = "SUCCESSFULLY INSERTED";
            }

        }
    }
}