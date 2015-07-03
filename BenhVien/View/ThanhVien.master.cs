using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ThanhVien : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["thanhvien"]) == 0)
            Response.Redirect("/trang-chu.html");
    }
}
