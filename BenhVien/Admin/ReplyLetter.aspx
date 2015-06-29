<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ReplyLetter.aspx.cs" Inherits="Admin_ReplyLetter" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content">
        <div class="header">
            <h1 class="page-title">

                <asp:Label ID="Label1" runat="server" Text="Trả lời thư liên hệ " />
                (ID:
                <asp:Label ID="lbHoiDapId" runat="server" Text="-10"></asp:Label>)
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Trả lời thư liên hệ<span class="divider">>></span></li>
        </ul>

        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">

                    <div class="toolbar">
                        <table class="Edit">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbMessage" runat="server" Text="" CssClass="red" />
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Thông tin khách hàng:
                                </td>
                                <td class="text" valign="top">
                                    <asp:Label ID="lbThongTinKhachHang" runat="server" Text="Nguyễn Ngọc Hoang - hoanghcmus@gmail.com  - gửi ngày 28-01-2015"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Nội dung liên hệ:
                                </td>
                                <td>

                                    <asp:TextBox ID="txtNoiDungHoi" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewContent"></asp:TextBox>

                                </td>
                            </tr>

                            <tr class="text">
                                <td colspan="2">Trả lời thư<br />
                                    <CKEditor:CKEditorControl ID="txtNoiDungDap" runat="server" Height="270px" CssClass="txteditor" Text="hoanghcmus">
                                    </CKEditor:CKEditorControl>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTraLoi" runat="server" ErrorMessage="Không được bỏ trống phần trả lời" ControlToValidate="txtNoiDungDap"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" OnClick="btnLuu_Click" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href = 'MgerLetter.aspx?Status=0'" /><br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>

