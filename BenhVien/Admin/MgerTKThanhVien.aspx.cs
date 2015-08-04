using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerTKThanhVien : System.Web.UI.Page
{
    public String moduleID { get; set; }
    #region Load du lieu
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
        if (!IsPostBack)
        {
            string moduleID = Request.QueryString["moduleID"] ?? "14";
            lbModuleID.Text = moduleID;
            this.moduleID = moduleID;
        }

        if (KiemTraSession() == 1)
        {
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        int howManyPages = 0;
        string menuID = Request.QueryString["MenuID"] ?? "";
        string moduleID = Request.QueryString["moduleID"] ?? "14";
        string chuoiTimKiem = Request.QueryString["Search"] ?? "";
        //string TrangThai = Request.QueryString["Status"] ?? "";
        string Trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";

        if (chuoiTimKiem != "")
        {
            Label1.Text = "Kết quả tìm kiếm tin tức cho chuỗi '" + chuoiTimKiem + "'";
            txtTimKiem.Text = chuoiTimKiem.ToString();
            repProd.DataSource = ThanhVien.Tim(chuoiTimKiem, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.EditThanhVienToSreach(chuoiTimKiem);
            pagerUrl = DataAccess.Connect.Link.EditThanhVienToSreach(chuoiTimKiem, "{0}");
        }
        else
        {
            Label1.Text = "Danh sách thành viên";
            repProd.DataSource = ThanhVien.LayTatCa_PhanTrang(Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerTKThanhVien("1");
            pagerUrl = DataAccess.Connect.Link.MgerTKThanhVien("1", "{0}");
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }

    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        btnTimKiem.Click += new EventHandler(btnTimKiem_Click);
    }
    void btnDelete_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                ThanhVien.Xoa(id);
                CapNhatHanhDong("Xóa thành viên(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    void btnTimKiem_Click(object sender, EventArgs e)
    {
        string chuoiTimKiem = txtTimKiem.Text.Trim();
        string moduleID = Request.QueryString["moduleID"] ?? "";
        if (chuoiTimKiem != "")
        {
            CapNhatHanhDong("Tìm kiếm thành viên(chuổi tìm kiếm: " + chuoiTimKiem + ")");
            Response.Redirect("MgerTKThanhVien.aspx?Search=" + chuoiTimKiem);
        }
    }


    public string ShowInfo(object sender, string column)
    {
        ThanhVien tv = sender as ThanhVien;
        switch (column)
        {
            case "chinhsua":
                if (tv.IDNguoiDung != 1)
                    return String.Format("<a href='EditThanhVien.aspx?ID={0}' class='lnk'><i class='icon-pencil'></i></a>", tv.IDNguoiDung);
                else return "";
            case "checkbox":
                if (tv.IDNguoiDung != 1)
                    return String.Format("<input type='checkbox' name='cid' value='{0}' />", tv.IDNguoiDung);
                else return "";
            default:
                return "";
        }
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