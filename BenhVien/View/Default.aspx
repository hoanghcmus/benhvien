<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/View/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Redirect() {
            var ddlLinks = document.getElementById('<%=drlLienKetWebsite.ClientID%>');
            var selectedval = ddlLinks.options[ddlLinks.selectedIndex].value;
            if (selectedval != '0') {
                window.open(selectedval, '_blank');
            };
        }
    </script>
</asp:Content>
<asp:Content ID="ContentMainPageProduct" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <%-- Khối tin tức đầu tiên --%>
    <div class="inside-full">
        <div class="inside-left">
            <div class="inside-left-wrap">
                <div class="khoi-tin-lon">
                    <div class="tin-lon-figure">
                        <asp:image id="imgTinLonFigure" runat="server" class="img" />
                    </div>
                    <div class="tin-lon-tieu-de">
                        <h1>
                            <asp:hyperlink id="hlTinLonTieuDe" runat="server" cssclass="link"></asp:hyperlink>
                        </h1>
                    </div>
                    <div class="tin-lon-mo-ta">
                        <p>
                            <asp:literal id="ltrTinLonMoTa" runat="server"></asp:literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="inside-right">
            <div class="khoi-tin-lien-quan">
                <div class="tin-lien-quan-tieu-de">
                    <h1>Tin tức liên quan</h1>
                </div>
                <div class="tin-lien-quan-noi-dung">

                    <asp:repeater id="rptTinTucLienQuan" runat="server">
                        <ItemTemplate>
                            <div class="tin-lien-quan-item">
                                <div class="item-lien-quan-figure">
                                    <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                        <img src="<%#Eval("HinhAnh") %>" alt="Tin liên quan" class="img" />
                                    </a>
                                </div>
                                <div class="item-lien-quan-tieu-de">
                                    <h1><a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link"><%#Eval("TieuDe_Vn") %></a></h1>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:repeater>

                </div>
            </div>
        </div>
    </div>

    <%-- Khổi quy chế, quy định --%>
    <div class="inside-full">
        <div class="khoi1">
            <div class="khoi1-tieu-de">
                <div class="tieu-de-wrap">
                    <span class="tieu-de-icon">
                        <img src="/Design/plus.png" alt="Icon title" class="img" />
                    </span>
                    <h1>QUY ĐỊNH, QUY CHẾ</h1>
                </div>
            </div>
            <div class="khoi1-noi-dung">
                <div class="inside-left">
                    <div class="khoi-wrap1">

                        <asp:repeater id="rptQuyCheItemNgang" runat="server">
                            <ItemTemplate>
                                <div class="item-ngang">
                                    <div class="item-ngang-figure">
                                        <img src="<%#Eval("HinhAnh") %>" alt="Hinh anh" class="img" />
                                    </div>
                                    <div class="item-ngang-content">
                                        <div class="item-ngang-tieu-de">
                                            <h1><a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link"><%#Eval("TieuDe_Vn") %></a></h1>
                                        </div>
                                        <div class="item-ngang-mo-ta">
                                            <p>
                                                <%#Eval("TomTat_Vn") %>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:repeater>

                    </div>
                </div>

                <div class="inside-right">
                    <div class="qnav">
                        <ul>

                            <asp:repeater id="rptQuyCheLienQuan" runat="server">
                                <ItemTemplate>

                                    <li>
                                        <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                            <span>
                                                <img src="/Design/gplus.png" alt="Plus" class="img" /></span>
                                            <span><%#Eval("TieuDe_Vn") %></span>
                                        </a>
                                    </li>

                                </ItemTemplate>
                            </asp:repeater>

                        </ul>
                    </div>
                </div>

            </div>
        </div>
    </div>


    <%-- Khối thông tin y dược --%>
    <div class="inside-full">
        <div class="inside-left">

            <div class="khoi1">
                <div class="khoi1-tieu-de">
                    <div class="tieu-de-wrap">
                        <span class="tieu-de-icon">
                            <img src="/Design/plus.png" alt="Icon title" class="img" />
                        </span>
                        <h1>THÔNG TIN Y DƯỢC</h1>
                    </div>
                </div>
                <div class="khoi1-noi-dung">
                    <div class="khoi-wrap1">

                        <div class="line-fix-parent-width">

                            <asp:repeater id="rptThongTinYItemDoc" runat="server">
                                <ItemTemplate>

                                    <div class="item-doc">
                                        <div class="item-doc-figure">
                                            <img src="<%#Eval("HinhAnh") %>" alt="Hinh anh" class="img" />
                                        </div>
                                        <div class="item-doc-tieu-de">
                                            <h1><a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link"><%#Eval("TieuDe_Vn") %></a></h1>
                                        </div>
                                        <div class="item-doc-mo-ta">
                                            <p>
                                                <%#Eval("TomTat_Vn") %>
                                            </p>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:repeater>

                        </div>

                        <div class="tin-lien-quan-ngang">
                            <div class="tin-lien-quan-ngang-tieu-de">
                                <h1>Tin tức liên quan</h1>
                            </div>

                            <div class="qnav">
                                <ul>

                                    <asp:repeater id="rptThongTinYLienQuan" runat="server">
                                        <ItemTemplate>

                                            <li>
                                                <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                                    <span>
                                                        <img src="/Design/gplus.png" alt="Plus" class="img" /></span>
                                                    <span><%#Eval("TieuDe_Vn") %></span>
                                                </a>
                                            </li>

                                        </ItemTemplate>
                                    </asp:repeater>

                                </ul>
                            </div>


                        </div>

                    </div>
                </div>
            </div>

        </div>
        <div class="inside-right">
            <div class="khoi1">

                <div class="khoi-tieu-de">
                    <div class="gach-ngang"></div>
                    <div class="nga-mau"></div>
                    <div class="tieu-de">
                        <h1>
                            <img src="/Design/thongbao.png" class="block-heder-icon" alt="icon" />
                            THÔNG BÁO

                        </h1>
                    </div>
                </div>
                <div class="khoi-noi-dung">
                    <div class="khoi-noi-dung-wrap">
                        <div class="qnav tnav">
                            <ul>

                                <asp:repeater id="rptThongBao" runat="server">
                                    <ItemTemplate>

                                        <li>
                                            <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                                <span>
                                                    <img src="/Design/gcirle.png" alt="Plus" class="img" /></span>
                                                <span><%#Eval("TieuDe_Vn") %></span>
                                            </a>
                                        </li>


                                    </ItemTemplate>
                                </asp:repeater>

                            </ul>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>

    <%-- KHối tin y khoa, y học thường thức --%>
    <div class="inside-full">
        <div class="inside-left">

            <div class="khoi1">
                <div class="khoi1-tieu-de">
                    <div class="tieu-de-wrap">
                        <span class="tieu-de-icon">
                            <img src="/Design/plus.png" alt="Icon title" class="img" />
                        </span>
                        <h1>TIN Y KHOA, Y HỌC THƯỜNG THỨC</h1>
                    </div>
                </div>
                <div class="khoi1-noi-dung">
                    <div class="khoi-wrap1">

                        <div class="line-fix-parent-width">

                            <asp:repeater id="rptYHocThuongThucItemNgang" runat="server">
                                <ItemTemplate>

                                    <div class="item-ngang">
                                        <div class="item-ngang-figure">
                                            <img src="<%#Eval("HinhAnh") %>" alt="Hinh anh" class="img" />
                                        </div>
                                        <div class="item-ngang-content">
                                            <div class="item-ngang-tieu-de">
                                                <h1><a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="line"><%#Eval("TieuDe_Vn") %></a></h1>
                                            </div>
                                            <div class="item-ngang-mo-ta">
                                                <p>
                                                    <%#Eval("TomTat_Vn") %>
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:repeater>

                        </div>

                        <div class="tin-lien-quan-ngang">

                            <div class="qnav">
                                <ul>

                                    <asp:repeater id="rptYHocThuongThucLienQuan" runat="server">
                                        <ItemTemplate>

                                            <li>
                                                <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                                    <span>
                                                        <img src="/Design/gplus.png" alt="Plus" class="img" /></span>
                                                    <span><%#Eval("TieuDe_Vn") %></span>
                                                </a>
                                            </li>

                                        </ItemTemplate>
                                    </asp:repeater>

                                </ul>
                            </div>


                        </div>

                    </div>
                </div>
            </div>

        </div>
        <div class="inside-right">
            <div class="khoi1">
                <div class="khoi">
                    <div class="khoi-tieu-de">
                        <div class="gach-ngang"></div>
                        <div class="nga-mau"></div>
                        <div class="tieu-de">
                            <h1>
                                <img src="/Design/lienket.png" class="block-heder-icon" alt="icon" />
                                LIÊN KẾT WEBSITE

                            </h1>
                        </div>
                    </div>
                    <div class="khoi-noi-dung">
                        <div class="web-link">
                            <asp:dropdownlist id="drlLienKetWebsite" runat="server" cssclass="web-link-input">
                                <%--<asp:ListItem Value="0" Text="Chọn liên kết"></asp:ListItem>--%>
                            </asp:dropdownlist>
                        </div>
                    </div>
                </div>

                <div class="khoi">


                    <div class="banner-lien-ket">
                        <a href="/hoi-dap.html" class="link">
                            <img src="/Design/hoidap.png" alt="Anh banner" class="img" />
                        </a>
                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>

