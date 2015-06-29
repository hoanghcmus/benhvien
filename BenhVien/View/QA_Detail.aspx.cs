using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.StringUtil;

public partial class View_QA_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idHoiDap = Request.QueryString["IDHoiDap"] ?? "1";
        HoiDap hoiDap = HoiDap.LayTheoID(idHoiDap);
        if (hoiDap != null)
        {
            SetData(hoiDap);
        }
    }
    protected void SetData(HoiDap hoiDap)
    {
        lbTitle.Text = hoiDap.TieuDe;
        lbNoiDungHoi.Text = hoiDap.NoiDungHoi;
        lbHoTen.Text = "(" + hoiDap.HoTen;
        lbNgayGui.Text = hoiDap.NgayGui.ToString().Split(' ').First().ToString() + ")";
        ltNoiDungDap.Text = hoiDap.NoiDungDap;        
       
    }
    public string Showinfo(object input, string colunmName)
    {
        HoiDap data = input as HoiDap;
        switch (colunmName)
        {
            case "ngaygui":
                return data.NgayGui.ToString().Split(' ').First().ToString();
            default:
                return "";
        }
    }
}