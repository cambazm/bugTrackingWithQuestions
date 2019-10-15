<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="projeEkle.aspx.cs" Inherits="projeEkle" Title="Proje Ekleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    
    <asp:ObjectDataSource ID="odsProjeDoldur" runat="server" SelectMethod="doldur" TypeName="_proje.proje"></asp:ObjectDataSource><asp:ObjectDataSource ID="odsProjeIsimDoldur" runat="server" SelectMethod="isimIdListesi" TypeName="_proje.proje">
    </asp:ObjectDataSource>
    <br />
    <span style="font-size: 10pt">Proje Ýsmi:&nbsp; 
        <asp:TextBox ID="projeismi" runat="server"></asp:TextBox></span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
        Font-Size="Medium" ControlToValidate="projeismi" ValidationGroup="1"></asp:RequiredFieldValidator><br />
    <span style="font-size: 10pt">Proje Türü:
        <asp:TextBox ID="projeturu" runat="server"></asp:TextBox></span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
        Font-Size="Medium" ControlToValidate="projeturu" ValidationGroup="1"></asp:RequiredFieldValidator><br />
    <asp:Button ID="ekle" runat="server" OnClick="ekle_Click" Text="Ekle" ValidationGroup="1" />&nbsp;&nbsp;<input
        id="Reset1" type="reset" value="Sýfýrla"/>
    <br />
    <br />
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label><br />
    <br />
    <asp:DropDownList ID="projeler" runat="server" EnableViewState="False" Width="212px" DataSourceID="odsProjeIsimDoldur"  DataTextField="ISIM" DataValueField="ID">
    </asp:DropDownList>
    <asp:Button ID="sil" runat="server" Text="Projeyi Sil" OnClick="sil_Click" ValidationGroup="2" /><br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="odsProjeDoldur" Font-Size="X-Small" EnableViewState="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="20">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Content>

