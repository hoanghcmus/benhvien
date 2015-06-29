using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.Text;

public partial class UserControl_MenuTop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BuildMenus();
    }
    protected void BuildMenus()
    {
        List<TheLoai> menuItems = TheLoai.LayTheoLoaiMenuVaParentIsNull("1");
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul>");
        sb.Append("<li > <a href=\"/trang-chu.html\">TRANG CHỦ</a></li>");
        foreach (TheLoai item in menuItems)
        {
           
            List<TheLoai> childItems = TheLoai.LayTheoIDParent(item.ID.ToString());
            if (childItems.Count > 0)
            {
                sb.Append("<li class=\"has-sub\" >");
                sb.Append("<a href=" + item.DuongDan_Vn + ">" + item.TieuDe_Vn + "</a>");                
                BuildMenusItem(ref sb, childItems);
            }
            else
            {
                sb.Append("<li  >");
                sb.Append("<a href=" + item.DuongDan_Vn + ">" + item.TieuDe_Vn + "</a>");
            }
            sb.Append("</li>");
        }
        sb.Append("</ul>");
        ltrMenuTop.Text = sb.ToString();
    }
    protected void BuildMenusItem(ref StringBuilder sb, List<TheLoai> menuItems)
    {
        sb.Append("<ul >");
        foreach (TheLoai item in menuItems)
        {
            sb.Append("<li >");
            List<TheLoai> childItems = TheLoai.LayTheoIDParent(item.ID.ToString());
            if (childItems.Count > 0)
            {
                sb.Append("<a href=\"#\">" + item.TieuDe_Vn + " </a>");
                BuildMenusItem(ref sb, childItems);
            }
            else
            {
                sb.Append("<a href=" + item.DuongDan_Vn + ">" + item.TieuDe_Vn + "</a>");
            }
            sb.Append("</li>");
        }
        sb.Append("</ul>");
    }
}