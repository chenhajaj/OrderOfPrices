using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NoNextProd : System.Web.UI.Page
{
    

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Session["Procced"] = 1;
        this.Button1.Visible = false;
        Response.Redirect("Experiment.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}