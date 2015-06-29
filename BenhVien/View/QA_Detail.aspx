<%@ Page Title="" Language="C#" MasterPageFile="~/View/LeftBlock.master" AutoEventWireup="true" CodeFile="QA_Detail.aspx.cs" Inherits="View_QA_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div class="product-wrapper">
        <div class="product-header">
            <div class="product-title">
                <h4><a href="javascript:void(0);">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label></a></h4>
            </div>
        </div>
        <div class="product-container">
            <div class="qa">
                <div class="qa-detail question bot5">
                    <img src="/Design/answer.png" alt="Question Icon" />
                    <asp:Label ID="lbNoiDungHoi" runat="server"></asp:Label>
                    <i style="font-size: 12px;">
                        <asp:Label ID="lbHoTen" runat="server"></asp:Label>
                        gửi ngày 
                    <asp:Label ID="lbNgayGui" runat="server"></asp:Label></i>

                </div>

                <div class="qa-detail answer bot10">
                    <asp:Literal ID="ltNoiDungDap" runat="server"></asp:Literal>

                </div>
                <div class="qa-detail question">

                    <a href="/hoi-dap.html">
                        <img src="/Design/undo.png" alt="Turnback Icon" style="width: 18px; height: 18px;" />Quay lại mục hỏi đáp</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

