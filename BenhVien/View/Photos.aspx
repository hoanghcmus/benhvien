<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="Photos.aspx.cs" Inherits="View_Photos" %>

<%@ Register Src="../UserControl/UC_Paging.ascx" TagName="UC_Paging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">Hình ảnh</a></h4>
            </div>
        </div>
        <div class="product-container">
            <asp:Repeater ID="dlListImg" runat="server">
                <ItemTemplate>
                    <div class="itemalbum">
                        <div class="image_stack">
                            <%#ShowImg(Container.DataItem,"ImgOrClip") %>
                        </div>
                        <div class="titlealbum">
                            <a href='<%#DataAccess.Connect.Link.DetailPhoto(Eval("Ten_Vn").ToString(),Eval("ID").ToString()) %>'>
                                <%#Eval("Ten_Vn").ToString() %></a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <uc1:UC_Paging ID="pagerBottom" runat="server" />

        </div>



    </div>
</asp:Content>

