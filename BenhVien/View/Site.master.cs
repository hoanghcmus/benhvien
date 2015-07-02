using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using Core;

public partial class View_Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var dataBaiViet = BaiViet.LayTheoIDTheLoai("13");
            ltLienHe.Text = HttpUtility.HtmlDecode(dataBaiViet.ChiTiet_Vn.ToString());


            BaiViet baiviet = BaiViet.LayTheoID("14");
            if (baiviet != null)
            {
                List<BaiViet> listBaiViet = new List<BaiViet>();
                listBaiViet.Add(baiviet);
                rptBaiVietGioiThieu.DataSource = listBaiViet;
                rptBaiVietGioiThieu.DataBind();
            }

            rptProduct.DataSource = TheLoai.LayTheoIDParent("23");
            rptProduct.DataBind();

            LoadAlbum();

            if (Convert.ToInt32(Session["thanhvien"]) == 1)
                ltrTrangThanhVien.Text = "<a href='/trang-thanh-vien.html' class='tvlink'>Trang thành viên</a>";
            else ltrTrangThanhVien.Text = String.Empty;

            List<TheLoai> listTL = TheLoai.LayTheoModule("9");
            rptBannerLienKet.DataSource = listTL;
            rptBannerLienKet.DataBind();
        }
    }

    protected string ShowInfo(object sender, string column)
    {
        BaiViet baiviet = sender as BaiViet;
        switch (column)
        {
            case "xemthem":
                return "<a href=\"/1/bai-viet/bai-viet-gioi-thieu-" + baiviet.ID.ToString() + ".html\">Xem thêm ...</a>";
            default: return "";
        }
    }
    protected void rptBaiVietGioiThieu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal ltBaiVietGioiThieu = (Literal)e.Item.FindControl("ltBaiVietGioiThieu");
        BaiViet baiviet = (BaiViet)e.Item.DataItem;
        ltBaiVietGioiThieu.Text = baiviet.TomTat_Vn;
    }

    private void LoadAlbum()
    {
        ImageAndClips data = ImageAndClips.LayTheoID(ImageAndClips.ImageAndClips_GetLastID(14));
        if (data != null)
        {
            List<Img> listimgs = new List<Img>();
            string listimg = data.ImgOrClip;
            string[] str = listimg.Split('\'');

            foreach (var item in str)
            {
                if (item.ToString() != "")
                {
                    Img dataimg = new Img();
                    dataimg.HinhAnh = item.ToString();
                    listimgs.Add(dataimg);
                }
            }

            int j = 1;
            foreach (Img img in listimgs)
            {
                if (j == 1)
                {
                    ltrListImages.Text += "<li>";
                }
                ltrListImages.Text += "<div class='gallery-item'>"
                             + "<a class='highslide imgshow link' rel='main-gallery' href='" + img.HinhAnh + "'>"
                                 + "<img src='" + img.HinhAnh + "' alt='Picture' class='img' />"
                             + "</a>"
                          + "</div>";

                if (j == 2)
                {
                    ltrListImages.Text += "</li>";
                    j = 1;
                    continue;
                }
                j++;

            }
        }
    }

}
