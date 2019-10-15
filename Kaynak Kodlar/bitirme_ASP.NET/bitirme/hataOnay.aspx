<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hataOnay.aspx.cs" Inherits="hataOnay" Title="Hata Çözümü Onaylama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<span style="font-size: 10pt; width: 750px;">
    <br />
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000" EnableViewState="true"></asp:Label><br />
    <asp:PlaceHolder
        ID="ph" runat="server" EnableViewState="False"></asp:PlaceHolder>
    <br />
</span>
</asp:Content>

