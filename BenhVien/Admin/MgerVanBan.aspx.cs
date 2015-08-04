using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerVanBan : System.Web.UI.Page
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
            if (item.ToString() == "1" || item.ToString() == "2" || item.ToString() == "4")
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
                LoadTheLoai();
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
            repProd.DataSource = VanBan.TimTheoModule(moduleID, chuoiTimKiem, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.EditVanBanToSreach(chuoiTimKiem);
            pagerUrl = DataAccess.Connect.Link.EditVanBanToSreach(chuoiTimKiem, "{0}");
        }
        else if (menuID != "")
        {
            Label1.Text = "Văn bản theo thể loại ID là " + menuID;
            repProd.DataSource = VanBan.LayTheoIDTheLoai(menuID, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.EditVanBanToMenu(menuID);
            pagerUrl = DataAccess.Connect.Link.EditVanBanToMenu(menuID, "{0}");
        }
        else
        {
            Label1.Text = "Danh sách văn bản";
            repProd.DataSource = VanBan.LayTheoModule(moduleID, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerVanBan("1");
            pagerUrl = DataAccess.Connect.Link.MgerVanBan("1", "{0}");
        }
        PagerBottom.Show(int.Parse(Trang), howManyPages, firstPageUrl, pagerUrl, true);
    }
    private void LoadTheLoai()
    {
        ddlTheLoai.DataValueField = "ID";
        ddlTheLoai.DataTextField = "TieuDe_Vn";
        ddlTheLoai.DataSource = TheLoai.LayTheoModule(lbModuleID.Text);
        ddlTheLoai.DataBind();
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
                VanBan.Xoa(id);
                CapNhatHanhDong("Xóa văn bản(id: " + id + ")");
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
            CapNhatHanhDong("Tìm kiếm văn bản(chuổi tìm kiếm: " + chuoiTimKiem + ")");
            Response.Redirect("MgerVanBan.aspx?Search=" + chuoiTimKiem);
        }
    }
    protected void btnDang_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                if (VanBan.SuaTrangThai(id, "1") == true)
                {
                    Label1.Text = "Đăng bài thành công!";
                    CapNhatHanhDong("Đăng văn bản (id: " + id + ")");
                }
            }
            PopulateControls();
        }
    }
    protected void btnCamDang_Click(object sender, EventArgs e)
    {
        string stringid = Request.Form["cid"] ?? "";
        if (stringid != "")
        {
            foreach (string id in stringid.Split(','))
            {
                VanBan.SuaTrangThai(id, "2");
                CapNhatHanhDong("cấm đăng tin tức (id: " + id + ")");
            }
            PopulateControls();
        }
    }
    //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int chon = Convert.ToInt32(ddlCategory.SelectedValue);
    //    switch (chon)
    //    {
    //        case 0:
    //            Response.Redirect("~/Admin/MgerArticle.aspx?Status=0");
    //            break;
    //        case 1:
    //            Response.Redirect("~/Admin/MgerArticle.aspx?Status=1");
    //            break;
    //        case 2:
    //            Response.Redirect("~/Admin/MgerArticle.aspx?Status=2");
    //            break;
    //        default:
    //            PopulateControls();
    //            break;
    //    }
    //}
    protected void ddlTheLoai_SelectedIndexChanged(object sender, EventArgs e)
    {
        int chon = Convert.ToInt32(ddlTheLoai.SelectedValue);
        if (chon != 0)
            Response.Redirect("~/Admin/MgerVanBan.aspx?MenuID=" + chon.ToString());
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