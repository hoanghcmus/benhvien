using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class View_TruyenNhanFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            lbID.Text = Session["idthanhvien"].ToString() ?? "-1";
        }
    }
    protected void down_Click(object sender, EventArgs e)
    {
        var btn = (LinkButton)(sender);
        string path = btn.CommandArgument;
        Response.Redirect("/View/DownLoadFile.ashx?fileName=" + path);
    }

    protected void rptArticleList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
<<<<<<< HEAD

            TruyenNhanFile vb = (TruyenNhanFile)dataItem.DataItem;
            var lbt = e.Item.FindControl("down") as LinkButton;
            lbt.CommandArgument = vb.DuongDan;
        }
    }

    protected void ListPager_PreRender(object sender, EventArgs e)
    {
        string IDThanhVien = Session["idthanhvien"].ToString() ?? "1";
        List<TruyenNhanFile> listVB = TruyenNhanFile.LayTatCa_TheoTV(IDThanhVien);
        LoadDataToRPT(listVB);
        lnkGuiFile.NavigateUrl = String.Format("/edit-truyen-nhan-file-0-{0}.html", IDThanhVien);
    }
    protected void LoadDataToRPT(List<TruyenNhanFile> listVB)
    {
        if (listVB != null && listVB.Count > 0)
        {
            rptArticleList.DataSource = listVB;
            rptArticleList.DataBind();
        }
    }
    protected void rptArticleList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
    }
    protected void drlNhanGui_SelectedIndexChanged(object sender, EventArgs e)
    {
        string condition = drlNhanGui.SelectedValue;
        if (condition.Equals("1"))
        {
            LoadDataToRPT(TruyenNhanFile.LayTatCa_Nhan(lbID.Text));
        }
        else if (condition.Equals("2"))
        {
            LoadDataToRPT(TruyenNhanFile.LayTatCa_Gui(lbID.Text));
        }
        else
        {
            LoadDataToRPT(TruyenNhanFile.LayTatCa_TheoTV(lbID.Text));
        }
    }

=======

            TruyenNhanFile vb = (TruyenNhanFile)dataItem.DataItem;

            var lbt = e.Item.FindControl("down") as HyperLink;
            lbt.NavigateUrl = "/View/DownLoadFile.ashx?fileName=" + vb.DuongDan;
        }
    }

    protected void ListPager_PreRender(object sender, EventArgs e)
    {
        string IDThanhVien = Session["idthanhvien"].ToString() ?? "1";
        List<TruyenNhanFile> listVB = TruyenNhanFile.LayTatCa_TheoTV(IDThanhVien);
        LoadDataToRPT(listVB);
        lnkGuiFile.NavigateUrl = String.Format("/edit-truyen-nhan-file-0-{0}.html", IDThanhVien);
    }
    protected void LoadDataToRPT(List<TruyenNhanFile> listVB)
    {
        if (listVB != null && listVB.Count > 0)
        {
            rptArticleList.DataSource = listVB;
            rptArticleList.DataBind();
        }
    }
    protected void rptArticleList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
    }
    protected void drlNhanGui_SelectedIndexChanged(object sender, EventArgs e)
    {
        string condition = drlNhanGui.SelectedValue;
        if (condition.Equals("1"))
        {
            LoadDataToRPT(TruyenNhanFile.LayTatCa_Nhan(lbID.Text));
        }
        else if (condition.Equals("2"))
        {
            LoadDataToRPT(TruyenNhanFile.LayTatCa_Gui(lbID.Text));
        }
        else
        {
            LoadDataToRPT(TruyenNhanFile.LayTatCa_TheoTV(lbID.Text));
        }
    }

>>>>>>> 642fe2eeb6d7f9e65a3bcdbd2ead2a9e4895a454
    public string ShowInfo(object sender, string column)
    {
        string IDThanhVien = Session["idthanhvien"].ToString() ?? "1";
        TruyenNhanFile tnf = sender as TruyenNhanFile;
        switch (column)
        {
            case "chinhsua":
                if (tnf.IDThanhVienGui.ToString().Equals(IDThanhVien))
                    return String.Format("<a href='/edit-truyen-nhan-file-{0}-{1}.html' class='lnk'><img src='/Design/pencil.png' alt='Edit' class='img'></img></a>", tnf.ID, tnf.IDThanhVienGui);
                else return "";
            default:
                return "";
        }
    }
}