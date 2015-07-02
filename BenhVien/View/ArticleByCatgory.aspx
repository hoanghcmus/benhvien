﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="ArticleByCatgory.aspx.cs" Inherits="En_ArticleByCatgory" %>

<%@ Import Namespace="DataAccess.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Styles/CSS/Desktop.Module.css" rel="stylesheet" />
    <link href="/Styles/CSS/SmartPhone.Module.css" rel="stylesheet" />
    <link href="/Styles/CSS/Tablet.Module.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">

    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4>
                    <asp:Literal ID="ltrCtTitle" runat="server"></asp:Literal></h4>
            </div>
        </div>
        <div class="product-container">
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
                                    <strong>Mô tả:</strong>
                                    <%#ShowArticleCat(Container.DataItem, "laytomtat") %>
                                </p>

                                </div>
                            </div>


                        </ItemTemplate>
                    </asp:ListView>

                    <div style="float: left; width: 100%;">
                        <asp:DataPager ID="ListPager" PagedControlID="rptArticleList" runat="server" PageSize="30" OnPreRender="ListPager_PreRender" class="control-pager">
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

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
