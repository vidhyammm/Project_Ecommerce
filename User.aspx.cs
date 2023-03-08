using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Ecommerce1
{
    public partial class User : System.Web.UI.Page
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
            string ch = DropDownList1.SelectedItem.Text;
            string r = RadioButtonList1.SelectedItem.Text;
            string img = "~/PHOTO/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(img));
            string ins = "insert into User_Table values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','"+ch+ "','" + TextBox6.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','"+r+"','"+img+"')";
            int i = obj.Fun_exenonquery(ins);
            string inslog = "insert into Login_Table values(" + reg_id + ",'user','" + TextBox7.Text + "','" + TextBox8.Text + "','active')";
            int j = obj.Fun_exenonquery(inslog);
            if(i!=0 && j!=0)
            {
                Label1.Text = "Registered...";
            }
        }
    }
}