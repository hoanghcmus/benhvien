<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<%@ Register Src="Mger_UserControl/UC_ThongKeBaiViet.ascx" TagName="UC_ThongKeBaiViet"
    TagPrefix="uc1" %>
<%@ Register Src="Mger_UserControl/UC_MenuTat.ascx" TagName="UC_MenuTat" TagPrefix="uc2" %>
<%@ Register Src="Mger_UserControl/UC_ThongKeNguoiDung.ascx" TagName="UC_ThongKeNguoiDung"
    TagPrefix="uc3" %>
<%@ Register Src="Mger_UserControl/UC_ThongKeKhac.ascx" TagName="UC_ThongKeKhac"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <div class="stats">
                <p class="stat">
                    <span class="number">
                        <asp:Label ID="lbvideo" runat="server" Text="0" /></span>Video
                </p>
                <p class="stat">
                    <span class="number">
                        <asp:Label ID="lbalbum" runat="server" Text="0" /></span>Album ảnh
                </p>
                <p class="stat">
                    <span class="number">
                        <asp:Label ID="lbbaiViet" runat="server" Text="0" /></span>Bài viết -
                </p>
                <p class="stat">
                    <span class="number">
                        <asp:Label ID="lblienHe" runat="server" Text="0" /></span>Liên hệ -
                </p>
            </div>
            <h1 class="page-title">Thông tin trang chủ</h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <a href="#page-stats" class="block-heading" data-toggle="collapse">Bảng menu tắt</a>
                    <div id="page-stats" class="block-body collapse in">
                        <uc2:UC_MenuTat ID="UC_MenuTat1" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="block span6">
                    <a href="#page-article" class="block-heading" data-toggle="collapse">THỐNG KÊ WEBSITE</a>
                    <div id="page-article" class="block-body collapse in">
                        <uc1:UC_ThongKeBaiViet ID="UC_ThongKeBaiViet1" runat="server" />
                    </div>
                </div>

                <uc3:UC_ThongKeNguoiDung ID="UC_ThongKeNguoiDung3" Visible="false" runat="server" />

            </div>

        </div>
        <div class="clearfix">
        </div>
    </div>
    <div class="clearfix">
    </div>
</asp:Content>
