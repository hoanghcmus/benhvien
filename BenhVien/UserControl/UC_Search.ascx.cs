using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Help;

public partial class UserControl_UC_Search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnTimKiem.Click += btnTimKiem_Click;
    }

    void btnTimKiem_Click(object sender, EventArgs e)
    {
        string chuoiTimKiem = txtTimKiem.Value;
        if (chuoiTimKiem != "")
        {
            Response.Redirect(String.Format("/tim-kiem-{0}.html", chuoiTimKiem.Trim()));
        }
    }
}