using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication1.CharPanel
{
    public partial class ManChar : System.Web.UI.Page
    {
        private float maxcp = 0 ;
        private float curcp = 0;
        private float maxhp = 0;
        private float curhp = 0;
        private float maxmp = 0;
        private float curmp = 0;
        private int race = 0;
        private int sex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                    Response.Redirect("Login.aspx");
                else
                {

                    String temp = Session["username"].ToString();
                    DataTable dt = new DataTable();

                    MySqlConnection connection = new MySqlConnection("Database=gameserver_beta;Data Source=localhost;User Id=root;Password=admin");
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT char_name FROM characters WHERE account_name=@flag AND online=0";
                    command.Parameters.AddWithValue("@flag", temp);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dt.Columns.Add(reader.GetString(0));
                    }

                    if (dt.Columns.Count > 0)
                    {
                        DropDownList1.DataSource = dt.Columns;
                        DropDownList1.DataBind();
                        Label1.Text = "Choose which characters you want to edit<br>";
                    }
                    else
                    {
                        DropDownList1.Visible = false;
                        Label1.Text = "There are no characters in your account!";
                    }
                    reader.Close();
                    connection.Close();
                }
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            String temp = DropDownList1.SelectedValue;
            DataTable dt = new DataTable();
            MySqlConnection connection = new MySqlConnection("Database=gameserver_beta;Data Source=localhost;User Id=root;Password=admin");
            connection.Open();
            String cmd = "SELECT * FROM characters WHERE char_name=@flag";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd, connection);
            da.SelectCommand.Parameters.AddWithValue("@flag",temp);
            da.Fill(dt);
            DataRow[] rows = dt.Select();
            maxcp = Convert.ToSingle(rows[0]["maxCP"]);
            curcp = Convert.ToSingle(rows[0]["curCP"]);
            maxhp = Convert.ToSingle(rows[0]["maxHP"]);
            curhp = Convert.ToSingle(rows[0]["curHP"]);
            maxmp = Convert.ToSingle(rows[0]["maxMP"]);
            curmp = Convert.ToSingle(rows[0]["curMP"]);
            race = Convert.ToInt16(rows[0]["race"]);
            sex = Convert.ToInt16(rows[0]["sex"]);
            CharListView.DataSource = dt;
            CharListView.DataBind();
            connection.Close();
        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {
            String temp = DropDownList1.SelectedValue;
            DataTable dt = new DataTable();
            MySqlConnection connection = new MySqlConnection("Database=gameserver_beta;Data Source=localhost;User Id=root;Password=admin");
            connection.Open();
            String cmd = "SELECT * FROM characters WHERE char_name=@flag";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd, connection);
            da.SelectCommand.Parameters.AddWithValue("@flag", temp);
            da.Fill(dt);
            DataRow[] rows = dt.Select();
            maxcp = Convert.ToSingle(rows[0]["maxCP"]);
            curcp = Convert.ToSingle(rows[0]["curCP"]);
            maxhp = Convert.ToSingle(rows[0]["maxHP"]);
            curhp = Convert.ToSingle(rows[0]["curHP"]);
            maxmp = Convert.ToSingle(rows[0]["maxMP"]);
            curmp = Convert.ToSingle(rows[0]["curMP"]);
            race = Convert.ToInt16(rows[0]["race"]);
            sex = Convert.ToInt16(rows[0]["sex"]);
            CharListView.DataSource = dt;
            CharListView.DataBind();
            connection.Close();
        }

        protected void CharListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Panel pnl1 = (Panel)e.Item.FindControl("Panel1");
            Panel pnl2 = (Panel)e.Item.FindControl("Panel2");
            Panel pnl3 = (Panel)e.Item.FindControl("Panel3");
            Image img = (Image)e.Item.FindControl("Image1");
            float x = (1 - (curcp / maxcp)) * 100;
            pnl1.Style.Add("width", x.ToString().Replace(',','.') + "%");
            x = (1 - (curhp / maxhp)) * 100;
            pnl2.Style.Add("width", x.ToString().Replace(',', '.') + "%");
            x = (1 - (curmp / maxmp)) * 100;
            pnl3.Style.Add("width", x.ToString().Replace(',', '.') + "%");


            if (sex == 0)
            {
                switch (race)
                {
                    case 0:
                        img.ImageUrl = "~/Images/Races/Hmale.jpg";
                        break;
                    case 1:
                        img.ImageUrl = "~/Images/Races/Emale.jpg";
                        break;
                    case 2:
                        img.ImageUrl = "~/Images/Races/DEmale.jpg";
                        break;
                    case 3:
                        img.ImageUrl = "~/Images/Races/Omale.jpg";
                        break;
                    case 4:
                        img.ImageUrl = "~/Images/Races/Dmale.jpg";
                        break;
                }
            }
            else
            {
                switch (race)
                {
                    case 0:
                        img.ImageUrl = "~/Images/Races/Hfemale.jpg";
                        break;
                    case 1:
                        img.ImageUrl = "~/Images/Races/Efemale.jpg";
                        break;
                    case 2:
                        img.ImageUrl = "~/Images/Races/DEfemale.jpg";
                        break;
                    case 3:
                        img.ImageUrl = "~/Images/Races/Ofemale.jpg";
                        break;
                    case 4:
                        img.ImageUrl = "~/Images/Races/Dfemale.jpg";
                        break;
                }
            }


        }
    }
}