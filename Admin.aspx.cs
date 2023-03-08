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
    public partial class Admin : System.Web.UI.Page
    {
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sel = "select max(Reg_Id)from Login_Table";
            string regid = obj.Fun_exescalar(sel);

            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string ins = "insert into Admin_Table values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
            int i = obj.Fun_exenonquery(ins);
            string inslog = "insert into Login_Table values(" + reg_id + ",'admin','" + TextBox5.Text + "','" + TextBox7.Text + "','active')";
            int j = obj.Fun_exenonquery(inslog);
            if(i!=0 && j!=0)
            {
                Label1.Text = "Registered...";
            }
          
        }
    }
}