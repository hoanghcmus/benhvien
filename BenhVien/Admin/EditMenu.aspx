﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="EditMenu.aspx.cs" Inherits="Admin_EditMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnDuyet").click(function () {
                var finder = new CKFinder();
                finder.selectActionFunction = function (fileUrl) {
                    $('#<%=txtHinhAnh.ClientID %>').val(fileUrl);
                };
                finder.popup();
            });
        });
    </script>
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm menu mới" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerMenu.aspx">Quản lý thể loại menu</a><span class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm menu mới" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        <asp:Label ID="lbtitle" runat="server" Text="Thêm Menu" /></p>
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
                                <td colspan="2">
                                    <h4>
                                        Nhập thông tin menu</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="title">
                                    Chọn loại menu:
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlLoadMenu"
                                                SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">(Chọn loại menu)</asp:RequiredFieldValidator>
                                            <br />
                                            <asp:DropDownList runat="server" ID="ddlLoadMenu" AppendDataBoundItems="true" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlLoadMenu_SelectedIndexChanged" CssClass="drl">
                                                <asp:ListItem Value="0">----- Chọn loại menu -----</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList runat="server" ID="ddlParent" AppendDataBoundItems="true" CssClass="drl">
                                                <asp:ListItem Value="0">--- Chọn menu cấp cha ---</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="title">
                                    Chọn loại module:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlModule"
                                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">(Chọn loại module bài viết)</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlModule" AppendDataBoundItems="true" CssClass="drl">
                                        <asp:ListItem Value="0">- Chọn loại module bài viết -</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Tiêu đề menu:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTieuDeVn"
                                        CssClass="red">(Nhập tiêu đề)</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valTieuDeVn" ControlToValidate="txtTieuDeVn" Text="(Tiêu đề < 50 ký tự)"
                                        runat="server" OnServerValidate="valTieuDeVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtTieuDeVn" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Mô tả menu:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmoTaVn"
                                        CssClass="red">(Nhập mô tả)</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="valmotaVn" ControlToValidate="txtmoTaVn" Text="(Mô tả < 150 ký tự)"
                                        runat="server" OnServerValidate="valmotaVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtmoTaVn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    <br />
                                    Đường dẫn:
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDuongDanVn"
                                        CssClass="red">(Nhập đường dẫn)</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="txtDuongDanVn" Text="(Đường dẫn < 200 ký tự)"
                                        runat="server" OnServerValidate="valDuongDanVn_ServerValidate" /><br />
                                    <asp:TextBox ID="txtDuongDanVn" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">
                                    Vị trí:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtViTri" runat="server" Text="" CssClass="txtsmall"></asp:TextBox>
                                    <asp:CompareValidator ID="RangeValidatorViTri" runat="server" CssClass="titletb"
                                        Operator="DataTypeCheck" ControlToValidate="txtViTri" Type="Integer">&nbsp;(Chỉ nhập số)</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr class="text">
                                <td valign="top">
                                    Chèn ảnh cho menu:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHinhAnh" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" onclick="BrowseServer( 'Mger_Design:/','<%=txtHinhAnh.ClientID%>');"
                                        type="button" value="Duy&#7879;t file" class="btnedit" />
                                </td>
                            </tr>
                         <%--   <tr class="text">
                                <td>
                                    Thêm hiển thị menu cuối website:
                                </td>
                                <td>
                                    <asp:CheckBox ID="ckbFooter" runat="server" Text="Có" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu menu" CssClass="btnedit" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href='MgerMenu.aspx'" /><br />
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
