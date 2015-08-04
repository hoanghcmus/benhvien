using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;


public partial class View_ChitTietVanBan : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string IdBaiViet = Request.QueryString["ID"] ?? "-1";
        if (IdBaiViet != "-1") { BaiViet.SuaLuotXemTangLen1(IdBaiViet); }

        BaiViet baiViet = BaiViet.LayTheoID(IdBaiViet);
        List<BaiViet> listBaiViet = new List<BaiViet>();
        listBaiViet.Add(baiViet);
        rptBaiViet.DataSource = listBaiViet;
        rptBaiViet.DataBind();
    }


    protected void rptBaiViet_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal ltChiTietBaiViet = (Literal)e.Item.FindControl("ltChiTietBaiViet");
        BaiViet item = (BaiViet)e.Item.DataItem;
        if (item != null)
        {
            ltChiTietBaiViet.Text = item.ChiTiet_Vn;
        }
    }

    protected string ShowInfo(object sender, string column)
    {
        BaiViet baiviet = sender as BaiViet;
        switch (column)
        {
            case "tieudelon":
                string idTheLoai = baiviet.IDTheLoai.ToString();
                TheLoai theLoai = TheLoai.LayTheoID(idTheLoai);
                return theLoai.TieuDe_Vn;
            default: return "";
        }
    }
}