using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;



namespace L2Morphine.CharPanel
{
    public partial class Login : System.Web.UI.Page
    {
        string strcon = "Server=localhost;Database=loginserver_beta;Uid=root;Pwd=admin";
        string str;
        MySqlCommand com;
        object obj;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender,EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(strcon);
            con.Open();
            str = "select count(*) from accounts where login=@UserName and password=@Password";
            com = new MySqlCommand(str, con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@UserName", txtboxUsername.Text);
            com.Parameters.AddWithValue("@Password", MyEncryption(txtbotPassword.Text));
            obj = com.ExecuteScalar();
            if (Convert.ToInt32(obj) != 0)
            {
                Session["username"] = txtboxUsername.Text;
                Response.Redirect("ManChar.aspx");
            }
            else
            {
                Label3.Text = "Invalid user name or password";
            }
            con.Close();

        }
        public static string MyEncryption(string password)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA");
            byte[] password2 = null;
            password2 = System.Text.Encoding.UTF8.GetBytes(password);
            password2 = algorithm.ComputeHash(password2);
            return Convert.ToBase64String(password2);
        }
    }
}