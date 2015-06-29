<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MgerLetter.aspx.cs" Inherits="Admin_MgerLetter" %>

<%@ Register Src="Mger_UserControl/UC_PhanTrang.ascx" TagName="UC_PhanTrang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {
            $("input.traloithu").click(function () {
                var n = $("table.list input:checkbox[name$=cid]:checked").length;
                if (n == 0) {
                    alert('Vui lòng chọn thư cần trả lời!');
                    return false;
                }

            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="header">
            <h1 class="page-title">
                <asp:Label ID="Label1" runat="server" Text="Không có thư nào!" /></h1>
        </div>
        <ul class="breadcrumb">
            <li><a href="Admin.aspx">Trang chủ</a> <span class="divider">>></span></li>
            <li class="active">Quản lý Ý kiến thực khách<span class="divider">>></span></li>
        </ul>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="content_right">



                    <div class="toolbar">
                        <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="drl">
                            <asp:ListItem>--Chọn xem quản lý ý kiến-- </asp:ListItem>
                            <asp:ListItem Value="0">Danh sách ý kiến đợi duyệt</asp:ListItem>
                            <asp:ListItem Value="1">Danh sách ý kiến đã duyệt</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button Text="Xóa ý kiến đã chọn" runat="server" ID="btnDelete" CssClass="multidelete" />
                        <asp:Button Text="Trả lời thư đã chọn" runat="server" ID="btnTraLoi" CssClass="traloithu" PostBackUrl="~/Admin/ReplyLetter.aspx" />
                    </div>
                    <div class="block">
                        <p class="block-heading">
                            Danh sách ý kiến thực khách
                        </p>
                        <div class="helpDatHang">
                            Chú ý: <span class="red">Chữ đỏ: Ý kiến chưa được duyệt </span><span>Chữ thường: Ý kiến
                                đã được duyệt</span>
                        </div>
                        <table class="list">
                            <thead>
                                <tr>
                                    <th class="cid">
                                        <input type="checkbox" id="chkAll" />
                                    </th>
                                    <th class="titlemax">Họ tên
                                    </th>
                                    <th class="titlemax">Ngày gửi
                                    </th>
                                    <th class="id">ID
                                    </th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repProd">
                                <AlternatingItemTemplate>
                                    <tr class="eventop">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="titlemax">
                                            <%#ShowContact(Container.DataItem, "HoTen")%>
                                        </td>
                                        <td class="titlemax">
                                            <%#ShowContact(Container.DataItem, "NgayGui")%>
                                        </td>
                                        <td class="id">
                                            <%#ShowContact(Container.DataItem, "ID")%>
                                        </td>
                                    </tr>
                                    <tr class="eventop">
                                        <td colspan="5">
                                            <strong>Địa chỉ</strong> &nbsp;&nbsp;&nbsp;:&nbsp;
                                            <%#Eval("DiaChi")%><br />
                                            <strong>Nội dung hỏi :&nbsp;</strong>
                                            <%#Eval("NoiDungHoi")%>
                                            <br />
                                            <strong>Trả lời :&nbsp;</strong>
                                            <%#Regex.Replace(Eval("NoiDungDap").ToString(),"<img.*>","")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5"></td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <tr class="evenbottom">
                                        <td>
                                            <input type="checkbox" name='cid' value='<%#Eval("ID") %>' />
                                        </td>
                                        <td class="titlemax">
                                            <%#ShowContact(Container.DataItem, "HoTen")%>
                                        </td>
                                        <td class="titlemax">
                                            <%#ShowContact(Container.DataItem, "NgayGui")%>
                                        </td>
                                        <td class="id">
                                            <%#ShowContact(Container.DataItem, "ID")%>
                                        </td>
                                    </tr>
                                    <tr class="evenbottom">
                                        <td colspan="5">
                                            <strong>Địa chỉ</strong> &nbsp;&nbsp;&nbsp;:&nbsp;
                                            <%#Eval("DiaChi")%><br />
                                            <strong>Nội dung hỏi :&nbsp;</strong>
                                            <%#Eval("NoiDungHoi")%>
                                            <br />
                                            <strong>Trả lời :&nbsp;</strong>
                                            <%#Regex.Replace(Eval("NoiDungDap").ToString(),"<img.*>","")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5"></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <uc1:UC_PhanTrang ID="PagerBottom" runat="server" />
                </div>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
