using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_UC_DangNhapThanhVien : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["thanhvien"]) == 1)
            {
                ltrTrangThanhVien.Text = "<a href='/thong-tin-chung.html' class='tvlink'>Trang thành viên</a>";
                SetVisibleForInOutButton(1);
            }
            else
            {
                ltrTrangThanhVien.Text = String.Empty;
                SetVisibleForInOutButton(0);
            }


        }
    }
    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        string user = txtTenNguoiDung.Text.Trim();
        string pass = txtMatKhau.Text.Trim();
        ThanhVien tv = ThanhVien.KiemTraDangNhap(user, pass);
        if (tv != null)
        {
            Session["idthanhvien"] = tv.IDNguoiDung;
            Session["thanhvien"] = 1;
            Session["tenthanhvien"] = tv.TenNguoiDung;            
            Session["uID"] = tv.IDNguoiDung;
            Response.Redirect("/thong-tin-chung.html");
        }
        else
        {
            ltrTrangThanhVien.Text = "<span style='color:red;' class='tvlink'>Thông tin đăng nhập sai</span>";
        }
    }
    protected void btnDangXuat_Click(object sender, EventArgs e)
    {
        Session["idthanhvien"] = "";
        Session["thanhvien"] = 0;
        Session["tenthanhvien"] = "";
        Session["uID"] = "";
        Response.Redirect("/trang-chu.html");
    }
    protected void SetVisibleForInOutButton(int th)
    {
        switch (th)
        {
            case 1:
                btnDangXuat.Visible = true;
                btnDangNhap.Visible = false;
                break;
            default:
                btnDangXuat.Visible = false;
                btnDangNhap.Visible = true;
                break;
        }
    }
}