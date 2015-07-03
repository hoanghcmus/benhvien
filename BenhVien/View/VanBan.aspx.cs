using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_VanBan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void down_Click(object sender, EventArgs e)
    {
        Response.Redirect("/View/DownLoadFile.ashx?fileName=/Design/flg.pdf");
    }
}