using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;

public partial class View_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            captchaImage.ImageUrl = new CaptchaProvider().CreateCaptcha();
            UpdataPageView.UpdataMetagMainTitle(Page, "Liên hệ");
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
                LienHe data = new LienHe();
                data.HoTen = txtHoTen.Text;
                data.Email = txtEmail.Text;
                data.TieuDe = txtTieuDe.Text;
                data.NoiDung = txtNoiDung.Text;
                data.DiaChi = txtDiaChi.Text;
                data.NgayGui = DateTime.Now;
                data.TrangThai = 0;
                data.TheLoai = 1;
                rs = LienHe.Them(data);
                if (rs)
                {
                    succesfull.Visible = true;
                    refesh();
                    succesfull.Text = "Gửi ý kiến thành công!";
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
}