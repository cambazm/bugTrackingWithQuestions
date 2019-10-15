<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Title="Sisteme Giriþ Sayfasý"  CodeFile="gir.aspx.cs" Inherits="gir" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
            <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000">
        </asp:Label><br />
            <br />
            <table id="TABLE1" style="width: 250px; height: 92px">
                <tr>
                    <td style="text-align: left">
                        <span style="font-size: 10pt">
                        Kullanýcý ismi:</span></td>
                    <td colspan="2" style="height: 27px; text-align: right">
                        <asp:TextBox ID="isim" runat="server" Width="122px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="isim">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <span style="font-size: 10pt">
                        Þifre:</span></td>
                    <td colspan="2" style="text-align: right">
                        <asp:TextBox ID="sifre" runat="server" Width="122px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="sifre">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="   Gir   " /></td>
                </tr>
            </table>
    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Small"
        ForeColor="Black" NavigateUrl="~/kullaniciEkle.aspx">Üye ol</asp:HyperLink>
</asp:Content>
