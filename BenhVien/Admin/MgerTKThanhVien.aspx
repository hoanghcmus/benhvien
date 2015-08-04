<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerTKThanhVien.aspx.cs" Inherits="Admin_MgerTKThanhVien" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có trạng thái thành viên" />
                <asp:Label ID="lbModuleID" runat="server" Visible="false" />
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý thành viên<span class="divider">>></span></li>
            <li class="active">Danh sách thành viên</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="content_mid">
                        <input type="button" value="Thêm thành viên" class="btnedit" onclick="location.href = 'EditThanhVien.aspx'" />
                        <asp:Button Text="Xóa thành viên" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <%--<asp:Button Text="Đăng thành viên đã chọn" runat="server" ID="btnDang" CssClass="execuChek"
                            Visible="False" OnClick="btnDang_Click" />
                        <asp:Button Text="Cấm Đăng thành viên đã chọn" runat="server" ID="btnCamDang" CssClass="execuChek"
                            Visible="False" OnClick="btnCamDang_Click" />--%>
                        |&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text=" Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href = 'MgerTKThanhVien.aspx'" />
                        <div class="block">
                            <p class="block-heading">
                                Danh sách thành viên
                            </p>
                            <table class="list">
                                <thead>
                                    <tr>
                                        <th class="id">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="smallmax">Tên đăng nhập
                                        </th>
                                        <th class="smallmax">Tên người dùng
                                        </th>
                                        <th class="smallmax">Chức vụ
                                        </th>
                                        <th class="smallmax">Địa chỉ
                                        </th>
                                        <th class="smallmax">Ngày sinh
                                        </th>
                                        <th class="smallmax">Số điện thoại
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
                                                 <%#ShowInfo(Container.DataItem, "checkbox") %>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("TenDangNhap")%>
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TenNguoiDung")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("ChucVu")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("DiaChi")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("NgaySinh")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("SoDT")%>
                                            </td>
                                            <td class="id">
                                                <%#Eval("IDNguoiDung")%>
                                            </td>
                                           
                                            <td class="idmax">
                                                <%#ShowInfo(Container.DataItem, "chinhsua") %>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <ItemTemplate>
                                        <tr class="evenbottom">
                                            <td class="id">
                                                 <%#ShowInfo(Container.DataItem, "checkbox") %>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("TenDangNhap")%>
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TenNguoiDung")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("ChucVu")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("DiaChi")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("NgaySinh")%>
                                            </td>
                                            <td class="titlemax">
                                                <%#Eval("SoDT")%>
                                            </td>
                                            <td class="id">
                                                <%#Eval("IDNguoiDung")%>
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

