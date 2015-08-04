using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;
using DataAccess.StringUtil;

public partial class En_ArticleByCatgory : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void ListPager_PreRender(object sender, EventArgs e)
    {

        string IDTheLoai = Request.QueryString["catID"] ?? "0";
        List<BaiViet> listBV = BaiViet.LayTheoIDTheLoai_List(IDTheLoai);

        if (listBV != null && listBV.Count != 0)
        {
            rptArticleList.DataSource = listBV;
            rptArticleList.DataBind();

            ltrCtTitle.Text = listBV.First().TenTheLoai_Vn;
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
                return "/" + baiviet.IDTheLoai + "/bai-viet/" + Helper.RejectMarks(baiviet.TieuDe_Vn) + "-" + baiviet.ID + ".html";
            case "ArticleCatTieuDe":
                return HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()); ;

            default: return "";
        }
    }
    protected string ShowArticleCat1(BaiViet baiviet, string column)
    {
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
                return baiviet.TieuDe_Vn;

            default: return "";
        }
    }
    protected void rptArticleList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var curentIndex = 0;
        var CurrentItem = new BaiViet();
        var ltrItemBV = e.Item.FindControl("ltrItemBV") as Literal;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            CurrentItem = (BaiViet)dataItem.DataItem;
            curentIndex = dataItem.DataItemIndex;

            if (curentIndex < 4)
            {
                if (curentIndex == 0)
                    ltrItemBV.Text = "<div class='line-fix-parent-width mb15'>" + showItem(CurrentItem, 2);
                else if (curentIndex == 3)
                    ltrItemBV.Text = showItem(CurrentItem, 2) + "</div>";
                else
                    ltrItemBV.Text = showItem(CurrentItem, 2);
            }
            else
                ltrItemBV.Text = showItem(CurrentItem, 1);
        }
    }
    protected string showItem(BaiViet bv, int th)
    {
        switch (th)
        {
            case 1:
                return
                    "<div class='item-bai-viet'>"
                                + "<div class='duong-dan-bai-viet'>"
                                    + "<a href='" + ShowArticleCat1(bv, "ArticleCatDuongDan") + "' class='link'>"
                                        + "<img src='" + bv.HinhAnh + "' alt='Hình ảnh' class='img' />"
                                        + "</a>"
                                + "</div>"
                                + "<div class='tieu-de-bai-viet'>"
                                    + "<a href='" + ShowArticleCat1(bv, "ArticleCatDuongDan") + "'>"
                                        + ShowArticleCat1(bv, "ArticleCatTieuDe") + "</a>"
                                    + "</h4>"
                                + "<p class='meta'>"
                                    + ShowArticleCat1(bv, "laytomtat")
                                + "</p>"

                                + "</div></div>";

            case 2:
                return "<div class='item-doc1'>"
                                        + "<div class='item-doc-figure h180'>"
                                         + "<a href='" + ShowArticleCat1(bv, "ArticleCatDuongDan") + "' class='link'>"
                                            + "<img src='" + bv.HinhAnh + "' alt='Hinh anh' class='img' />"
                                            + "</a>"
                                        + "</div>"
                                        + "<div class='item-doc-tieu-de'>"
                                            + "<h1><a href='" + ShowArticleCat1(bv, "ArticleCatDuongDan") + "' class='link'>"
                                        + ShowArticleCat1(bv, "ArticleCatTieuDe") + "</a></h1>"
                                       + "</div>"
                                        + "<div class='item-doc-mo-ta'>"
                                            + "<p>"
                                                 + ShowArticleCat1(bv, "laytomtat")
                                            + "</p>"
                                        + "</div>"
                                    + "</div>";
            default: return "";
        }
    }
}