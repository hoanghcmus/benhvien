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

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <asp:ListView ID="rptArticleList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptArticleList_DataBound">
                            <LayoutTemplate>

                                <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="search-retult-line">
                                    <a href='<%#ShowInfo(Container.DataItem, "hienthilink")%>'>
                                        <%#ShowInfo(Container.DataItem, "hienthinoidung")%>

                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>

                        <asp:DataPager ID="ListPager" PagedControlID="rptArticleList" runat="server" PageSize="50" OnPreRender="ListPager_PreRender" class="control-pager">
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
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

