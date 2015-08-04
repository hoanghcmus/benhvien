using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_MgerTruyenNhanFile : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
<<<<<<< HEAD
            if (item.ToString() == "1" || item.ToString() == "2")
=======
            if (item.ToString() == "1" || item.ToString() == "2" || item.ToString() == "4")
>>>>>>> 642fe2eeb6d7f9e65a3bcdbd2ead2a9e4895a454
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
        string chuoiTimKiem = Request.QueryString["Search"] ?? "";
        //string TrangThai = Request.QueryString["Status"] ?? "";
        string Trang = Request.QueryString["Page"] ?? "1";
        string firstPageUrl = "";
        string pagerUrl = "";

        if (chuoiTimKiem != "")
        {
            Label1.Text = "Kết quả tìm kiếm cho chuỗi '" + chuoiTimKiem + "'";
            txtTimKiem.Text = chuoiTimKiem.ToString();
            repProd.DataSource = TruyenNhanFile.Tim(chuoiTimKiem, Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.EditTruyenNhanFileToSreach(chuoiTimKiem);
            pagerUrl = DataAccess.Connect.Link.EditTruyenNhanFileToSreach(chuoiTimKiem, "{0}");
        }
        else
        {
            Label1.Text = "Danh sách truyền nhận file";
            repProd.DataSource = TruyenNhanFile.LayTatCa_PhanTrang(Trang, out howManyPages);
            repProd.DataBind();
            firstPageUrl = DataAccess.Connect.Link.MgerTruyenNhanFile("1");
            pagerUrl = DataAccess.Connect.Link.MgerTruyenNhanFile("1", "{0}");
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
                TruyenNhanFile.Xoa(id);
                CapNhatHanhDong("Xóa truyền nhận file(id: " + id + ")");
            }
            PopulateControls();
        }
    }
    void btnTimKiem_Click(object sender, EventArgs e)
    {
        string chuoiTimKiem = txtTimKiem.Text.Trim();
        if (chuoiTimKiem != "")
        {
            CapNhatHanhDong("Tìm kiếm truyền nhận file(chuổi tìm kiếm: " + chuoiTimKiem + ")");
            Response.Redirect("MgerTruyenNhanFile.aspx?Search=" + chuoiTimKiem);
        }
    }

    protected void down_Click(object sender, EventArgs e)
    {
        var btn = (LinkButton)(sender);
        string path = btn.CommandArgument;
        Response.Redirect("/View/DownLoadFile.ashx?fileName=" + path);
    }

    protected void rptArticleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TruyenNhanFile tnf = (TruyenNhanFile)e.Item.DataItem;
        var lbt = e.Item.FindControl("down") as LinkButton;
        lbt.CommandArgument = tnf.DuongDan;

    }

    public string ShowInfo(object sender, string column)
    {
        TruyenNhanFile tnf = sender as TruyenNhanFile;
        switch (column)
        {
            case "chinhsua":
                if (tnf.IDThanhVienGui == 1)
                    return String.Format("<a href='EditTruyenNhanFile.aspx?ID={0}&IDTV={1}' class='lnk'><i class='icon-pencil'></i></a>", tnf.ID, tnf.IDThanhVienGui);
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