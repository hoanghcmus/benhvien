<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Search.ascx.cs" Inherits="UserControl_UC_Search" %>
<div class="header-search">
    <input type="text" id="txtTimKiem" name="keyword" class="search-box" placeholder="Tìm kiếm ..." runat="server" />
    <div class="search-button">

        <asp:Button runat="server" CssClass="tim-kiem" ID="btnTimKiem" />
    </div>

</div>
