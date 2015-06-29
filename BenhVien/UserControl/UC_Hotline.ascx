<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Hotline.ascx.cs" Inherits="UserControl_UC_Hotline" %>

<asp:Repeater ID="dlhotro" runat="server">
    <ItemTemplate>

        <div class="block-line">
            <div class="contact-name"><span><%#(Eval("Ten").ToString())%></span></div>
        </div>
        <div class="block-line bot15">
            <div class="contact-info">
                <div class="call">
                    <img src="/Design/call.png" alt="" />
                </div>
                <div class="phone-number">
                    <span><%#(Eval("SDT").ToString())%></span>
                </div>
            </div>
        </div>


    </ItemTemplate>
</asp:Repeater>

