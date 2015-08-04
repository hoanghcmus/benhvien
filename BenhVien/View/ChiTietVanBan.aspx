<%@ Page Title="" Language="C#" MasterPageFile="~/View/ThanhVien.master" AutoEventWireup="true" CodeFile="ChiTietVanBan.aspx.cs" Inherits="View_ChitTietVanBan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <asp:Repeater ID="rptBaiViet" runat="server" OnItemDataBound="rptBaiViet_ItemDataBound">
        <ItemTemplate>
            <div class="product-wrapper">
                <div class="bai-viet">
                    <h4 style="color: #148f4b; margin-top: 20px; font-weight: bold; font-size: 17px;"><%#Eval("TieuDe_Vn") %></h4>
                    <p style="color: #823501; font-size: 12px; float: left; width: 100%; margin-bottom: 10px; margin-top: 5px;"><i>Ngày tạo : </i><b><%#Eval("NgayTao") %></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>Lượt xem : </i><b><%#Eval("LuotXem") %></b></p>

                    <asp:Literal ID="ltChiTietBaiViet" runat="server"> </asp:Literal>

                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

