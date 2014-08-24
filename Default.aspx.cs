using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASP;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Profile;
using System.Web.SessionState;

public partial class _Default : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e) {
        string id = (string)this.Session["userId"];
        string ass = (string)this.Session["turkAss"];
        UserInfo uInf = new UserInfo(id, ass);
        if (this.isInDB(uInf)) {
            if (id.Equals("friend1")) {
                int[] numArray = new int[5];
                this.Session["Sampling"] = numArray;
                int num = new Random().Next(10);
                new List<int>();
                SessionData UserData = new SessionData();
                UserData.CurrentSetIndex = num % 5;
                Session["SessionData"] = UserData;
                this.Session["Bonus"] = 0;
                Response.Redirect("CSAsite.aspx");
            }
            else {
                Alert.Show("You already participanted in this experiment earlier, please return the hit");
            }
        }
        else {
            //this.saveWorkerToDB(uInf);
            int[] Terminate = new int[5];
            this.Session["Sampling"] = Terminate;
            int startingProduct = new Random().Next(10);
            SessionData UserData = new SessionData();
            UserData.CurrentSetIndex = startingProduct % 5;
            Session["SessionData"] = UserData;
            this.Session["Bonus"] = 0;
            base.Response.Redirect("CSAsite.aspx");
        }
    }

    public bool isInDB(UserInfo uInf) {
        List<UserInfo> list = null;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString()))
        {
            connection.Open();
            string str2 = "SELECT userID, assID FROM usersTable";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = str2;
            SqlDataReader reader = command.ExecuteReader();
            list = new List<UserInfo>();
            while (reader.Read()) {
                list.Add(new UserInfo(Convert.ToString(reader["userID"]), Convert.ToString(reader["assID"])));
            }
        }
        foreach (UserInfo info in list) {
            if (info.userId.Equals(uInf.userId)) {
                return true;
            }
        }
        return false;
    }

    protected void Page_Load(object sender, EventArgs e) {
        this.Session["hitId"] = Request.QueryString["hitId"];
        this.Session["Procced"] = 0;
        this.Session["Cp"] = -1;
        DateTime now = DateTime.Now;
        this.Session["sTime"] = now;
        string str = null;
        str = base.Request.QueryString["assignmentId"];
        if (str == null) {
            Button1.Visible = true;
            Session["userId"] = "friend1";
            Session["turkAss"] = "turkAss";
        }
        else if (str.Equals("ASSIGNMENT_ID_NOT_AVAILABLE")) {
            Button1.Visible = false;
        }
        else {
            Button1.Visible = true;
            Session["userId"] = base.Request.QueryString["workerId"];
            Session["turkAss"] = str;
        }
    }

    public void saveWorkerToDB(UserInfo uInf) {
        string str = "VALUES ('" + uInf.userId + "','" + uInf.assId + "')";
        string str2 = "INSERT INTO usersTable (userID, assID) " + str;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = str2;
            command.ExecuteNonQuery();
        }
    }
}
