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
    public partial class Login : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_Id) from Login_Table where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string cid = obj.Fun_exescalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Reg_Id from Login_Table where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string regid = obj.Fun_exescalar(str1);
                Session["User_Id"] = regid;

                string str2 = "select Log_Type from  Login_Table where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string logtype = obj.Fun_exescalar(str2);
                if (logtype == "admin")
                {
                    Response.Redirect("Admin homepage.aspx");
                    Label1.Text = "Admin";
                }
                else if (logtype == "user")
                {
                    Label1.Text = "User";
                }
            }
        }
    }
}