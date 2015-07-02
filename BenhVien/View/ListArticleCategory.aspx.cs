using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class View_ListArticleCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListPager_PreRender(object sender, EventArgs e)
    {

        string IDTheLoai = Request.QueryString["catID"] ?? "0";

        if (!IsPostBack)
        {
            List<TheLoai> listTheLoai = TheLoai.LayTheoIDParent(IDTheLoai);

            if (listTheLoai != null && listTheLoai.Count > 0)
            {
                rptCatList.DataSource = listTheLoai;
                rptCatList.DataBind();

                TheLoai tlParent = TheLoai.LayTheoID(listTheLoai.First().IDParent.ToString());
                ltrCtTitle.Text = tlParent.TieuDe_Vn;
            }
        }
    }


    protected void rptCatList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
    }
}