using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    #region Load Link
    private int KiemTraSession()
    {
        int kq = 0;
        string chuoiQuyen = Session["QuyenHan"].ToString();
        string[] str = chuoiQuyen.Split(',');
        foreach (var item in str)
        {
            if (item.ToString() == "1" || item.ToString() == "2"
                || item.ToString() == "3" || item.ToString() == "4")
                kq = 1;
        }
        return kq;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string page = Request.AppRelativeCurrentExecutionFilePath;
            if (String.Compare(page, "~/Admin/EditVanBan.aspx", true) == 0 || String.Compare(page, "~/Admin/EditTruyenNhanFile.aspx", true) == 0)
            {
                Session["ckfunc"] = "tv";
            }
            else
            {
                Session["ckfunc"] = "";
            }

            if (String.Compare(page, "~/Admin/EditTruyenNhanFile.aspx", true) == 0)
            {
                Session["uID"] = "1";
            }
            else
            {
                Session["uID"] = "";
            }


        }
        if (KiemTraSession() == 1)
        {
            if (!IsPostBack)
                PopulateControls();
        }
        else
            Response.Redirect("~/Admin/Login.aspx");
    }
    private void PopulateControls()
    {
        lbUser.Text = Session["TenNguoiDung"].ToString();
        lblh.Text = "+ " + LienHe.DemTheoTrangThaiVaTheLoai(0, 1).ToString();
        lbLetter.Text = "+ " + HoiDap.DemTheoTrangThai(0).ToString();
        //lbshopping.Text = shop;
        string tenDangNhap = Session["TenDangNhap"].ToString();
        string quyenHan = Session["QuyenHan"].ToString();
        if (tenDangNhap != "" || quyenHan != "")
        {
            UnLockQuanLyNguoiDung();
            UnLockQuanLyThanhPhan();
            UnLockQuanLyThongTin();
            string chuoiQuyen = Session["QuyenHan"].ToString();
            string[] str = chuoiQuyen.Split(',');
            foreach (var item in str)
            {
                switch (item.ToString())
                {
                    case "1":
                        OnLockQuanLyNguoiDung();
                        OnLockQuanLyThanhPhan();
                        OnLockQuanLyThongTin();
                        break;
                    case "2":
                        OnLockQuanLyThanhPhan();
                        break;
                    case "3":
                        OnLockQuanLyNguoiDung();
                        break;
                    case "4":
                        OnLockQuanLyThongTin();
                        break;
                }
            }
        }
        else
            Response.Redirect("~/Admin/Login.aspx");
    }
    #endregion

    #region Un And On Lock Link
    private void UnLockQuanLyThanhPhan()
    {
        lnkMgerMenu.Visible = false;
    }
    private void OnLockQuanLyThanhPhan()
    {
        lnkMgerMenu.Visible = true;
    }
    private void UnLockQuanLyThongTin()
    {
        lnkLetter.Visible = false;
        lnkMgerContact.Visible = false;
        lnkMgerAr.Visible = false;
        lnkEditArticle.Visible = false;
        lnkMgerArticle.Visible = false;
        lnkMgerPhoto.Visible = false;
        //lnkMgerSupport.Visible = false;
        lnkSlideShow.Visible = false;
        lnkMgerVideo.Visible = false;
    }
    private void OnLockQuanLyThongTin()
    {
        lnkLetter.Visible = true;
        lnkMgerContact.Visible = true;
        lnkMgerAr.Visible = true;
        lnkEditArticle.Visible = true;
        lnkMgerArticle.Visible = true;
        lnkMgerPhoto.Visible = true;
        //lnkMgerSupport.Visible = true;
        lnkSlideShow.Visible = true;
        lnkMgerVideo.Visible = true;
    }
    private void UnLockQuanLyNguoiDung()
    {
        lnkMgerUs.Visible = false;
        lnkMgerGroupUser.Visible = false;
        lnkMgerJoinGroupUser.Visible = false;
        lnkMgerLogin.Visible = false;
        lnkMgerUser.Visible = false;
    }
    private void OnLockQuanLyNguoiDung()
    {
        lnkMgerUs.Visible = true;
        lnkMgerGroupUser.Visible = true;
        lnkMgerJoinGroupUser.Visible = true;
        lnkMgerLogin.Visible = true;
        lnkMgerUser.Visible = true;
    }
    #endregion
}
