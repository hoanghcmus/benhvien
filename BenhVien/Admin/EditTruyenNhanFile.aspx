<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditTruyenNhanFile.aspx.cs" Inherits="Admin_EditTruyenNhanFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="lbTitle01" runat="server" Text="Thông tin truyền nhận file" />
                <asp:Label ID="lbModuleID" runat="server" Visible="false" />
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerTruyenNhanFile.aspx">Quản lý truyền nhận file</a><span
                class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Gủi file cho thành viên" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Thông tin truyền nhận file
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
                                <td class="text" valign="top">Người gửi:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNguoiGui" runat="server" CssClass="txtNewMin" Enabled="false"></asp:TextBox>
                                    <asp:Label ID="lbIDNguoiGui" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Tập tin
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDuongDan" runat="server" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" type="button" value="Duy&#7879;t file" class="btnedit" />
                                    <asp:LinkButton ID="down" runat="server" CssClass="tit" Text="Tải về" OnClick="down_Click"></asp:LinkButton>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDuongDan" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="text">
                                <td>Mô tả:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMoTa" runat="server" CssClass="txtNewContent" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMoTa" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr class="text">
                                <td>Người nhận:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drlNguoiNhan" runat="server" CssClass="drl"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="drlNguoiNhan"
                                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">(Chọn người nhận)</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr class="text">
                                <td>Ngày gửi:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNgayGui" runat="server" CssClass="txtNewMin" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" OnClick="btnCapNhat_Click" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href = 'MgerTruyenNhanFile.aspx'" /><br />
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

