using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_EditThanhVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["ID"] ?? "-1";
            ThanhVien tv = ThanhVien.LayThongTinDangNhap(id);
            if (tv != null && tv.IDNguoiDung > 0)
            {
                SetData(tv);
            }
        }
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        ThanhVien tv = GetData();
        if (tv.IDNguoiDung > 0)
        {
            if (ThanhVien.Sua(tv))
            {
                Label1.Text = "<h6 style='color:blue;' class='tvlink'>Đã cập nhật thông tin thành viên</h6>";
                MKC.Text = tv.MatKhau;
            }
            else
            {
                Label1.Text = "<h6 style='color:red;' class='tvlink'>Có lỗi xảy ra!</h6>";
            }
        }
        else
        {
            if (ThanhVien.Them(tv) > 0)
            {
                Label1.Text = "<h6 style='color:blue;' class='tvlink'>Đã thêm thành viên mới</h6>";
                ResetForm();
            }
            else
            {
                Label1.Text = "<h6 style='color:red;' class='tvlink'>Có lỗi xảy ra!</h6>";
            }
        }

    }

    protected void ResetForm()
    {
        txtTenDangNhap.Text = string.Empty;
        txtTenThanhVien.Text = string.Empty;
        txtNgaySinh.Text = string.Empty;
        txtDiaChi.Text = string.Empty;
        txtSoDienThoai.Text = string.Empty;
        txtMatKhauMoi.Text = string.Empty;

        MKC.Text = string.Empty;
    }
    protected void SetData(ThanhVien tv)
    {
        txtTenDangNhap.Text = tv.TenDangNhap;
        txtTenThanhVien.Text = tv.TenNguoiDung;
        txtNgaySinh.Text = tv.NgaySinh;
        txtDiaChi.Text = tv.DiaChi;
        txtSoDienThoai.Text = tv.SoDT;
        txtMatKhauMoi.Text = string.Empty;
        txtChucVu.Text = tv.ChucVu;

        MKC.Text = tv.MatKhau;
        lblId.Text = tv.IDNguoiDung.ToString();
    }

    protected ThanhVien GetData()
    {
        ThanhVien tv = null;
        if (!lblId.Text.Equals(""))
            tv = ThanhVien.LayThongTinDangNhap(lblId.Text.Trim());
        else
            tv = new ThanhVien();

        if (!txtMatKhauMoi.Text.Trim().Equals(""))
            tv.MatKhau = txtMatKhauMoi.Text.Trim();
        else
            tv.MatKhau = MKC.Text.Trim();

        tv.TenDangNhap = txtTenDangNhap.Text.Trim();
        tv.TenNguoiDung = txtTenThanhVien.Text.Trim();
        tv.DiaChi = txtDiaChi.Text.Trim();
        tv.NgaySinh = txtNgaySinh.Text.Trim();
        tv.SoDT = txtSoDienThoai.Text.Trim();
        tv.ChucVu = txtChucVu.Text.Trim();
        return tv;
    }
}