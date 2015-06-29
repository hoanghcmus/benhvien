<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerSupport.aspx.cs" Inherits="Admin_MgerSupport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Danh sách hổ trợ" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Hổ trợ khách hàng<span class="divider"></span></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <input type="button" value="Làm mới" class="btnnew" onclick="location.href='MgerSupport.aspx'" />
                        <a href="#" class="moreHoTro">Thêm hổ trợ</a><asp:Label ID="lbtitle" runat="server"
                            Text="Label" Visible="false" CssClass="red" />
                        <br />
                        <div id="feedback">
                            <div class="well">
                                <p>
                                    Nhập thông tin hổ trợ cần thêm.
                                </p>
                                <table class="Edit">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lbrs" runat="server" Text="" Visible="false" CssClass="red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Tên liên hệ:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNhapTen" runat="server" CssClass="txt" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            SĐT:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSDT" runat="server" CssClass="txt" />
                                            <asp:CompareValidator ID="RangeValidatorSDT" runat="server" ErrorMessage="Chi nhập số"
                                                CssClass="titletb" Operator="DataTypeCheck" ControlToValidate="txtSDT" Type="Integer">&nbsp;(Chỉ nhập số)</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Email:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="titletb">(Email Không đúng)</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td">
                                        </td>
                                        <td colspan="2">
                                            <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách hổ trợ khách hàng</p>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="title1">
                                        ID
                                    </th>
                                    <th class="title2">
                                        Tên hổ trợ
                                    </th>
                                    <th class="title1">
                                        Số điện thoại
                                    </th>
                                    <th class="title1">
                                        Thông tin khác
                                    </th>
                                    <th class="title">
                                        Cập nhật
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td class="link">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="link">
                                            <asp:TextBox runat="server" ID="txtfrmTen" Text='<%#Eval("Ten")%>' CssClass="txtsmall" />
                                            <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td class="link">
                                            <asp:TextBox runat="server" ID="txtfrmSDT" Text='<%#Eval("SDT")%>' CssClass="txtsmall" />
                                        </td>
                                        <td class="link">
                                            <asp:TextBox runat="server" ID="txtfrmEmail" Text='<%#Eval("Email")%>' CssClass="txtsmall" />
                                        </td>
                                        <td class="title">
                                            <asp:Button Text="Cập nhật" runat="server" ID="btnUpdata" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Updata" CssClass="linkEditmin" />
                                            <asp:Button Text="Xóa" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Delete" CssClass="linkRemovemin" />
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td class="link">
                                            <%#Eval("ID")%>
                                        </td>
                                        <td class="link">
                                            <asp:TextBox runat="server" ID="txtfrmTen" Text='<%#Eval("Ten")%>' CssClass="txtsmall" />
                                            <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td class="link">
                                            <asp:TextBox runat="server" ID="txtfrmSDT" Text='<%#Eval("SDT")%>' CssClass="txtsmall" />
                                        </td>
                                        <td class="link">
                                            <asp:TextBox runat="server" ID="txtfrmEmail" Text='<%#Eval("Email")%>' CssClass="txtsmall" />
                                        </td>
                                        <td class="title">
                                            <asp:Button Text="Cập nhật" runat="server" ID="btnUpdata" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Updata" CssClass="linkEditmin" />
                                            <asp:Button Text="Xóa" runat="server" ID="btnDelete" CommandArgument='<%#Eval("ID")%>'
                                                CommandName="Delete" CssClass="linkRemovemin" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
