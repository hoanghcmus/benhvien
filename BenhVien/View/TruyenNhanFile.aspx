<%@ Page Title="" Language="C#" MasterPageFile="~/View/ThanhVien.master" AutoEventWireup="true" CodeFile="TruyenNhanFile.aspx.cs" Inherits="View_TruyenNhanFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lbID" runat="server" Visible="false"></asp:Label>
                <div class="line-fix-parent-width">
                    <div class="lbChose">
                        <span>Lọc theo nhận/gửi</span>
                    </div>
                    <div class="tlvb">
                        <asp:DropDownList ID="drlNhanGui" runat="server" CssClass="web-link-input" AutoPostBack="true" OnSelectedIndexChanged="drlNhanGui_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Chọn điều kiện"></asp:ListItem>
                            <asp:ListItem Value="1" Text="File đã nhận"></asp:ListItem>
                            <asp:ListItem Value="2" Text="File gửi đi"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:HyperLink ID="lnkGuiFile" runat="server" CssClass="down">Gửi file</asp:HyperLink>

                </div>
                <table class="vbtable" cellspacing="0">
                    <thead>
                        <tr>
                            <td class="col col1"><span>Người gửi</span></td>
                            <td class="col col3"><span>Tập tin</span></td>
                            <td class="col col2"><span>Mô tả</span></td>
                            <td class="col col4"><span>Ngày gửi</span></td>
                            <td class="col"><span>Sửa</span></td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="rptArticleList" runat="server" ItemPlaceholderID="ItemPlaceholderIDArticleList" OnDataBound="rptArticleList_DataBound" OnItemDataBound="rptArticleList_ItemDataBound">
                            <LayoutTemplate>

                                <asp:PlaceHolder runat="server" ID="ItemPlaceholderIDArticleList"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>

                                <tr>
                                    <td class="col col1"><%#Eval("TenThanhVienGui") %></td>
                                    <td class="col col3">
<<<<<<< HEAD
                                        <asp:LinkButton ID="down" runat="server" CssClass="tit" Text="Tải về" OnClick="down_Click"></asp:LinkButton>
=======
                                        <asp:HyperLink ID="down" runat="server" CssClass="tit" Text="Tải về"></asp:HyperLink>
>>>>>>> 642fe2eeb6d7f9e65a3bcdbd2ead2a9e4895a454
                                    </td>
                                    <td class="col col2"><%#Eval("MoTa") %></td>
                                    <td class="col col4"><%#Eval("NgayGui") %></td>
                                    <td class="col col5">
                                        <%#ShowInfo(Container.DataItem, "chinhsua") %>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

