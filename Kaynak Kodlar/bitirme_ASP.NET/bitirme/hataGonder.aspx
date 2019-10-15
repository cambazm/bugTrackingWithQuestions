<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hataGonder.aspx.cs" Inherits="hataGonder" Title="Hata Gönderme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ObjectDataSource ID="odsProjeIsimDoldur" runat="server" SelectMethod="isimIdListesi"
        TypeName="_proje.proje"></asp:ObjectDataSource>
    <span style="font-size: 10pt">&nbsp; &nbsp;</span><asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label><br />
    <span style="font-size: 10pt">
    &nbsp;<span>Projeyi Seçiniz: </span></span>
    <asp:DropDownList ID="projeler" runat="server" DataSourceID="odsProjeIsimDoldur" DataTextField="ISIM"
        DataValueField="ID" Width="200px">
    </asp:DropDownList><span style="font-size: 10pt"> </span>
    <asp:Button ID="devam" runat="server" OnClick="devam_Click" Text="Tamam" /><span
        style="font-size: 10pt"> veya </span>
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Small"
        ForeColor="Black" OnClick="LinkButton1_Click">Soru seçerek gönderim</asp:LinkButton><br />
    <span style="font-size: 10pt">
        <br />
        <asp:Label ID="lblCevapla" runat="server" Font-Bold="True" Font-Italic="True" Text="Aþaðýdaki soruyu cevaplayýnýz"
            Visible="False"></asp:Label><br />
        <br />
    </span>
            <asp:Label ID="lbl" runat="server" Font-Size="10pt" ForeColor="Maroon"></asp:Label><br />
    <br />
    <asp:Label ID="lblAciklama" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="12px"
        Text="Açýklama" Visible="False"></asp:Label><br />
    <asp:Label ID="lblNot" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="10pt"
        Visible="False"></asp:Label><br />
            <asp:Button ID="evet" runat="server" Text="Evet" OnClick="evet_Click" Visible="False" />
            <asp:Button ID="hayir" runat="server" Text="Hayýr" OnClick="hayir_Click" Visible="False" /><br />
    <span style="font-size: 10pt">
        <asp:Panel ID="pnl" runat="server" Height="95px" Width="339px" EnableViewState="False" Visible="False">
            <br />
            Hata hakkýnda ayrýntýlý açýklama giriniz:<br />
            <asp:TextBox ID="hata" runat="server" BorderWidth="1px" Height="74px" TextMode="MultiLine"
                Width="267px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="hata"
                ErrorMessage="*" Font-Size="Medium" Enabled="False"></asp:RequiredFieldValidator><br />
            <asp:Button ID="gonder" runat="server" Text="Gönder" OnClick="gonder_Click" />&nbsp;<br />
            <br />
            &nbsp;</asp:Panel>
        </span>
</asp:Content>

