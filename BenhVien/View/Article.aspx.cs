using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;

public partial class View_Article : System.Web.UI.Page
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
        int howManyPages = 0;
        string theLoaiID = Request.QueryString["IDTheLoai"] ?? "";
        string trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerFormat = "";
        if (theLoaiID != "")
        {
            TheLoai theLoai = TheLoai.LayTheoID(theLoaiID);
            if (theLoai == null)
            {
                lbTitle.Visible = false;
            }
            else
            {
                UpdataPageView.UpdataMetagMainTitle(Page, theLoai.TieuDe_Vn);
                lbTitle.Visible = true;
                lbTitle.Text = theLoai.TieuDe_Vn;
                List<BaiViet> list = BaiViet.LayTheoTheLoai_4item(theLoaiID, trang, out howManyPages);
                if (list == null || list.Count <= 0)
                    lbtl.Visible = true;
                dlProdList.DataSource = list;
                dlProdList.DataBind();
                firstPageUrl = Link.Services(theLoai.TieuDe_Vn, theLoaiID);
                pagerFormat = Link.Services(theLoai.TieuDe_Vn, theLoaiID, "{0}");
            }
        }
        pagerBottom.Show(int.Parse(trang), howManyPages, firstPageUrl, pagerFormat, true);
    }
}