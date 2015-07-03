<%@ Page Title="" Language="C#" MasterPageFile="~/View/ThanhVien.master" AutoEventWireup="true" CodeFile="VanBan.aspx.cs" Inherits="View_VanBan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
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
                <tr>
                    <td class="col col1 tit">821/KHLT-PGDĐT-CĐGD</td>
                    <td class="col col2">Kế hoạch Thực hiện cuộc vận động “Mỗi nhà giáo, cán bộ giáo dục giúp đỡ học sinh có hoàn cảnh đặc biệt khó khăn”</td>
                    <td class="col col3">03/07/2015</td>
                    <td class="col col4">
                        <asp:LinkButton ID="down" runat="server" CssClass="tit" Text="Tải về" OnClick="down_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="col col1 tit">61/QĐ-UBND</td>
                    <td class="col col2">Quyết định khen thưởng LĐTT cho cán bộ quản lý 2013-201</td>
                    <td class="col col3">07/07/2015</td>
                    <td class="col col4">
                        <asp:LinkButton ID="downLoad" runat="server" CssClass="tit" Text="Tải về"></asp:LinkButton></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

