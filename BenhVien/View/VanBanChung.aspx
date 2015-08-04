<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="VanBanChung.aspx.cs" Inherits="View_VanBanChung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">VĂN BẢN</a></h4>
            </div>
        </div>
        <div class="product-container">


            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="line-fix-parent-width">
                        <div class="lbChose">
                            <span>Lọc theo thể loại văn bản</span>
                        </div>
                        <div class="tlvb">
                            <asp:DropDownList ID="drlTheLoai" runat="server" CssClass="web-link-input" AutoPostBack="true" OnSelectedIndexChanged="drlTheLoai_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Chọn thể loại"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <table class="vbtable" cellspacing="0">
                        <thead>
                            <tr>
                                <td class="col col1"><span>Số hiệu</span></td>
                                <td class="col col2"><span>Tên văn bản</span></td>
                                <td class="col col3"><span>Ngày ban hành</span></td>
                                <td class="col col4"><span>Tải về</span></td>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:ListView ID="rptArticleList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptArticleList_DataBound" OnItemDataBound="rptArticleList_ItemDataBound">
                                <LayoutTemplate>

                                    <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <ItemTemplate>

                                    <tr>
                                        <td class="col col1 tit"><%#Eval("SoHieu")%></td>
                                        <td class="col col2"><%#Eval("TenVanBan")%></td>
                                        <td class="col col3"><%#Convert.ToDateTime(Eval("NgayBanHanh")).ToShortDateString() %></td>
                                        <td class="col col4">
                                             <asp:HyperLink ID="down" runat="server" CssClass="tit" Text="Tải về"></asp:HyperLink>
                                        </td>
                                    </tr>

                                </ItemTemplate>

                            </asp:ListView>
                        </tbody>
                    </table>

                    <div style="float: left; width: 100%; margin-top: 15px;">
                        <asp:DataPager ID="ListPager" PagedControlID="rptArticleList" runat="server" PageSize="20" OnPreRender="ListPager_PreRender" class="control-pager">
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

