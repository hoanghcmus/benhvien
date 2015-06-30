<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true"
    CodeFile="Videos.aspx.cs" Inherits="View_Videos" %>

<%@ Register Src="/UserControl/UC_Paging.ascx" TagName="UC_Paging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">VIDEO - CLIPS</a></h4>
            </div>
        </div>
        <div class="product-container">
            <asp:DataList ID="dlVideos" runat="server">
                <ItemTemplate>
                    <div class="item_videos">
                        <div class="url_videos">
                            <a class="fancybox-media link" href="<%#Eval("ImgOrClip")%>">
                                <img src='<%#Eval("HinhAnh") %>' alt="Hình ảnh" class="img" />
                                <i class="playvideo"></i></a>
                        </div>
                        <div class="name_videos">
                            <h4><a class="fancybox-media  link" href="<%#Eval("ImgOrClip")%>">
                                <%#Eval("Ten_Vn").ToString() %></a>
                            </h4>
                            <p class="meta">
                                <strong>Ngày tạo:</strong>
                                <%#Eval("NgayTao") %>
                            </p>
                            <p class="text">
                                <strong>Mô tả:</strong>ss
                                <%#Eval("MoTa_Vn") %>
                            </p>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <uc1:UC_Paging ID="pagerBottom" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
