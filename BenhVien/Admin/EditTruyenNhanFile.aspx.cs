using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_EditTruyenNhanFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["ID"] ?? "-1";
            if (id.Equals("-1")) down.Visible = false;
            else down.Visible = true;

            string idtv = Request.QueryString["IDTV"] ?? "-1";
            if (!id.Equals("-1") && !idtv.Equals("1")) Response.Redirect("/Admin/MgerTruyenNhanFile.aspx");

            LoadDSThanhVien();

            txtNgayGui.Text = DateTime.Now.ToShortDateString();

            TruyenNhanFile tnf = TruyenNhanFile.LayTheoID(id);
            if (tnf != null && tnf.ID > 0)
            {
                lblId.Text = id;
                SetData(tnf);
            }
            else
            {
                txtNguoiGui.Text = "Quản trị viên";
                lbIDNguoiGui.Text = "1";
            }
        }
    }
    protected void LoadDSThanhVien()
    {
        List<ThanhVien> listTV = ThanhVien.LayTatCa_EceptID("1");
        if (listTV != null && listTV.Count > 0)
        {
            drlNguoiNhan.DataValueField = "IDNguoiDung";
            drlNguoiNhan.DataTextField = "TenNguoiDung";
            drlNguoiNhan.DataSource = listTV;
            drlNguoiNhan.DataBind();
            drlNguoiNhan.Items.Insert(0, new ListItem("Chọn người nhận", "0"));
        }
    }
    protected void down_Click(object sender, EventArgs e)
    {
        var btn = (LinkButton)(sender);
        string path = btn.CommandArgument;
        Response.Redirect("/View/DownLoadFile.ashx?fileName=" + path);
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        TruyenNhanFile tn = GetData();
        if (tn.ID > 0)
        {
            if (TruyenNhanFile.Sua(tn))
            {
                Label1.Text = "<h6 style='color:blue;' class='tvlink'>Đã cập nhật thông tin gửi file</h6>";
            }
            else
            {
                Label1.Text = "<h6 style='color:red;' class='tvlink'>Có lỗi xảy ra!</h6>";
            }
        }
        else
        {
            if (TruyenNhanFile.Them(tn) > 0)
            {
                Label1.Text = "<h6 style='color:blue;' class='tvlink'>Đã gửi file cho thành viên</h6>";
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
        txtNguoiGui.Text = string.Empty;
        lbIDNguoiGui.Text = string.Empty;

        down.CommandArgument = string.Empty;
        txtDuongDan.Text = string.Empty;

        txtMoTa.Text = string.Empty;
        txtNguoiGui.Text = string.Empty;

    }
    protected void SetData(TruyenNhanFile tn)
    {
        txtNguoiGui.Text = tn.TenThanhVienGui;
        lbIDNguoiGui.Text = tn.IDThanhVienGui.ToString();

        down.CommandArgument = tn.DuongDan;
        txtDuongDan.Text = tn.DuongDan;

        txtMoTa.Text = tn.MoTa;
        drlNguoiNhan.SelectedValue = tn.IDThanhVienNhan.ToString();
        txtNgayGui.Text = tn.NgayGui;
    }

    protected TruyenNhanFile GetData()
    {
        TruyenNhanFile tn = null;
        if (!lblId.Text.Equals(""))
            tn = TruyenNhanFile.LayTheoID(lblId.Text.Trim());
        else
            tn = new TruyenNhanFile();

        tn.IDThanhVienGui = Convert.ToInt32(lbIDNguoiGui.Text);
        tn.DuongDan = txtDuongDan.Text.Trim();
        tn.MoTa = txtMoTa.Text.Trim();
        tn.IDThanhVienNhan = Convert.ToInt32(drlNguoiNhan.SelectedValue); ;
        tn.NgayGui = txtNgayGui.Text.Trim();
        return tn;
    }
}