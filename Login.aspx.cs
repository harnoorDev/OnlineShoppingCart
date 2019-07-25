using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace FINALPROJECT_shoppingCart_
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblpassword.Visible = false;
            lblusername.Visible = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            connection.Open();
            string checkuser = "select count(*) from users where username='" + txtusername.Text + "'";
            SqlCommand command = new SqlCommand(checkuser, connection);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            if (temp == 1)
            {
                lblusername.Visible = false;
                connection.Open();
                string checkpass = "select password from users where username ='" + txtusername.Text + "'";
                SqlCommand passcommand = new SqlCommand(checkpass, connection);
                string password = passcommand.ExecuteScalar().ToString().Replace(" ","");
                if(password == txtpassword.Text)
                {
                    lblpassword.Visible = false;
                    Session["New"] = txtusername.Text;
                    lblpassword.Visible = false;
                    Response.Write("Password is correct");
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    lblpassword.Visible = true;
                    
                }

            }
            else
            {
                lblusername.Visible = true;

            }
            connection.Close();
        }
    }
}