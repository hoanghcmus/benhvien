<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditVanban.aspx.cs" Inherits="Admin_EditVanban" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
                <asp:Label ID="lbTitle01" runat="server" Text="Thêm văn bản mới" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active"><a href="MgerVanBan.aspx">Quản lý văn bản</a><span
                class="divider">>></span></li>
            <li class="active">
                <asp:Label ID="lbTitle02" runat="server" Text="Thêm văn bản mới" /></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="block">
                    <p class="block-heading">
                        Thông tin văn bản
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
                                <td class="text" valign="top">Thể loại văn bản:
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlLoaiMenu" AppendDataBoundItems="true" CssClass="drl">
                                        <asp:ListItem Value="0">-- Chọn thể loại văn bản -- </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlLoaiMenu"
                                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">(Chọn thể loại văn bản)</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Số hiệu văn bản:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSoHieu" runat="server" Text="" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSoHieu"
                                        CssClass="red">( * )</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="text" valign="top">Tên văn bản:
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTieuDeVn" ControlToValidate="txtTieuDeVn" Text="(Tiêu đề < 100 ký tự)"
                                        runat="server" OnServerValidate="valTieuDeVn_ServerValidate" />
                                    <br />
                                    <asp:TextBox ID="txtTieuDeVn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNew"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTieuDeVn"
                                        CssClass="red">( * )</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Mô tả:
                                </td>
                                <td>
                                    <asp:CustomValidator ID="valTomTatVn" ControlToValidate="txtTomTatVn" Text="(Tóm tắt <300 ký tự)"
                                        runat="server" OnServerValidate="valTomTatVn_ServerValidate" />
                                    <br />
                                    <asp:TextBox ID="txtTomTatVn" runat="server" Text="" TextMode="MultiLine" CssClass="txtNewContent"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTomTatVn"
                                        CssClass="red">( * )</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="text" valign="top">Ngày ban hành:
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelNgayBanHanh" runat="server">
                                        <ContentTemplate>
                                            <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="Calendar_SelectionChanged" BorderWidth="0px" NextPrevFormat="FullMonth" OnDayRender="Calendar_DayRender">
                                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                <TitleStyle BackColor="White" Font-Bold="True" BorderColor="#3399ff" BorderWidth="1px"  Font-Size="12pt" ForeColor="#333399" />
                                                <TodayDayStyle BackColor="#CCCCCC" />
                                            </asp:Calendar>



                                            <span style="float: left; width: 100%; height: 5px;"></span>

                                            <asp:TextBox ID="txtNgayBanHanh" runat="server" Text="" CssClass="txtNewMin chose-date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNgayBanHanh"
                                                CssClass="red">( * )</asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Calendar" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr class="text">
                                <td>Văn bản:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDuongDan" runat="server" Text="" CssClass="txtNewMin"></asp:TextBox>
                                    <input id="btnDuyet" type="button" value="Duy&#7879;t file" class="btnedit" /><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDuongDan" CssClass="red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btnedit" />
                                    <input type="button" value="Đóng" class="btnedit" onclick="location.href = 'MgerVanBan.aspx'" /><br />
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
