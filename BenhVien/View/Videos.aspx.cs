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
        int howManyPages = 0;
        string trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerFormat = "";
        dlVideos.DataSource = ImageAndClips.LayTheoTheLoai("12", trang, out howManyPages);
        dlVideos.DataBind();
        firstPageUrl = Link.Videos();
        pagerFormat = Link.Videos("{0}");
        pagerBottom.Show(int.Parse(trang), howManyPages, firstPageUrl, pagerFormat, true);
    }
}