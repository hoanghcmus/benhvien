<%@ Page Title="" Language="C#" MasterPageFile="~/View/ThanhVien.master" AutoEventWireup="true" CodeFile="TaiKhoan.aspx.cs" Inherits="View_TaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Styles/multies/jquery.datetimepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <asp:Label ID="lbIDNguoiDung" runat="server" Visible="false"></asp:Label>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Tên đăng nhập</span></div>

            <asp:TextBox ID="txtTenDangNhap" runat="server" Enabled="false" CssClass="input"></asp:TextBox>

        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Mật khẩu cũ</span></div>
            <asp:TextBox ID="txtMatKhauCu" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
            <asp:Label ID="MKC" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Mật khẩu mới</span></div>

            <asp:TextBox ID="txtMatKhauMoi" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtMatKhauMoi" ControlToCompare="txtXacNhanMatKhauMoi" Operator="Equal" Type="String" ErrorMessage="không khớp" CssClass="titletb" ValidationGroup="taikhoan"></asp:CompareValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Xác nhận mật khẩu mới</span></div>

            <asp:TextBox ID="txtXacNhanMatKhauMoi" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtXacNhanMatKhauMoi" ControlToCompare="txtMatKhauMoi" Operator="Equal" Type="String" ErrorMessage="không khớp" CssClass="titletb" ValidationGroup="taikhoan"></asp:CompareValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Tên thành viên</span></div>

            <asp:TextBox ID="txtTenThanhVien" runat="server" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenThanhVien" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Địa chỉ</span></div>

            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiaChi" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Ngày sinh</span></div>

            <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="input chose-date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNgaySinh" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Số điện thoại</span></div>

            <asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSoDienThoai" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb" ValidationGroup="taikhoan">*</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <asp:Literal ID="ltrMess" runat="server" Text=""></asp:Literal>
            <asp:Button ID="btnCapNhat" runat="server" CssClass="btn" Text="Cập nhật tài khoản thành viên" OnClick="btnCapNhat_Click" ValidationGroup="taikhoan"></asp:Button>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">

    <script type="text/javascript" src="/Styles/multies/jquery.datetimepicker.js"></script>
    <script type="text/javascript" src="/Styles/multies/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        jQuery('.chose-date').datetimepicker({
            lang: 'vi',
            timepicker: false,
            format: 'd/m/Y'
        });
    </script>

</asp:Content>

