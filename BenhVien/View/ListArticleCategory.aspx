<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="ListArticleCategory.aspx.cs" Inherits="View_ListArticleCategory" %>

<%@ Import Namespace="DataAccess.Help" %>
<asp:Content ID="HeadExtender" ContentPlaceHolderID="head" runat="Server">
    <link href="/Styles/CSS/Desktop.Module.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">

    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4>
                    <asp:Literal ID="ltrCtTitle" runat="server"></asp:Literal></h4>
            </div>
        </div>
        <div class="product-container">
            <div class="image-cat-block">
                <div class="image-cat-block-warpper">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                        <ContentTemplate>



                            <asp:ListView ID="rptCatList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptCatList_DataBound">
                                <LayoutTemplate>

                                    <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>


                                    <div class="cat-block">

                                        <div class="cat-block-pic">
                                            <a href="<%#Eval("DuongDan_Vn") %>">
                                                <img src="<%#Eval("HinhAnh") %>" alt="<%#Eval("TieuDe_Vn") %>" />
                                            </a>
                                        </div>


                                        <div class="cat-block-title">
                                            <p><a href="<%#Eval("DuongDan_Vn") %>"><%#Eval("TieuDe_Vn") %></a></p>
                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:ListView>



                            <asp:DataPager ID="ListPager" PagedControlID="rptCatList" runat="server" PageSize="20" OnPreRender="ListPager_PreRender" class="control-pager">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" PreviousPageText="Trước" />
                                    <asp:NumericPagerField ButtonType="Link" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" NextPageText="Sau" />
                                    <asp:TemplatePagerField></asp:TemplatePagerField>
                                </Fields>
                            </asp:DataPager>
                        </ContentTemplate>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ListPager" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="FootExtender" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

