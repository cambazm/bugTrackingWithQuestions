<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hataGonderU.aspx.cs" Inherits="hataGonderU" Title="Uzman Hata Gönderimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ObjectDataSource ID="odsProjeIsimDoldur" runat="server" SelectMethod="isimIdListesi"
        TypeName="_proje.proje"></asp:ObjectDataSource>
    &nbsp;
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label><br />
    <asp:DropDownList ID="projeler" runat="server" DataSourceID="odsProjeIsimDoldur"
        DataTextField="ISIM" DataValueField="ID" Width="200px">
    </asp:DropDownList><asp:Button ID="devam" runat="server" OnClick="devam_Click" Text="Tamam" /><br />
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server" Visible="False">
        <asp:View ID="View1" runat="server">
            <asp:DropDownList ID="soruListesi" runat="server" Width="535px">
            </asp:DropDownList><br />
            <asp:Label ID="lbl" runat="server" Font-Size="10pt" ForeColor="Maroon"></asp:Label><br />
            <asp:Label ID="lblAciklama" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="12px"
                Text="Açýklama" Visible="False"></asp:Label><br />
            <asp:Label ID="lblNot" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="10pt"
                Visible="False"></asp:Label><br />
            <asp:Button ID="evet" runat="server" OnClick="evet_Click" Text="Evet" /><asp:Button
                ID="hayir" runat="server" OnClick="hayir_Click" Text="Hayýr" /></asp:View>
        <asp:View ID="View2" runat="server">
            <asp:TextBox ID="hata" runat="server" BorderWidth="1px" Height="74px" TextMode="MultiLine"
                Width="285px"></asp:TextBox><br />
            <asp:Button ID="gonder" runat="server" OnClick="gonder_Click" Text="Gönder" Width="81px" /></asp:View>
        <br />
    </asp:MultiView>
</asp:Content>

