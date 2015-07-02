using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using DataAccess.Help;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<BaiViet> listBV = BaiViet.LayTheoModuleTop20("4");
            LoadDataChoKhoiTinTuc(listBV);

            //listBV = BaiViet.LayTheoModuleAll("4");
            LoadDataChoKhoiQuyDinhQuyChe(listBV);

            //listBV = BaiViet.LayTheoModuleAll("4");
            LoadDataChoKhoiThongTinYDuoc(listBV);

            //listBV = BaiViet.LayTheoModuleAll("4");
            LoadDataChoKhoiYHocThuongThuc(listBV);

            //listBV = BaiViet.LayTheoModuleAll("4");
            LoadDataChoKhoiThongBao(listBV);

            List<TheLoai> listTL = TheLoai.LayTheoModule("10");
            LoadDataLienKetWebsite(listTL);
        }
    }

    protected void LoadDataChoKhoiTinTuc(List<BaiViet> listBV)
    {
        if (listBV != null && listBV.Count > 0)
        {
            List<BaiViet> listBaiViet = new List<BaiViet>();
            for (int i = 0; i < listBV.Count; i++)
            {
                BaiViet bv = listBV.ElementAt(i);
                if (i == 0)
                {
                    imgTinLonFigure.ImageUrl = bv.HinhAnh;
                    hlTinLonTieuDe.Text = bv.TieuDe_Vn;
                    hlTinLonTieuDe.NavigateUrl = String.Format("/{0}/bai-viet/{1}-{2}.html", bv.IDTheLoai, Helper.RejectMarks(bv.TieuDe_Vn), bv.ID);
                    ltrTinLonMoTa.Text = bv.TomTat_Vn;
                }
                if (i > 0)
                {
                    if (i < 8)
                        listBaiViet.Add(bv);
                    else
                        break;
                }
            }
            rptTinTucLienQuan.DataSource = listBaiViet;
            rptTinTucLienQuan.DataBind();
        }
    }

    protected void LoadDataChoKhoiQuyDinhQuyChe(List<BaiViet> listBV)
    {
        if (listBV != null && listBV.Count > 0)
        {
            List<BaiViet> listBaiVietNgang = new List<BaiViet>();
            List<BaiViet> listBaiVietLienQuan = new List<BaiViet>();
            for (int i = 0; i < listBV.Count; i++)
            {
                BaiViet bv = listBV.ElementAt(i);
                if (i < 2)
                {
                    listBaiVietNgang.Add(bv);
                }
                if (i >= 2)
                {
                    if (i < 9)
                        listBaiVietLienQuan.Add(bv);
                    else
                        break;
                }
            }
            rptQuyCheItemNgang.DataSource = listBaiVietNgang;
            rptQuyCheItemNgang.DataBind();

            rptQuyCheLienQuan.DataSource = listBaiVietLienQuan;
            rptQuyCheLienQuan.DataBind();
        }
    }

    protected void LoadDataChoKhoiThongTinYDuoc(List<BaiViet> listBV)
    {
        if (listBV != null && listBV.Count > 0)
        {
            List<BaiViet> listBaiVietDoc = new List<BaiViet>();
            List<BaiViet> listBaiVietLienQuan = new List<BaiViet>();
            for (int i = 0; i < listBV.Count; i++)
            {
                BaiViet bv = listBV.ElementAt(i);
                if (i < 2)
                {
                    listBaiVietDoc.Add(bv);
                }
                if (i >= 2)
                {
                    if (i < 7)
                        listBaiVietLienQuan.Add(bv);
                    else
                        break;
                }
            }
            rptThongTinYItemDoc.DataSource = listBaiVietDoc;
            rptThongTinYItemDoc.DataBind();

            rptThongTinYLienQuan.DataSource = listBaiVietLienQuan;
            rptThongTinYLienQuan.DataBind();
        }
    }

    protected void LoadDataChoKhoiThongBao(List<BaiViet> listBV)
    {
        List<BaiViet> listBaiViet = new List<BaiViet>();
        for (int i = 0; i < listBV.Count; i++)
        {
            BaiViet bv = listBV.ElementAt(i);
            if (i < 19)
            {
                listBaiViet.Add(bv);
            }

        }
        rptThongBao.DataSource = listBaiViet;
        rptThongBao.DataBind();
    }

    protected void LoadDataChoKhoiYHocThuongThuc(List<BaiViet> listBV)
    {
        if (listBV != null && listBV.Count > 0)
        {
            List<BaiViet> listBaiVietYHocThuongThuc = new List<BaiViet>();
            List<BaiViet> listBaiVietLienQuan = new List<BaiViet>();
            for (int i = 0; i < listBV.Count; i++)
            {
                BaiViet bv = listBV.ElementAt(i);
                if (i < 2)
                {
                    listBaiVietYHocThuongThuc.Add(bv);
                }
                if (i >= 2)
                {
                    if (i < 8)
                        listBaiVietLienQuan.Add(bv);
                    else
                        break;
                }
            }
            rptYHocThuongThucItemNgang.DataSource = listBaiVietYHocThuongThuc;
            rptYHocThuongThucItemNgang.DataBind();

            rptYHocThuongThucLienQuan.DataSource = listBaiVietLienQuan;
            rptYHocThuongThucLienQuan.DataBind();
        }
    }

    protected void LoadDataLienKetWebsite(List<TheLoai> listTL)
    {
        drlLienKetWebsite.DataTextField = "TieuDe_Vn";
        drlLienKetWebsite.DataValueField = "DuongDan_Vn";
        drlLienKetWebsite.DataSource = listTL;
        drlLienKetWebsite.DataBind();
        drlLienKetWebsite.Items.Insert(0, new ListItem("Chọn liên kết", "#"));
        //drlLienKetWebsite.Items[0].Attributes.Add("disabled", "disabled");     
        
    }


    public String ShowInfo(object sender, string func)
    {
        BaiViet bv = sender as BaiViet;
        switch (func)
        {
            case "lienket":
                return String.Format("/{0}/bai-viet/{1}-{2}.html", bv.IDTheLoai, Helper.RejectMarks(bv.TieuDe_Vn), bv.ID);
            default: return "";
        }
    }
    protected void drlLienKetWebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        string lienKet = drlLienKetWebsite.SelectedValue.Trim();      
        Response.Redirect(lienKet);
    }
}