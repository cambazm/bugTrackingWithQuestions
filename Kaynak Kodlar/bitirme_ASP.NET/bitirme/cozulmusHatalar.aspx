<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cozulmusHatalar.aspx.cs" Inherits="cozulmusHatalar" Title="Çözülmüþ Hatalar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <span style="font-size: 10pt; width: 750px;">&nbsp;<asp:ObjectDataSource ID="odsProjeIsimDoldur"
        runat="server" SelectMethod="isimIdListesi" TypeName="_proje.proje"></asp:ObjectDataSource>
        &nbsp;&nbsp;<br />
        &nbsp;&nbsp;
        Projeyi Seçiniz:
        <asp:DropDownList ID="projeler" runat="server" DataSourceID="odsProjeIsimDoldur" DataTextField="ISIM"
            DataValueField="ID" Width="201px">
        </asp:DropDownList><asp:Button ID="devam" runat="server" OnClick="devam_Click" Text="Tamam" /><br />
        <br />
        <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label><br />
        <br />
        <asp:PlaceHolder ID="ph" runat="server" EnableViewState="False"></asp:PlaceHolder>
        &nbsp;&nbsp;<br />
        <br />
        </span>
</asp:Content>

