using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;

public partial class View_Videos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }
    private void PopulateControls()
    {
        UpdataPageView.UpdataMetagMainTitle(Page, "Video-Clips");
    }

    protected void ListPager_PreRender(object sender, EventArgs e)
    {
        string IDTheLoai = Request.QueryString["catID"] ?? "0";
        List<ImageAndClips> listBV = ImageAndClips.LayTheoTheLoaiNoPaging(IDTheLoai);

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
}