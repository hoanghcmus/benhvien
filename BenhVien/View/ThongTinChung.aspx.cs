using DataAccess.Classes;
using DataAccess.Help;
using DataAccess.StringUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ThongTinChung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListPager_PreRender(object sender, EventArgs e)
    {

        string IDTheLoai = Request.QueryString["catID"] ?? "0";
        List<BaiViet> listBV = BaiViet.LayTheoModuleAll("13");

        if (listBV != null && listBV.Count != 0)
        {
            rptArticleList.DataSource = listBV;
            rptArticleList.DataBind();
        }
    }

    protected void rptArticleList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
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
                return "/1/bai-viet-tv/" + Helper.RejectMarks(baiviet.TieuDe_Vn) + "-" + baiviet.ID + ".html";
            case "ArticleCatTieuDe":
                return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); ;

            default: return "";
        }
    }
}