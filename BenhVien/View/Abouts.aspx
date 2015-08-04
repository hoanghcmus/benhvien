<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="Abouts.aspx.cs" Inherits="View_Abouts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">
                    <asp:Literal ID="ltrTieuDeLon" runat="server"></asp:Literal></a></h4>
            </div>
        </div>
        <div class="product-container">
            <asp:Repeater ID="rptBaiViet" runat="server" OnItemDataBound="rptBaiViet_ItemDataBound">
                <ItemTemplate>

                    <div class="bai-viet">
                        <h4 style="color: #148f4b; margin-top: 20px; font-weight: bold; font-size: 17px;"><%#Eval("TieuDe_Vn") %></h4>
                        <p style="color: #823501; font-size: 12px; float: left; width: 100%; margin-bottom: 10px; margin-top: 5px;"><i>Ngày tạo : </i><b><%#Eval("NgayTao") %></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>Lượt xem : </i><b><%#Eval("LuotXem") %></b></p>

                        <asp:Literal ID="ltChiTietBaiViet" runat="server"> </asp:Literal>

                    </div>

                </ItemTemplate>
            </asp:Repeater>

            <h2 class="related-title" id="bvlq" runat="server">BÀI VIẾT CÙNG THỂ LOẠI</h2>

            <asp:Repeater runat="server" ID="rptBaiVietLienQuan">
                <ItemTemplate>
                    <div class='item-bai-viet'>
                        <div class='duong-dan-bai-viet'>
                            <a href='<%#ShowArticleCat(Container.DataItem, "ArticleCatDuongDan") %>' class='link'>
                                <img src='<%#Eval("HinhAnh") %>' alt='Hình ảnh' class='img' />
                            </a>
                        </div>
                        <div class='tieu-de-bai-viet'>
                            <a href='<%#ShowArticleCat(Container.DataItem, "ArticleCatDuongDan") %>'>
                                <%#ShowArticleCat(Container.DataItem, "ArticleCatTieuDe") %>
                            </a>
                            </h4>
                                 <p class='meta'>
                                     <%#ShowArticleCat(Container.DataItem, "laytomtat") %>
                                 </p>

                        </div>
                    </div>                    
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>

