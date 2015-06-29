<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_ShowPhoto.ascx.cs" Inherits="UserControl_UC_ShowPhoto" %>

<div class="flexslider">
    <ul class="slides">
        <asp:Repeater ID="repslideshow" runat="server">
            <ItemTemplate>
                <li>
                    <img src="<%#Eval("HinhAnh") %>" alt="<%#Eval("TieuDe_Vn") %>" /></li>
            </ItemTemplate>
        </asp:Repeater>

    </ul>
</div>
