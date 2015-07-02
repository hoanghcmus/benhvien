using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Connect;
using DataAccess.Help;

public partial class View_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
    }

    public string DecodeUtf8(string s_Input)
    {
        byte[] u8_Utf = new byte[s_Input.Length];
        for (int i = 0; i < s_Input.Length; i++)
        {
            if (s_Input[i] > 255)
                return s_Input;

            u8_Utf[i] = (byte)s_Input[i];
        }
        return Encoding.UTF8.GetString(u8_Utf);
    }

    public string ShowInfo(object input, string colunmName)
    {
        TimKiem data = input as TimKiem;
        switch (colunmName)
        {
            case "hienthilink":
                if (data.Module.Equals("baiviet"))
                {
                    return "/" + data.IDTheLoai + "/bai-viet/" + Helper.RejectMarks(data.TieuDe) + "-" + data.ID + ".html";
                }
                else
                {
                    return "/hoi-dap/" + Helper.ToSeoString(data.NoiDung) + "-" + data.ID + ".html";
                }
            case "hienthinoidung":
                if (data.Module.Equals("baiviet"))
                {
                    return "<span style='color:red;'>[.::Thông tin::.]  </span>" + data.TieuDe;
                }
                else
                {
                    return "<span style='color:blue;'>[.::Hỏi đáp::.]  </span>" + data.NoiDung;
                }
            default:
                return "";
        }
    }


    protected void ListPager_PreRender(object sender, EventArgs e)
    {

        //string keyword = Request.Form["keyword"] ?? "";
        string keyword = Request.QueryString["keyword"] ?? "";

        keyword = DecodeUtf8(keyword);
        List<TimKiem> listTimKiem = TimKiem.TimKiemTuBaiVietVaHoiDap(keyword);
        if (listTimKiem != null)
        {
            rptArticleList.DataSource = listTimKiem;
            rptArticleList.DataBind();
            if (listTimKiem.Count != 0)
            {
                lbMessage.Text = "<b style='color: red;  color: red; font-size: 13px;f ont-family: Arial; margin-bottom: 5px;float: left;'>Có " + listTimKiem.Count() + " kết quả được tìm thấy</b>";
            }
            else
            {
                lbMessage.Text = "<b style='color: red;  color: red; font-size: 13px;f ont-family: Arial; margin-bottom: 5px;float: left;'>Không có kết quả nào phù hợp với nội dung tìm kiếm :: <i style='color:blue;'>" + keyword + "</i> ::</b>";
            }
        }
    }

    protected void rptArticleList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
    }
}