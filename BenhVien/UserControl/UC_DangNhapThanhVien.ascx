<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_DangNhapThanhVien.ascx.cs" Inherits="UserControl_UC_DangNhapThanhVien" %>

<div class="khoi">
    <div class="khoi-tieu-de">
        <div class="gach-ngang"></div>
        <div class="nga-mau"></div>
        <div class="tieu-de">
            <h1>
                <img src="/Design/dangnhap.png" class="block-heder-icon" alt="icon" />
                <span>ĐĂNG NHẬP THÀNH VIÊN</span>

            </h1>
        </div>
    </div>
    <div class="khoi-noi-dung">
        <div class="khoi-noi-dung-wrap">
            <div class="line-fix-parent-width h24 mb5" style="margin-top: 24px;">
                <span class="nhan">Tên người dùng:</span>
                <asp:TextBox ID="txtTenNguoiDung" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div class="line-fix-parent-width h24 mb5">
                <span class="nhan">Mật khẩu:</span>
                <asp:TextBox ID="txtMatKhau" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
            </div>
            <div class="line-fix-parent-width h24 mb10">
                <asp:Literal ID="ltrTrangThanhVien" runat="server" Text="Trang thành viên"></asp:Literal>
                <asp:Button ID="btnDangNhap" runat="server" CssClass="btn" Text="Đăng nhập" OnClick="btnDangNhap_Click"></asp:Button>
                <asp:Button ID="btnDangXuat" runat="server" CssClass="btn" Text="Đăng xuất" OnClick="btnDangXuat_Click" Visible="false"></asp:Button>
            </div>
        </div>
    </div>
</div>
