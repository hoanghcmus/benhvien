using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class View_TaiKhoan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string idThanhVien = "-1";
            if (Session["idthanhvien"] != null && !Session["idthanhvien"].ToString().Equals(""))
            {
                idThanhVien = Session["idthanhvien"].ToString();
                SetData(ThanhVien.LayThongTinDangNhap(idThanhVien));
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (!txtXacNhanMatKhauMoi.Text.Trim().Equals(""))
        {
            if (!txtMatKhauCu.Text.Trim().Equals(MKC.Text.Trim()))
            {
                ltrMess.Text = "<h1 style='color:red;' class='tvlink'>Nhập mật khẩu cũ sai</h1>";
                return;
            }
        }

        ThanhVien tv = GetData();
        if (tv.IDNguoiDung > 0)
        {
            if (ThanhVien.Sua(tv))
            {
                ltrMess.Text = "<h1 style='color:blue;' class='tvlink'>Đã cập nhật thông tin người dùng</h1>";
                MKC.Text = tv.MatKhau;
            }
            else
            {
                ltrMess.Text = "<h1 style='color:red;' class='tvlink'>Có lỗi xảy ra!</h1>";
            }
        }

    }

    protected void SetData(ThanhVien tv)
    {
        txtTenDangNhap.Text = tv.TenDangNhap;
        txtTenThanhVien.Text = tv.TenNguoiDung;
        txtNgaySinh.Text = tv.NgaySinh;
        txtDiaChi.Text = tv.DiaChi;
        txtSoDienThoai.Text = tv.SoDT;

        MKC.Text = tv.MatKhau;
        lbIDNguoiDung.Text = tv.IDNguoiDung.ToString();
    }

    protected ThanhVien GetData()
    {
        ThanhVien tv = null;
        if (!lbIDNguoiDung.Text.Equals(""))
            tv = ThanhVien.LayThongTinDangNhap(lbIDNguoiDung.Text.Trim());
        else
            tv = new ThanhVien();

        if (!txtXacNhanMatKhauMoi.Text.Trim().Equals(""))
            tv.MatKhau = txtXacNhanMatKhauMoi.Text.Trim();
        else
            tv.MatKhau = MKC.Text.Trim();

        tv.TenNguoiDung = txtTenThanhVien.Text.Trim();
        tv.DiaChi = txtDiaChi.Text.Trim();
        tv.NgaySinh = txtNgaySinh.Text.Trim();
        tv.SoDT = txtSoDienThoai.Text.Trim();
        return tv;
    }
}