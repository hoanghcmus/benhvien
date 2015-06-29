using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_ReplyLetter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadEditor();
        if (!IsPostBack)
        {
            string stringid = Request.Form["cid"] ?? "";
            string firstElementID = "-1";
            if (stringid != "")
            {
                firstElementID = stringid.Split(',').First().ToString();
            }
            HoiDap hoiDap = HoiDap.LayTheoID(firstElementID);
            if (hoiDap != null)
            {
                lbHoiDapId.Text = hoiDap.ID.ToString();
                lbThongTinKhachHang.Text = "Tên: " + hoiDap.HoTen + " --- Email: " + hoiDap.Email + " --- Ngày gửi: " + hoiDap.NgayGui.ToString().Split(' ').First().ToString();
                txtNoiDungHoi.Text = hoiDap.NoiDungHoi;
                txtNoiDungDap.Text = hoiDap.NoiDungDap;
            }
        }
    }

    protected void LoadEditor()
    {
        //Load CKFinder vao CKEditor
        txtNoiDungDap.Language = "vi";
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "ckfinder";
        _FileBrowser.SetupCKEditor(txtNoiDungDap);
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        string Id = lbHoiDapId.Text.Trim();
        string noiDungDap = txtNoiDungDap.Text.Trim();
        bool rs = false;
        rs = HoiDap.CapNhaHoiDap(Id, noiDungDap);
        lbMessage.Text = rs ? "Đã trả lời thư liên hệ" : "Trả lời thư thất bại";
    }
}