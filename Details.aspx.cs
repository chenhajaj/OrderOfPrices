
using System.Linq;
using System.Web;

using ASP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //save user info to DB
        if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0 || TxtAge.Text == "")
            Alert.Show("Please fill in all the required details");
        else
        {
            string str = string.Concat(new object[] { "VALUES('", (string)this.Session["userId"], "','", (string)this.Session["turkAss"], "','", DropDownList1.Text, "','", TxtAge.Text, "','", DropDownList2.Text, "','", DropDownList3.Text, "')" });
            //string str = "VALUES ('" + this.Session["userId"] + "','" + this.Session["turkAss"] + "','" + DropDownList1.Text + "','" + TxtAge.Text + "','" + DropDownList2.Text + "','" + DropDownList3.Text + "')";
            string str2 = "INSERT INTO usersTable(userID, assID, Gender, Age, Education, Nationality) " + str;
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ToString()))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = str2;
                command.ExecuteNonQuery();
            }
            Response.Redirect("EndExp.aspx");
            
        }
    }
}