<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MgerVanBan.aspx.cs" Inherits="Admin_MgerVanBan" %>


<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Datatables/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có trạng thái văn bản" />
                <asp:Label ID="lbModuleID" runat="server" Visible="false" />
            </h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý văn bản<span class="divider">>></span></li>
            <li class="active">Danh sách văn bản</li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">
                    <div class="toolbar">
                        <div>
                            <asp:DropDownList runat="server" ID="ddlTheLoai" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged" CssClass="drl">
                                <asp:ListItem>-- Chọn xem theo thể loại -- </asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="drl">
                                <asp:ListItem>-- Chọn xem quản lý bản tin -- </asp:ListItem>
                                <asp:ListItem Value="0">Danh sách bản tin đợi duyệt</asp:ListItem>
                                <asp:ListItem Value="1">Danh sách bản tin đã đăng</asp:ListItem>
                                <asp:ListItem Value="2">Danh sách bản tin cấm đăng</asp:ListItem>
                            </asp:DropDownList>--%>
                        </div>
                    </div>
                    <hr />
                    <div class="content_mid">
                        <input type="button" value="Thêm văn bản" class="btnedit" onclick="location.href = 'EditVanBan.aspx'" />
                        <asp:Button Text="Xóa văn bản đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <%--<asp:Button Text="Đăng văn bản đã chọn" runat="server" ID="btnDang" CssClass="execuChek"
                            Visible="False" OnClick="btnDang_Click" />
                        <asp:Button Text="Cấm Đăng văn bản đã chọn" runat="server" ID="btnCamDang" CssClass="execuChek"
                            Visible="False" OnClick="btnCamDang_Click" />--%>
                        |&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" CssClass="txtsreach" />
                        <asp:Button Text=" Tìm" runat="server" ID="btnTimKiem" CssClass="btnsreach" />
                        <input type="button" value="Làm mới" class="btnedit" onclick="location.href = 'MgerVanBan.aspx'" />
                        <div class="block">
                            <p class="block-heading">
                                Danh sách văn bản
                            </p>
                            <table class="list" id="dttb">
                                <thead>
                                    <tr>
                                        <th class="id">
                                            <input type="checkbox" id="chkAll" />
                                        </th>
                                        <th class="smallmax">Số hiệu văn bản
                                        </th>
                                        <th class="titlemax">Tên văn bản
                                        </th>
                                        <th class="smallmax">Ngày ban hành
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
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <%#Eval("SoHieu")%>
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TenVanBan")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Convert.ToDateTime(Eval("NgayBanHanh")).ToShortDateString() %>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='EditVanban.aspx?ID=<%#Eval("ID") %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <ItemTemplate>
                                        <tr class="evenbottom">
                                            <td class="id">
                                                <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                            </td>
                                            <td align="center">
                                                <%#Eval("SoHieu")%>
                                            </td>
                                            <td class="titlemax" valign="top">
                                                <%#Eval("TenVanBan")%>
                                            </td>
                                            <td class="smallmax">
                                                <%#Convert.ToDateTime(Eval("NgayBanHanh")).ToShortDateString() %>
                                            </td>
                                            <td class="id">
                                                <%#Eval("ID")%>
                                            </td>
                                            <td class="idmax">
                                                <a href='EditVanban.aspx?ID=<%#Eval("ID") %>' class='lnk'>
                                                    <i class="icon-pencil"></i></a>
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
    <script type="text/javascript" src="../Styles/Datatables/jquery.dataTables.min.js"></script>
    <script src="../Styles/Datatables/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dttb').DataTable({

            });
        });
    </script>
</asp:Content>
