using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EndExp : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        NameValueCollection data = new NameValueCollection();
        data.Add("assignmentId", Session["turkAss"].ToString());
        data.Add("workerId", Session["userId"].ToString());
        data.Add("hitId", Session["hitId"].ToString());
        saveWorkerToDB(new UserInfo((string)this.Session["userId"],(string)this.Session["turkAss"],this.Session["bonus"].ToString()));
        Alert.RedirectAndPOST(this.Page, "https://www.mturk.com/mturk/externalSubmit", data);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.Label1.Text = Convert.ToString(Math.Round((double)this.Session["bonus"], 2));
        }
    }
    public void saveWorkerToDB(UserInfo uInf)
    {
        string str = "VALUES ('" + uInf.userId + "','" + uInf.assId + "','" + uInf.bonus + "')";
        string str2 = "INSERT INTO Bonuses (userID, assID, TotalBonus) " + str;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = str2;
            command.ExecuteNonQuery();
        }
    }
}