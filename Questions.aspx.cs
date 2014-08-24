using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASP;
using System.Web.Profile;
using System.Web.SessionState;

public partial class Questions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.ToLower().Equals("55.41") && (this.RadioButtonList1.SelectedIndex == 0))
        {
            base.Response.Redirect("Experiment is starting.aspx");
        }
        else
        {
            Alert.Show("Wrong answers, please try again based on the above screenshot.");
        }
    }

    /*protected global_asax ApplicationInstance
    {
        get
        {
            return (global_asax) this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile) this.Context.Profile;
        }
    }*/

}