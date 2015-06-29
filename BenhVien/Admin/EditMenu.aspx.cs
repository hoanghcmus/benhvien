using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_EditMenu : System.Web.UI.Page
{
    #region Load du lieu len web
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "2")
                kq = 1;
        }
        return kq;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            if (!IsPostBack)
            {
                LoadMenu();
                LoadModule();
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        try
        {
            string id = Request.QueryString["ID"] ?? "";
            //new co QueryString cid=> cap nhat Article
            if (id != "")
            {
                TheLoai data = TheLoai.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerMenu.aspx");
                lbtitle.Text = "Cập nhật thể loại";
                SetData(data);
            }
            else
                lbtitle.Text = "Thêm thể loại mới";
        }
        catch (Exception)
        {
        }
    }
    private void LoadMenu()
    {
        ddlLoadMenu.DataValueField = "ID";
        ddlLoadMenu.DataTextField = "TenLoai";
        ddlLoadMenu.DataSource = LoaiMenu.LayTatCa();
        ddlLoadMenu.DataBind();
    }
    private void LoadParent(string loaimenu)
    {
        ddlParent.DataValueField = "ID";
        ddlParent.DataTextField = "TieuDe_Vn";
        ddlParent.DataSource = TheLoai.LayTheoLoaiMenuVaParentIsNull(loaimenu);
        ddlParent.DataBind();
    }
    private void LoadModule()
    {
        ddlModule.DataValueField = "ID";
        ddlModule.DataTextField = "TenLoai";
        ddlModule.DataSource = Module.LayTatCa();
        ddlModule.DataBind();
    }
    private void SetData(TheLoai data)
    {
        LoadParent(data.IDLoaiMenu.ToString());
        lblId.Text = data.ID.ToString();
        txtTieuDeVn.Text = data.TieuDe_Vn;
        txtmoTaVn.Text = data.MoTa_Vn;
        txtHinhAnh.Text = data.HinhAnh;
        txtDuongDanVn.Text = data.DuongDan_Vn;
        if (data.ViTri < 0)
            txtViTri.Text = "0";
        txtViTri.Text = data.ViTri.ToString();
        ddlParent.SelectedValue = data.IDParent.ToString();
        ddlLoadMenu.SelectedValue = data.IDLoaiMenu.ToString();
        ddlModule.SelectedValue = data.IDModule.ToString();
        if (data.Footer == true)
            ckbFooter.Checked = true;
    }
    #endregion

    #region Xu ly xu kien
    private void ResetForm()
    {
        txtTieuDeVn.Text = "";
        txtmoTaVn.Text = "";
        txtHinhAnh.Text = "";
        txtDuongDanVn.Text = "";
        ckbFooter.Checked = false;
    }
    private TheLoai GetData()
    {
        TheLoai data = null;
        if (lblId.Text != "")
            data = TheLoai.LayTheoID(lblId.Text);//cap nhat voi thong tin cu
        else
            data = new TheLoai();//them moi
        data.TieuDe_Vn = txtTieuDeVn.Text;
        data.MoTa_Vn = txtmoTaVn.Text;
        data.HinhAnh = txtHinhAnh.Text;
        data.DuongDan_Vn = txtDuongDanVn.Text;
        data.ViTri = ConvertType.ToInt32(txtViTri.Text.Trim());
        data.IDLoaiMenu = ConvertType.ToInt32(ddlLoadMenu.SelectedValue.Trim());
        data.IDModule = ConvertType.ToInt32(ddlModule.SelectedValue.Trim());
        data.IDParent = ConvertType.ToInt32(ddlParent.SelectedValue.Trim());
        if (ckbFooter.Checked)
            data.Footer = true;
        else
            data.Footer = false;
        return data;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        TheLoai data = GetData();
        int idparent = ConvertType.ToInt32(ddlParent.SelectedValue.Trim());
        int rst = 0;
        if (data.ID > 0)
        {
            if (idparent > 0)
                rst = TheLoai.SuaYesParent(data);
            else
                rst = TheLoai.SuaNoParent(data);
            if (rst>0)
            {
                CapNhatHanhDong("Cập nhật thể loại (id: " + rst + ")");
                Label1.Text = "Cập nhật thể loại thành công!";
            }
            else
                Label1.Text = "Cập nhật thể loại thất bại!";
        }
        else
        {
            if (idparent > 0)
                rst = TheLoai.ThemYesIDParent(data);
            else
                rst = TheLoai.ThemNoIDParent(data);
            if (rst>0)
            {
                CapNhatHanhDong("Thêm thể loại (id: " + rst + ")");
                Label1.Text = "Thêm thể loại thành công!";
                ResetForm();
            }
            else
                Label1.Text = "Thêm thể loại thất bại!";
        }
    }
    protected void ddlLoadMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idLoaiMenu = ddlLoadMenu.SelectedValue;
        if (idLoaiMenu.CompareTo("0") != 0)
        {
            ddlParent.Items.Clear();
            ddlParent.Items.Add(new ListItem("--- Chọn menu cấp cha ---", "0"));
            ddlParent.DataValueField = "ID";
            ddlParent.DataTextField = "TieuDe_Vn";
            ddlParent.DataSource = TheLoai.LayTheoLoaiMenuVaParentIsNull(idLoaiMenu);
            ddlParent.DataBind();
        }
    }
    protected void valTieuDeVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 50)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valmotaVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 150)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void valDuongDanVn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length > 200)
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