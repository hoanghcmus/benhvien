using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using System.Text;

public partial class View_Photos : System.Web.UI.Page
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
        UpdataPageView.UpdataMetagMainTitle(Page, "Hình ảnh");
    }
    public string ShowImg(object input, string colunmName)
    {
        ImageAndClips data = input as ImageAndClips;
        switch (colunmName)
        {
            case "ImgOrClip":
                StringBuilder sb = new StringBuilder();
                string url01 = "";
                string listimg = data.ImgOrClip;
                string[] str = listimg.Split('\'');
                url01 = str[0].ToString();
                sb.Append(String.Format("<img id=\"photo1\" class=\"stackphotos\"  src='{1}' />", data.ID, url01));
                return sb.ToString();
            default:
                return "";
        }

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