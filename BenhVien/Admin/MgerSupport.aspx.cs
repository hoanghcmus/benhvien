using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class Admin_MgerSupport : System.Web.UI.Page
{
    #region Load du lieu
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "4")
                kq = 1;
        }
        return kq;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (KiemTraSession() == 1)
        {
            if (!IsPostBack)
                PopulateControls();
        }
        else
            Response.Redirect("~/Admin/Admin.aspx");
    }
    private void PopulateControls()
    {
        repProd.DataSource = HoTro.LayTatCa();
        repProd.DataBind();
    }
    #endregion

    #region Xu ly su kien
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnLuu.Click += new EventHandler(btnLuu_Click);
        repProd.ItemCommand += new RepeaterCommandEventHandler(repProd_ItemCommand);
    }
    void repProd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Updata")
        {
            HoTro dataimg = new HoTro();
            TextBox txtfrmTen = (TextBox)e.Item.FindControl("txtfrmTen");
            dataimg.Ten = txtfrmTen.Text.Trim().ToString();
            TextBox txtfrmSDT = (TextBox)e.Item.FindControl("txtfrmSDT");
            dataimg.SDT = txtfrmSDT.Text.Trim().ToString();
            TextBox txtfrmEmail = (TextBox)e.Item.FindControl("txtfrmEmail");
            dataimg.Email = txtfrmEmail.Text.Trim().ToString();
            dataimg.ID = ConvertType.ToInt32(e.CommandArgument.ToString().Trim());
            HoTro.Sua(dataimg);
            CapNhatHanhDong("Sửa Hổ trợ (id: " + e.CommandArgument.ToString().Trim() + ")");
        }
        if (e.CommandName == "Delete")
        {
            string s = e.CommandArgument.ToString();
            HoTro.Xoa(s.ToString());
            CapNhatHanhDong("Xóa hổ trợ (id: " + s[0].ToString() + ")");
        }
        PopulateControls();
    }
    #endregion

    #region Xu ly them
    public int KiemTraDieuKien()
    {
        int kq = 0;
        if (txtNhapTen.Text == "" || txtSDT.Text == "" || txtEmail.Text == "")
        {
            lbrs.Visible = true;
            lbrs.Text = "Cần nhập đầy đủ thông tin để thêm!";
            kq = 0;
        }
        else
        {
            if (txtNhapTen.Text.Length <= 15)
            {
                if (txtSDT.Text.Length <= 15)
                {
                    kq = 1;
                    lbrs.Visible = false;
                }
                else
                {
                    kq = 0;
                    lbrs.Visible = true;
                    lbrs.Text = "SĐT > 15 ký tự";
                }
            }
            else
            {
                kq = 0;
                lbrs.Visible = true;
                lbrs.Text = "Tên không được > 15 ký tự";
            }
        }
        return kq;
    }
    protected void refesh()
    {
        txtNhapTen.Text = "";
        txtSDT.Text = "";
        txtEmail.Text = "";
    }
    void btnLuu_Click(object sender, EventArgs e)
    {
        lbtitle.Visible = true;
        // Neu tat ca du lieu deu duoc nhap hop le 
        if (KiemTraDieuKien() == 1)
        {
            bool rs = false;
            HoTro data = new HoTro();
            data.Ten = txtNhapTen.Text;
            data.SDT = txtSDT.Text;
            data.Email = txtEmail.Text;
            rs = HoTro.Them(data);
            if (rs)
            {
                refesh();
                PopulateControls();
                lbtitle.Text = " *Thêm hổ trợ thành công!";
                CapNhatHanhDong("Thêm hổ trợ(id: " + data.ID + ")");
            }
            else
                lbtitle.Text = " *Thêm hổ trợ thất bại!";
        }
        else
            lbtitle.Text = " *Không thêm được hổ trợ";
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