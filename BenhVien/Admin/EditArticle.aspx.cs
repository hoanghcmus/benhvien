﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_EditArticle : System.Web.UI.Page
{
    #region Load du lieu len web
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "2" || item.ToString() == "3" || item.ToString() == "4")
                kq = 1;
        }
        return kq;
    }
    protected void LoadEditor()
    {
        //Load CKFinder vao CKEditor
        txtckeditorVn.Language = "vi";
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "ckfinder";
        _FileBrowser.SetupCKEditor(txtckeditorVn);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            LoadEditor();
            if (!IsPostBack)
            {
                //Load du lieu form
                LoadTheLoai();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void LoadLoaiMenu()
    {
        ddlLoaiMenu.DataValueField = "ID";
        ddlLoaiMenu.DataTextField = "TieuDe_Vn";
        ddlLoaiMenu.DataSource = TheLoai.LayTheoModule_ExceptID();
        ddlLoaiMenu.DataBind();



    }

    private void LoadTheLoai()
    {
        ddlLoaiMenu.Items.Clear();
        ddlLoaiMenu.Items.Add(new ListItem("-- Chọn thể loại bài viết cần thêm --", "0"));
        List<TheLoai> list = TheLoai.LayTheoModule_ExceptID();
        foreach (var item in list)
        {
            ddlLoaiMenu.Items.Add(new ListItem("* " + item.TieuDe_Vn, item.ID.ToString()));
            List<TheLoai> tl = TheLoai.LayTheoIDParent(item.ID.ToString());
            foreach (var itemtl in tl)
            {
                ddlLoaiMenu.Items.Add(new ListItem("--- " + itemtl.TieuDe_Vn, itemtl.ID.ToString()));
            }
        }
    }

    private void PopulateControls()
    {
        try
        {
            string id = Request.QueryString["ID"] ?? "";
            //new co QueryString cid=> cap nhat Article
            if (id != "")
            {
                //lay Khao sat theo gia tri id
                BaiViet data = BaiViet.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerArticle.aspx?TrangThai=0");
                //Dat ten trang web
                lbTitle01.Text = "Cập nhật bài viết";
                lbTitle02.Text = "Cập nhật bài viết '" + id + "'";
                SetData(data);
            }
            else
            {
                lbTitle01.Text = "Thêm bài viết mới";
                lbTitle02.Text = "Thêm bài viết mới";
            }
        }
        catch (Exception)
        {
        }
    }
    #endregion

    #region Luu Bai Viet
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }
    public int KiemTraDieuKien()
    {
        int kq;
        if (Page.IsValid)
        {
            if (txtckeditorVn.Text == "")
            {
                Label1.Text = "Chưa nhập nội dung bài viết!";
                kq = 0;
            }
            else
                kq = 1;
            return kq;
        }
        else
            return kq = 0;
    }
    private void ResetForm()
    {
        txtTieuDeVn.Text = "";
        txtTomTatVn.Text = "";
        txtHinhAnh.Text = "";
        txtckeditorVn.Text = "";
        //ckbTrangChu.Checked = false;
    }
    private void SetData(BaiViet data)
    {
        lblId.Text = data.ID.ToString();
        txtTieuDeVn.Text = data.TieuDe_Vn;
        txtTomTatVn.Text = data.TomTat_Vn;
        txtHinhAnh.Text = data.HinhAnh;
        txtckeditorVn.Text = data.ChiTiet_Vn;
        ddlLoaiMenu.SelectedValue = data.IDTheLoai.ToString();
        //if (data.TrangChu == true)
        //    ckbTrangChu.Checked = true;
    }
    private BaiViet GetData()
    {
        BaiViet data = null;
        if (lblId.Text != "")
        {
            //lay thong tin cu tu Database de cap nhat
            data = BaiViet.LayTheoID(lblId.Text);
            //cap nhat lai thoi gian chinh sua
            data.NgayCapNhat = DateTime.Now.ToShortDateString();
            //cap nhat nguoi chinh sua(use hien tai)
            data.NguoiCapNhat = Session["TenDangNhap"].ToString();
        }
        else
        {
            data = new BaiViet();//them moi
            data.NgayTao = DateTime.Now.ToShortDateString();
            data.NguoiTao = Session["TenDangNhap"].ToString();
        }
        data.TieuDe_Vn = txtTieuDeVn.Text;
        data.TomTat_Vn = txtTomTatVn.Text;
        data.HinhAnh = txtHinhAnh.Text; ;
        data.ChiTiet_Vn = txtckeditorVn.Text;
        //if (ckbTrangChu.Checked)
        //    data.TrangChu = true;
        //else
        //    data.TrangChu = false;
        data.TrangThai = 1;
        data.IDTheLoai = ConvertType.ToInt32(ddlLoaiMenu.SelectedValue.Trim());
        return data;
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        //neu tat ca du lieu duoc nhap la hop le
        if (KiemTraDieuKien() == 1)
        {
            bool rs = false;
            //lay du lieu tu form
            BaiViet data = GetData();
            //ID>0 ==> cap nhat va hien thong bao
            if (data.ID > 0)
            {
                rs = BaiViet.Sua(data);
                Label1.Text = rs ? "Cập nhật bài viết thành công!" : "Cập nhật bài viết thất bại!";
                if (rs)
                {
                    //lay du lieu moi nhat Db
                    data = BaiViet.LayTheoID(lblId.Text);
                    SetData(data);
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Cập nhật bài viết (id: " + lblId.Text + ")");
                }
            }
            else
            {
                int rst = BaiViet.Them(data);
                if (rst > 0)
                {
                    //Cap nhat hanh dong dang nhap
                    CapNhatHanhDong("Thêm bài viết (id: " + rst + ")");
                    //Thong bao them thanh cong
                    Label1.Text = "Thêm bài viết thành công!";
                    ResetForm();
                }
                else
                {
                    Label1.Text = "Thêm bài viết thất bại!";
                }
            }
        }
    }
    protected void valTieuDeVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 100)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valTomTatVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 300)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    #endregion

    #region Cap nhat hanh dong
    private void CapNhatHanhDong(string hanhDong)
    {
        if (Session["IDNguoiDung"] != "" || Session["IDDangNhap"] != "")
        {
            string maDangNhap = Session["IDDangNhap"].ToString();
            string maNguoiDung = Session["IDNguoiDung"].ToString();
            string hanhDongDangNhap = Session["HanhDongDangNhap"].ToString();
            hanhDongDangNhap += "<br /> - " + hanhDong + " (giờ: " + DateTime.Now.ToShortTimeString() + ")";
            Session["HanhDongDangNhap"] = hanhDongDangNhap;
            DangNhap.SuaHanhDong(maDangNhap, maNguoiDung, hanhDongDangNhap);
        }
    }
    #endregion
}