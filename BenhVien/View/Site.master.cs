using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class View_Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var dataBaiViet = BaiViet.LayTheoIDTheLoai("13");
            ltLienHe.Text = HttpUtility.HtmlDecode(dataBaiViet.ChiTiet_Vn.ToString());


            BaiViet baiviet = BaiViet.LayTheoID("14");
            if (baiviet != null)
            {
                List<BaiViet> listBaiViet = new List<BaiViet>();
                listBaiViet.Add(baiviet);
                rptBaiVietGioiThieu.DataSource = listBaiViet;
                rptBaiVietGioiThieu.DataBind();
            }

            rptProduct.DataSource = TheLoai.LayTheoIDParent("23");
            rptProduct.DataBind();
        }
    }

    protected string ShowInfo(object sender, string column)
    {
        BaiViet baiviet = sender as BaiViet;
        switch (column)
        {
            case "xemthem":
                return "<a href=\"/1/bai-viet/bai-viet-gioi-thieu-" + baiviet.ID.ToString() + ".html\">Xem thêm ...</a>";
            default: return "";
        }
    }
    protected void rptBaiVietGioiThieu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal ltBaiVietGioiThieu = (Literal)e.Item.FindControl("ltBaiVietGioiThieu");
        BaiViet baiviet = (BaiViet)e.Item.DataItem;
        ltBaiVietGioiThieu.Text = baiviet.TomTat_Vn;
    }
}
