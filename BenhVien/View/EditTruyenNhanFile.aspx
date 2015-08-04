<%@ Page Title="" Language="C#" MasterPageFile="~/View/ThanhVien.master" AutoEventWireup="true" CodeFile="EditTruyenNhanFile.aspx.cs" Inherits="View_EditTruyenNhanFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="line-fix-parent-width">
            <asp:Label ID="lblId" runat="server" Visible="false" />
            <div class="nhan"><span>Người gửi</span></div>

            <asp:TextBox ID="txtNguoiGui" runat="server" CssClass="input" Enabled="false"></asp:TextBox>
            <asp:Label ID="lbIDNguoiGui" runat="server" Visible="false"></asp:Label>

        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Tập tin</span></div>

            <asp:TextBox ID="txtDuongDan" runat="server" CssClass="input"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDuongDan" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb">*</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <input id="btnDuyet" type="button" value="Duyệt file" class="btnedit" />
            <asp:LinkButton ID="down" runat="server" CssClass="down" Text="Tải về" OnClick="down_Click"></asp:LinkButton>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Mô tả</span></div>

            <asp:TextBox ID="txtMoTa" runat="server" CssClass="inputta" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMoTa" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb">*</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Người nhận</span></div>

            <asp:DropDownList ID="drlNguoiNhan" runat="server" CssClass="input"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="drlNguoiNhan"
                SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">(Chọn người nhận)</asp:RequiredFieldValidator>
        </div>
        <div class="line-fix-parent-width">
            <div class="nhan"><span>Ngày gửi</span></div>

            <asp:TextBox ID="txtNgayGui" runat="server" CssClass="input" Enabled="false"></asp:TextBox>
        </div>
        <div class="line-fix-parent-width">
            <asp:Literal ID="ltrMess" runat="server" Text=""></asp:Literal>
            <asp:Button ID="btnCapNhat" runat="server" CssClass="btn" Text="Cập nhật thông tin gửi file" OnClick="btnCapNhat_Click"></asp:Button>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script type="text/javascript" src="/Admin/ckfinder/ckfinder.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnDuyet").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtDuongDan.ClientID %>').val(fileUrl);
                };
                finder.popup();
            });
        });
    </script>
</asp:Content>

