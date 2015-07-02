using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.Configuration;
using System.Web.UI.HtmlControls;
using DataAccess.Connect;

public partial class View_DetailPhoto : System.Web.UI.Page
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
        string id = Request.QueryString["ID"];
        ImageAndClips data = ImageAndClips.LayTheoID(Convert.ToInt32(id));
        if (data != null)
        {
            string img = "";
            int stt = 0;

            Label1.Text = data.Ten_Vn;
            List<Img> listimgs = new List<Img>();
            string listimg = data.ImgOrClip;
            string[] str = listimg.Split('\'');
            foreach (var item in str)
            {
                if (item.ToString() != "")
                {
                    Img dataimg = new Img();
                    if (stt == 0)
                        img = item.ToString();
                    dataimg.HinhAnh = item.ToString();
                    listimgs.Add(dataimg);
                }
                stt++;
            }
            UpdataPageView.UpdataMetagOpenGraph(Page, data.Ten_Vn, data.MoTa_Vn, Link.DetailPhoto(data.Ten_Vn, data.ID.ToString()), img, "Photo");
            dlListimages.DataSource = listimgs;
            dlListimages.DataBind();
        }
    }
}