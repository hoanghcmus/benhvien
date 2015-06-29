<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_HoiDap.ascx.cs" Inherits="UserControl_UC_HoiDap" %>

<asp:Repeater ID="rptHoiDap" runat="server">
    <ItemTemplate>
        <li class=" link"><a href="<%#Showinfo(Container.DataItem,"hienthilink") %>">
            <%#Eval("NoiDungHoi") %>
        </a></li>
    </ItemTemplate>
</asp:Repeater>
