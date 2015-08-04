using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_EditVanban : System.Web.UI.Page
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

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["ckfunc"] = "tv";
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
        ddlLoaiMenu.DataSource = TheLoai.LayTheoModule("14");
        ddlLoaiMenu.DataBind();



    }

    private void LoadTheLoai()
    {
        ddlLoaiMenu.Items.Clear();
        ddlLoaiMenu.Items.Add(new ListItem("-- Chọn thể loại văn bản cần thêm --", "0"));
        List<TheLoai> list = TheLoai.LayTheoModule("14");
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
                VanBan data = VanBan.LayTheoID(id);
                if (data == null)
                    Response.Redirect("~/Admin/MgerVanBan.aspx");
                //Dat ten trang web
                lbTitle01.Text = "Cập nhật văn bản";
                lbTitle02.Text = "Cập nhật văn bản '" + id + "'";
                SetData(data);
            }
            else
            {
                lbTitle01.Text = "Thêm văn bản mới";
                lbTitle02.Text = "Thêm văn bản mới";
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

    private void ResetForm()
    {
        txtTieuDeVn.Text = "";
        txtTomTatVn.Text = "";
        txtDuongDan.Text = "";
        txtNgayBanHanh.Text = "";
        txtSoHieu.Text = "";
        //ckbTrangChu.Checked = false;
    }
    private void SetData(VanBan data)
    {
        lblId.Text = data.ID.ToString();
        txtTieuDeVn.Text = data.TenVanBan;
        txtTomTatVn.Text = data.MoTa;
        txtDuongDan.Text = data.DuongDan;
        txtSoHieu.Text = data.SoHieu;
        txtNgayBanHanh.Text = data.NgayBanHanh.ToShortDateString();
        ddlLoaiMenu.SelectedValue = data.IDTheLoai.ToString();
        //if (data.TrangChu == true)
        //    ckbTrangChu.Checked = true;
    }
    private VanBan GetData()
    {
        VanBan data = new VanBan();
        if (lblId.Text != "")
        {
            //lay thong tin cu tu Database de cap nhat
            data = VanBan.LayTheoID(lblId.Text);
        }
        else
        {
            data = new VanBan();//them moi         
        }
        data.SoHieu = txtSoHieu.Text.Trim();
        data.TenVanBan = txtTieuDeVn.Text.Trim();
        data.MoTa = txtTomTatVn.Text.Trim();
        data.DuongDan = txtDuongDan.Text.Trim();
        data.NgayBanHanh = Convert.ToDateTime(txtNgayBanHanh.Text.Trim());
        data.IDTheLoai = ConvertType.ToInt32(ddlLoaiMenu.SelectedValue.Trim());
        return data;
    }
    void btnLuu_Click(object sender, EventArgs e)
    {

        bool rs = false;
        //lay du lieu tu form
        VanBan data = GetData();
        //ID>0 ==> cap nhat va hien thong bao
        if (data.ID > 0)
        {
            rs = VanBan.Sua(data);
            Label1.Text = rs ? "Cập nhật văn bản thành công!" : "Cập nhật văn bản thất bại!";
            if (rs)
            {
                //lay du lieu moi nhat Db
                data = VanBan.LayTheoID(lblId.Text);
                SetData(data);
                //Cap nhat hanh dong dang nhap
                CapNhatHanhDong("Cập nhật văn bản (id: " + lblId.Text + ")");
            }
        }
        else
        {
            int rst = VanBan.Them(data);
            if (rst > 0)
            {
                //Cap nhat hanh dong dang nhap
                CapNhatHanhDong("Thêm văn bản (id: " + rst + ")");
                //Thong bao them thanh cong
                Label1.Text = "Thêm văn bản thành công!";
                ResetForm();
            }
            else
            {
                Label1.Text = "Thêm văn bản thất bại!";
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
    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        txtNgayBanHanh.Text = Calendar.SelectedDate.ToShortDateString();
    }
    protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
    {
        string id = Request.QueryString["ID"] ?? "";
        if (id != "")
        {            
            VanBan data = VanBan.LayTheoID(id);
            if (data != null)
                Calendar.SelectedDate = data.NgayBanHanh;            
        }

    }
}