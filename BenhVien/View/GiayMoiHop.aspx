<%@ Page Title="" Language="C#" MasterPageFile="~/View/ThanhVien.master" AutoEventWireup="true" CodeFile="GiayMoiHop.aspx.cs" Inherits="View_GiayMoiHop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:ListView ID="rptArticleList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptArticleList_DataBound">
                <LayoutTemplate>

                    <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>

                    <div class="item-bai-viet">
                        <div class="duong-dan-bai-viet">
                            <a href='<%#ShowArticleCat(Container.DataItem, "ArticleCatDuongDan") %>'>
                                <img src="<%#Eval("HinhAnh") %>" alt="Hình ảnh" class="img" />
                                </i></a>
                        </div>
                        <div class="tieu-de-bai-viet">
                            <a href='<%#ShowArticleCat(Container.DataItem, "ArticleCatDuongDan") %>'>
                                <%#ShowArticleCat(Container.DataItem, "ArticleCatTieuDe") %></a>
                            </h4>
                                <p class="meta">
                                    <%--<strong>Mô tả:</strong>--%>
                                    <%#ShowArticleCat(Container.DataItem, "laytomtat") %>
                                </p>

                        </div>
                    </div>


                </ItemTemplate>
            </asp:ListView>

            <div style="float: left; width: 100%;">
                <asp:DataPager ID="ListPager" PagedControlID="rptArticleList" runat="server" PageSize="18" OnPreRender="ListPager_PreRender" class="control-pager">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" PreviousPageText="Trước" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" NextPageText="Sau" />
                        <asp:TemplatePagerField></asp:TemplatePagerField>
                    </Fields>
                </asp:DataPager>
            </div>

        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ListPager" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

