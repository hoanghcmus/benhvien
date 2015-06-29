<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master"  AutoEventWireup="true" CodeFile="Abouts.aspx.cs" Inherits="View_Abouts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">

    <asp:Repeater ID="rptBaiViet" runat="server" OnItemDataBound="rptBaiViet_ItemDataBound">
        <ItemTemplate>
            <div class="product-wrapper">
                <div class="product-header">
                    <div class="product-title">
                        <h4><a href="javascript:void(0);"><%#ShowInfo(Container.DataItem, "tieudelon") %></a></h4>
                    </div>
                </div>
                <div class="product-container">
                    <div class="bai-viet">
                        <h4 style="color: #148f4b; margin-top: 20px; "><%#Eval("TieuDe_Vn") %></h4>
                        <p style="color: #823501; font-size: 12px; float: left; width: 100%; margin-bottom:10px; margin-top: 5px;"><i>Ngày tạo : </i><b><%#Eval("NgayTao") %></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>Lượt xem : </i><b><%#Eval("LuotXem") %></b></p>

                        <asp:Literal ID="ltChiTietBaiViet" runat="server"> </asp:Literal>
                       
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    
</asp:Content>

