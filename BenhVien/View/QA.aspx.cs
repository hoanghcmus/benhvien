using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using DataAccess.StringUtil;

public partial class View_QA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            captchaImage.ImageUrl = new CaptchaProvider().CreateCaptcha();
            UpdataPageView.UpdataMetagMainTitle(Page, "Hỏi đáp");


            int howManyPages = 0;
            string tinhTrang = "1";
            string firstPageUrl = "";
            string pagerFormat = "";
            string Trang = Request.QueryString["Page"] ?? "1";
            List<HoiDap> listHoiDap = HoiDap.LayTheoTrangThai(tinhTrang, Trang, out howManyPages);

            if (listHoiDap != null)
            {
                rptHoiDap.DataSource = listHoiDap;
                rptHoiDap.DataBind();

                firstPageUrl = DataAccess.Connect.Link.HoiDap(tinhTrang);
                pagerFormat = DataAccess.Connect.Link.HoiDap(tinhTrang, "{0}");
            }


            pagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerFormat, true);
        }
    }
    protected void refesh()
    {
        txtDiaChi.Text = "";
        txtHoTen.Text = "";
        txtEmail.Text = "";
        txtTieuDe.Text = "";
        txtNoiDung.Text = "";
        txtInputString.Text = "";
    }
    protected void btnbtnGui_Click(object sender, EventArgs e)
    {
        // Neu tat ca du lieu deu duoc nhap hop le 
        if (Page.IsValid)
        {
            CaptchaProvider captchaPro = new CaptchaProvider();
            if (captchaPro.IsValidCode(txtInputString.Text))
            {
                lbcapcha.Visible = false;
                bool rs = false;


                HoiDap data = new HoiDap();
                data.HoTen = txtHoTen.Text;
                data.Email = txtEmail.Text;
                data.TieuDe = txtTieuDe.Text;
                data.NoiDungHoi = txtNoiDung.Text;
                data.NoiDungDap = "";
                data.DiaChi = txtDiaChi.Text;
                data.NgayGui = DateTime.Now;
                data.TrangThai = 0;

                rs = HoiDap.Them(data);
                if (rs)
                {
                    succesfull.Visible = true;
                    refesh();
                    succesfull.Text = "Nội dung liên hệ của bạn đã được gủi đến Răng sứ No 1. Chúng tôi sẽ trả lời liên hệ của bạn trong thời gian sớm nhất!";
                }
                else
                {
                    succesfull.Visible = true;
                    succesfull.Text = "Gửi ý kiến thất bại!";
                }
            }
            else
            {
                lbcapcha.Visible = true;
                succesfull.Visible = false;
                lbcapcha.Text = "Sai mã xác nhận!";
            }
        }
    }
    protected void btnRedefine_Click(object sender, EventArgs e)
    {
        //Response.Redirect(this.Request.Url.AbsoluteUri);
        captchaImage.ImageUrl = new CaptchaProvider().CreateCaptcha();
    }

    public string Showinfo(object input, string colunmName)
    {
        HoiDap data = input as HoiDap;
        switch (colunmName)
        {
            case "ngaygui":
                return data.NgayGui.ToString().Split(' ').First().ToString();
            case "hienthilink":
                return "/hoi-dap/chi-tiet-hoi-dap-" + data.ID.ToString() + ".html";
            case "laytomtat":
                if (data.NoiDungDap.Length < 300) { return Regex.Replace(data.NoiDungDap, "<img.*?>", ""); }
                else
                {
                    return StringUltility.GetStringByLenght(Regex.Replace(data.NoiDungDap, "<img.*?>", ""), 300) + "...";
                }
            default:
                return "";
        }
    }
}