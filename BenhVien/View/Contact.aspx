<%@ Page Title="Liên hệ" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="View_Contact" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">LIÊN HỆ</a></h4>
            </div>
        </div>
        <div class="product-container">

            <div class="content_producthot">
                <div class="contact">

                    <div id="feedback">
                        <p>
                            Mọi thắc mắc, liên hệ đặt hàng của chúng tôi. Xin vui lòng gửi nội dung liên hệ với chúng tôi, 
                    vui lòng gõ tiếng Việt có dấu & nêu nội dung thông tin rõ ràng, rành mạch.
                    Bắt đầu bằng việc viết nội dung thư vào bên dưới và gửi đi!
                        </p>
                        <div class="GuiYkien">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table class="GuiYkien">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="succesfull" runat="server" Text="Label" Visible="false" CssClass="succesfull" />
                                                <asp:Label ID="lbtitle" runat="server" Text="Label" Visible="false" CssClass="titletb" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Họ tên :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHoTen" runat="server" CssClass="txt"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoTen" ValidationGroup="contact" ErrorMessage="->Vui lòng nhập họ tên!" CssClass="titletb">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Email :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="contact"
                                                    ErrorMessage="Email Không đúng!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    CssClass="titletb">*</asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ValidationGroup="contact"
                                                    ErrorMessage="->Vui lòng nhập email!" CssClass="titletb">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Địa chỉ :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="txt" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDiaChi" ValidationGroup="contact"
                                                    ErrorMessage="->Vui lòng nhập địa chỉ!" CssClass="titletb">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Tiêu đề :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTieuDe" runat="server" CssClass="txt" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTieuDe" ValidationGroup="contact"
                                                    ErrorMessage="->Vui lòng nhập tiêu đề!" CssClass="titletb">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">Nội dung:
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtNoiDung" runat="server" TextMode="MultiLine" CssClass="txtnd"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoiDung" ValidationGroup="contact"
                                                    ErrorMessage="->Vui lòng nhập nội dung!" CssClass="titletb">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbcapcha" runat="server" Text="Label" Visible="false" CssClass="titletb" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom">Mã xác nhận:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtInputString" runat="server" CssClass="txtmin"></asp:TextBox>
                                                <asp:Image ID="captchaImage" runat="server" />
                                                <asp:Button ID="btnRedefine" runat="server" Text="" CssClass="btnrefresh" OnClick="btnRedefine_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td"></td>
                                            <td colspan="2">
                                                <asp:Button ID="btnGui" runat="server" Text="Gửi ý kiến" CssClass="btn" ValidationGroup="contact" OnClick="btnbtnGui_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

