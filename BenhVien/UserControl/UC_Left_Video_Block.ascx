<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Left_Video_Block.ascx.cs" Inherits="UserControl_UC_Left_Video_Block" %>
<div class="block-line bot10" style="margin-top: -10px;">
    <div class="video-img">
        <asp:Repeater ID="rptVideoFirst" runat="server">
            <ItemTemplate>

                <a class="fancybox-media" href="<%#Eval("ImgOrClip") %>" style="color: black; font-weight: bold;">
                    <img src="<%#Eval("HinhAnh") %>" alt="Video here" />
                    <i class="video-play-button">
                        <img src="/Design/play.png" alt="Play video" />
                    </i></a>

            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>

<div class="block-line">
    <ul>
        <asp:Repeater ID="rptVideoRemain" runat="server">
            <ItemTemplate>

                <li class="link"><a class="fancybox-media" href="<%#Eval("ImgOrClip") %>"><%#Eval("Ten_Vn").ToString() %></a></li>

            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
