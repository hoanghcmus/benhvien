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
        int howManyPages = 0;
        string trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerFormat = "";
        dlListImg.DataSource = ImageAndClips.LayTheoTheLoai("14", trang, out howManyPages);
        dlListImg.DataBind();
        firstPageUrl = Link.Photos();
        pagerFormat = Link.Photos("{0}");
        pagerBottom.Show(int.Parse(trang), howManyPages, firstPageUrl, pagerFormat, true);
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
}