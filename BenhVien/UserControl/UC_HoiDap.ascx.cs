using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.StringUtil;

public partial class UserControl_UC_HoiDap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptHoiDap.DataSource = HoiDap.LayTatCaTheoTrangThai(1);
            rptHoiDap.DataBind();
        }
    }
    public string Showinfo(object input, string colunmName)
    {
        HoiDap data = input as HoiDap;
        switch (colunmName)
        {
            case "hienthilink":
                return "/hoi-dap/chi-tiet-hoi-dap-" + data.ID.ToString() + ".html";
            default:
                return "";
        }
    }
}