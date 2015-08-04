using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class View_VanBanChung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
<<<<<<< HEAD
        {           
=======
        {
>>>>>>> 642fe2eeb6d7f9e65a3bcdbd2ead2a9e4895a454

        }
    }
    private void LoadTheLoai()
    {
        drlTheLoai.DataValueField = "ID";
        drlTheLoai.DataTextField = "TieuDe_Vn";
        drlTheLoai.DataSource = TheLoai.LayTheoModule("14");
        drlTheLoai.DataBind();
        drlTheLoai.Items.Insert(0, new ListItem("Chọn thể loại văn bản", "0"));
    }
    protected void down_Click(object sender, EventArgs e)
    {
        var btn = (LinkButton)(sender);
        string path = btn.CommandArgument;
        Response.Redirect("/View/DownLoadFile.ashx?fileName=" + path);
    }
    protected void rptVanBan_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var vb = e.Item.DataItem as VanBan;
        var lbt = e.Item.FindControl("down") as LinkButton;
        lbt.CommandArgument = vb.DuongDan;
    }


    protected void ListPager_PreRender(object sender, EventArgs e)
    {
        List<VanBan> listVB = VanBan.LayTheoModuleAll("14");
        if (listVB != null && listVB.Count > 0)
        {
            rptArticleList.DataSource = listVB;
            rptArticleList.DataBind();
        }
        LoadTheLoai();
    }

    protected void rptArticleList_DataBound(object sender, EventArgs e)
    {
        ListPager.Visible = (ListPager.PageSize < ListPager.TotalRowCount);
    }

    protected void rptArticleList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;

            VanBan vb = (VanBan)dataItem.DataItem;
<<<<<<< HEAD
            var lbt = e.Item.FindControl("down") as LinkButton;
            lbt.CommandArgument = vb.DuongDan;
=======
            var lbt = e.Item.FindControl("down") as HyperLink;
            lbt.NavigateUrl = "/View/DownLoadFile.ashx?fileName=" + vb.DuongDan;
>>>>>>> 642fe2eeb6d7f9e65a3bcdbd2ead2a9e4895a454
        }
    }
    protected void drlTheLoai_SelectedIndexChanged(object sender, EventArgs e)
    {
        string menuID = drlTheLoai.SelectedValue;
        List<VanBan> listVB = VanBan.LayTheoTheLoai_All(menuID);
        if (listVB != null && listVB.Count > 0)
        {
            rptArticleList.DataSource = listVB;
            rptArticleList.DataBind();
        }
    }
}