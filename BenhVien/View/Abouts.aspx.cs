using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.StringUtil;
using DataAccess.Help;

public partial class View_Abouts : System.Web.UI.Page
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


        List<BaiViet> listBV = BaiViet.LayTheoIDTheLoaiTop10_ExceptID(baiViet.IDTheLoai.ToString(), baiViet.ID.ToString());
        if (listBV != null && listBV.Count != 0)
        {
            rptBaiVietLienQuan.DataSource = listBV;
            rptBaiVietLienQuan.DataBind();
            bvlq.Visible = true;
        }
        else
        {
            bvlq.Visible = false;
        }
    }


    protected void rptBaiViet_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal ltChiTietBaiViet = (Literal)e.Item.FindControl("ltChiTietBaiViet");
        BaiViet item = (BaiViet)e.Item.DataItem;
        if (item != null)
        {
            ltChiTietBaiViet.Text = item.ChiTiet_Vn;
        }
        if (e.Item.ItemIndex == 0)
        {
            ltrTieuDeLon.Text = item.TenTheLoai_Vn;
        }
    }

    protected string ShowArticleCat(object sender, string column)
    {
        BaiViet baiviet = sender as BaiViet;

        switch (column)
        {
            case "laytomtat":
                if (baiviet.TomTat_Vn.Length > 100)
                {
                    return StringUltility.GetStringByLenght(baiviet.TomTat_Vn, 100) + "...";
                }
                else
                {
                    return baiviet.TomTat_Vn + "...";
                }

            case "ArticleCatDuongDan":
                return "/" + baiviet.IDTheLoai + "/bai-viet/" + Helper.RejectMarks(baiviet.TieuDe_Vn) + "-" + baiviet.ID + ".html";
            case "ArticleCatTieuDe":
                return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); ;

            default: return "";
        }
    }
}