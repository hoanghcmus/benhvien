<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerArticleByCat.aspx.cs" Inherits="Admin_MgerArticleByCat" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có trạng thái bài viết" />
                <asp:Label ID="lbModuleID" runat="server" Visible="false" />
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><%=lbModuleID.Text.Equals("13") ? "Thông tin chung" : "Giấy mời họp"  %><span class="divider">>></span></li>
            <li class="active"><%=lbModuleID.Text.Equals("13") ? "Danh sách tin" : "Danh sách giấy mời"  %></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <div>
                            <asp:DropDownList runat="server" ID="ddlTheLoai" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged" CssClass="drl">
                                <asp:ListItem>-- Chọn xem theo thể loại -- </asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="drl">
                                <asp:ListItem>-- Chọn xem quản lý bản tin -- </asp:ListItem>
                                <asp:ListItem Value="0">Danh sách bản tin đợi duyệt</asp:ListItem>
                                <asp:ListItem Value="1">Danh sách bản tin đã đăng</asp:ListItem>
                                <asp:ListItem Value="2">Danh sách bản tin cấm đăng</asp:ListItem>
                            </asp:DropDownList>--%>
                        </div>
                    </div>
                    <hr />
                    <div class="content_mid">
                        <input type="button" value="Thêm bài viết" class="btnedit" onclick="location.href = 'EditArticleTV.aspx?moduleID=<%=lbModuleID.Text%>    '" />
                        <asp:Button Text="Xóa bài đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <%--<asp:Button Text="Đăng bài đã chọn" runat="server" ID="btnDang" CssClass="execuChek"
                            Visible="False" OnClick="btnDang_Click" />
                        <asp:Button Text="Cấm Đăng bài đã chọn" runat="server" ID="btnCamDang" CssClass="execuChek"
                            Visible="False" OnClick="btnCamDang_Click" />--%>
                        |&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text=" Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href = 'MgerArticleByCat.aspx?moduleID=<%=lbModuleID.Text%>    '" />
                        <div class="block">
                            <p class="block-heading">
                                <%=lbModuleID.Text.Equals("13") ? "Thông tin chung" : "Giấy mời họp"  %>
                            </p>
                            <table class="list">
                                <thead>
                                    <tr>
                                        <th class="id">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="img">Hình Ảnh
                                        </th>
                                        <th class="titlemax">Tiêu đề
                                        </th>
                                        <th class="smallmax">Ngày tạo
                                        </th>
                                        <th class="smallmax">Người tạo
                                        </th>
                                        <th class="id">ID
                                        </th>
                                        <th class="idmax">Sửa
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater runat="server" ID="repProd">
                                    <AlternatingItemTemplate>
                                        <tr class="eventop">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                    Height="80" Width="90" />
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TieuDe_Vn")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NgayTao") %>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NguoiTao") %>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='<%# DataAccess.Connect.Link.EditArticle1(Eval("ID").ToString(), lbModuleID.Text) %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <ItemTemplate>
                                        <tr class="evenbottom">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:Image runat="server" ID="img" ImageUrl='<%# DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString()) %>'
                                                    Height="80" Width="90" />
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TieuDe_Vn")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NgayTao") %>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NguoiTao") %>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='<%# DataAccess.Connect.Link.EditArticle1(Eval("ID").ToString(), lbModuleID.Text) %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <uc1:UC_PhanTrang ID="PagerBottom" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>

