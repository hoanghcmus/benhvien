<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="View_Search" %>

<%@ Register Src="../UserControl/UC_Paging.ascx" TagName="UC_Paging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">KẾT QUẢ TÌM KIẾM</a></h4>
            </div>
        </div>
        <div class="product-container">
            <div class="qa">
                <asp:Label ID="lbMessage" runat="server">

                </asp:Label>
                <asp:Repeater ID="rptTimKiem" runat="server">
                    <ItemTemplate>
                        <div class="search-retult-line">
                            <a href='<%#ShowInfo(Container.DataItem, "hienthilink")%>'>
                                <%#ShowInfo(Container.DataItem, "hienthinoidung")%>

                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>



                <uc1:UC_Paging ID="pagerBottom" runat="server" />

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

