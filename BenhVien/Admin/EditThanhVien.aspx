<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditThanhVien.aspx.cs" Inherits="Admin_EditThanhVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm thành viên mới" />
                <asp:Label ID="lbModuleID" runat="server" Visible="false" />
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerTKThanhVien.aspx">Quản lý thành viên</a><span
                class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm thành viên mới" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Thông tin thành viên
                    </p>
                    <div class="toolbar">
                        <table class="Edit">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="" CssClass="red" />
                                    <asp:Label ID="label2" runat="server" Visible="false" />
                                    <asp:Label ID="lblId" runat="server" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Tên Đăng nhập:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTenDangNhap" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTenDangNhap" ErrorMessage="->Vui lòng nhập tên đăng nhập!" CssClass="red" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Mật khẩu mới
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMatKhauMoi" runat="server" CssClass="txtNewMin" TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="MKC" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr class="text">
                                <td>Tên thành viên:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTenThanhVien" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenThanhVien" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr class="text">
                                <td>Địa chỉ:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiaChi" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiaChi" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr class="text">
                                <td>Ngày sinh:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNgaySinh" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="text">
                                <td>Số điện thoại:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSoDienThoai" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr class="text">
                                <td>Chức vụ:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChucVu" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtChucVu" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" OnClick="btnCapNhat_Click" ValidationGroup="taikhoan" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href = 'MgerTKThanhVien.aspx'" /><br />
                                    <br />
                                </td>
                            </tr>
                        </table>
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

