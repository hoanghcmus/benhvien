<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/View/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="ContentMainPageProduct" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <%-- Khối tin tức đầu tiên --%>
    <div class="inside-full">
        <div class="inside-left">
            <div class="inside-left-wrap">
                <div class="khoi-tin-lon">
                    <div class="tin-lon-figure">
                        <asp:Image ID="imgTinLonFigure" runat="server" class="img" />
                    </div>
                    <div class="tin-lon-tieu-de">
                        <h1>
                            <asp:HyperLink ID="hlTinLonTieuDe" runat="server" CssClass="link"></asp:HyperLink>
                        </h1>
                    </div>
                    <div class="tin-lon-mo-ta">
                        <p>
                            <asp:Literal ID="ltrTinLonMoTa" runat="server"></asp:Literal>
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

                    <asp:Repeater ID="rptTinTucLienQuan" runat="server">
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
                    </asp:Repeater>

                </div>
            </div>
        </div>
    </div>

    <%-- Khổi quy chế, quy định --%>
    <div class="inside-full">
        <div class="khoi1">
            <div class="khoi1-tieu-de">
                <h1>QUY ĐỊNH, QUY CHẾ</h1>
            </div>
            <div class="khoi1-noi-dung">
                <div class="inside-left">
                    <div class="khoi-wrap1">

                        <asp:Repeater ID="rptQuyCheItemNgang" runat="server">
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
                        </asp:Repeater>

                    </div>
                </div>

                <div class="inside-right">
                    <div class="qnav">
                        <ul>

                            <asp:Repeater ID="rptQuyCheLienQuan" runat="server">
                                <ItemTemplate>

                                    <li>
                                        <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                            <span>
                                                <img src="/Design/gplus.png" alt="Plus" class="img" /></span>
                                            <span><%#Eval("TieuDe_Vn") %></span>
                                        </a>
                                    </li>

                                </ItemTemplate>
                            </asp:Repeater>

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
                    <h1>THÔNG TIN Y DƯỢC</h1>
                </div>
                <div class="khoi1-noi-dung">
                    <div class="khoi-wrap1">

                        <div class="line-fix-parent-width">

                            <asp:Repeater ID="rptThongTinYItemDoc" runat="server">
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
                            </asp:Repeater>

                        </div>

                        <div class="tin-lien-quan-ngang">
                            <div class="tin-lien-quan-ngang-tieu-de">
                                <h1>Tin tức liên quan</h1>
                            </div>

                            <div class="qnav">
                                <ul>

                                    <asp:Repeater ID="rptThongTinYLienQuan" runat="server">
                                        <ItemTemplate>

                                            <li>
                                                <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                                    <span>
                                                        <img src="/Design/gplus.png" alt="Plus" class="img" /></span>
                                                    <span><%#Eval("TieuDe_Vn") %></span>
                                                </a>
                                            </li>

                                        </ItemTemplate>
                                    </asp:Repeater>

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
                        <h1>THÔNG BÁO</h1>
                    </div>
                </div>
                <div class="khoi-noi-dung">
                    <div class="khoi-noi-dung-wrap">
                        <div class="qnav tnav">
                            <ul>

                                <asp:Repeater ID="rptThongBao" runat="server">
                                    <ItemTemplate>

                                        <li>
                                            <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                                <span>
                                                    <img src="/Design/gcirle.png" alt="Plus" class="img" /></span>
                                                <span><%#Eval("TieuDe_Vn") %></span>
                                            </a>
                                        </li>


                                    </ItemTemplate>
                                </asp:Repeater>

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
                    <h1>THÔNG TIN Y KHOA, Y HỌC THƯỜNG THỨC</h1>
                </div>
                <div class="khoi1-noi-dung">
                    <div class="khoi-wrap1">

                        <div class="line-fix-parent-width">

                            <asp:Repeater ID="rptYHocThuongThucItemNgang" runat="server">
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
                            </asp:Repeater>

                        </div>

                        <div class="tin-lien-quan-ngang">

                            <div class="qnav">
                                <ul>

                                    <asp:Repeater ID="rptYHocThuongThucLienQuan" runat="server">
                                        <ItemTemplate>

                                            <li>
                                                <a href="<%#ShowInfo(Container.DataItem,"lienket") %>" class="link">
                                                    <span>
                                                        <img src="/Design/gplus.png" alt="Plus" class="img" /></span>
                                                    <span><%#Eval("TieuDe_Vn") %></span>
                                                </a>
                                            </li>

                                        </ItemTemplate>
                                    </asp:Repeater>

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
                            <h1>LIÊN KẾT WEBSITE</h1>
                        </div>
                    </div>
                    <div class="khoi-noi-dung">
                        <div class="web-link">
                            <asp:DropDownList ID="drlLienKetWebsite" runat="server" CssClass="web-link-input" AutoPostBack="true" OnSelectedIndexChanged="drlLienKetWebsite_SelectedIndexChanged">
                                <%--<asp:ListItem Value="0" Text="Chọn liên kết"></asp:ListItem>--%>
                            </asp:DropDownList>
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

