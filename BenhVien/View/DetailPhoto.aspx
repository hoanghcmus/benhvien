<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true"
    CodeFile="DetailPhoto.aspx.cs" Inherits="View_DetailPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">Hình ảnh</a></h4>
            </div>
        </div>
        <div class="product-container">
            <h3>
                <asp:Label ID="Label1" runat="server" Text="Hình ảnh"  style="color: #148f4b; font-size: 15px; margin-left: 20px;"/></h3>
            <div class="gallery">
                <asp:DataList ID="dlListimages" runat="server" RepeatColumns="3">
                    <ItemTemplate>
                        <a class="highslide" draggable="true" onclick="return hs.expand(this)" href="<%#Eval("HinhAnh")%>">
                            <img src='<%#Eval("HinhAnh")%>'><i class="iconphoto"></i> </a>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
