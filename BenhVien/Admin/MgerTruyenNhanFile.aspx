<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerTruyenNhanFile.aspx.cs" Inherits="Admin_MgerTruyenNhanFile" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có trạng thái truyền nhận file" />
                <asp:Label ID="lbModuleID" runat="server" Visible="false" />
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý truyền nhận file<span class="divider">>></span></li>
            <li class="active">Danh sách truyền nhận file</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="content_mid">
                        <input type="button" value="Gửi file cho thành viên" class="btnedit" onclick="location.href = 'EditTruyenNhanFile.aspx?IDTV=1'" />
                        <asp:Button Text="Xóa truyền nhận file" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <%--<asp:Button Text="Đăng truyền nhận file đã chọn" runat="server" ID="btnDang" CssClass="execuChek"
                            Visible="False" OnClick="btnDang_Click" />
                        <asp:Button Text="Cấm Đăng truyền nhận file đã chọn" runat="server" ID="btnCamDang" CssClass="execuChek"
                            Visible="False" OnClick="btnCamDang_Click" />--%>
                        |&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text=" Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href = 'MgerTruyenNhanFile.aspx'" />
                        <div class="block">
                            <p class="block-heading">
                                Danh sách truyền nhận file
                            </p>
                            <table class="list">
                                <thead>
                                    <tr>
                                        <th class="id">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="smallmax">Người gửi
                                        </th>
                                        <th class="smallmax">File
                                        </th>
                                        <th class="smallmax">Mô tả
                                        </th>
                                        <th class="smallmax">Người nhận
                                        </th>
                                        <th class="smallmax">Ngày gửi
                                        </th>
                                        <th class="id">ID
                                        </th>
                                        <th class="idmax">Sửa
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater runat="server" ID="repProd" OnItemDataBound="rptArticleList_ItemDataBound">
                                    <AlternatingItemTemplate>
                                        <tr class="eventop">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("TenThanhVienGui")%>
                                            </td>
                                            <td class="smallmax" valign="top">
                                                <asp:LinkButton ID="down" runat="server" CssClass="tit" Text="Tải về" OnClick="down_Click"></asp:LinkButton>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("MoTa")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("TenThanhVienNhan")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NgayGui")%>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <%#ShowInfo(Container.DataItem, "chinhsua") %>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <ItemTemplate>
                                        <tr class="evenbottom">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("TenThanhVienGui")%>
                                            </td>
                                            <td class="smallmax" valign="top">
                                                <asp:LinkButton ID="down" runat="server" CssClass="tit" Text="Tải về" OnClick="down_Click"></asp:LinkButton>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("MoTa")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("TenThanhVienNhan")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Eval("NgayGui")%>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <%#ShowInfo(Container.DataItem, "chinhsua") %>
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
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

