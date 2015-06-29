<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="View_Article" %>

<%@ Register Src="/UserControl/UC_Paging.ascx" TagName="UC_Paging" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <meta itemprop="image" content="../Design/lau-thai.jpg" />
    <meta itemprop="headline" content="Răng sứ No 1" />
    <meta property="og:site_name" content="Các dịch vụ nha khoa thẩm mỹ" />
    <meta property="og:type" content="article" />
    <meta property="og:url" content="http://www.rangsunoo1.vn/" />
    <meta property="og:title" itemprop="headline" content="Răng sứ No 1, nụ cười hạnh phúc" />
    <meta property="og:description" content="Đến với trung tâm nha khoa Răng sứ No 1, quý khách sẽ có được nụ cười tươi và một sức khỏe răng miệng tốt" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="article-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </a></h4>
            </div>
        </div>
        <div class="article-container">


            <asp:Label ID="lbtl" runat="server" CssClass="titlecategory" Visible="false" Text="Không tìm thấy bài viết!" />
            <asp:Repeater ID="dlProdList" runat="server">
                <ItemTemplate>

                    <div class="article-box">
                        <div class="article-pic">
                            <a href='<%#DataAccess.Connect.Link.DetailArticle(Eval("TieuDe_Vn").ToString(),Eval("ID").ToString()) %>'>
                                <img src='<%#DataAccess.Connect.Link.Toimages(Eval("HinhAnh").ToString())%>' alt="Product Pic Here" />
                            </a>
                        </div>
                        <div class="article-name link">
                            <p><a href='<%#DataAccess.Connect.Link.DetailArticle(Eval("TieuDe_Vn").ToString(),Eval("ID").ToString()) %>'><%#HttpUtility.HtmlEncode(Eval("TieuDe_Vn").ToString()) %></a></p>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

            <uc2:UC_Paging ID="pagerBottom" runat="server" />

        </div>
    </div>


</asp:Content>

