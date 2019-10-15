<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HataCozumEkle.aspx.cs" Inherits="hataCozumEkle" Title="Hataya Çözüm Ekleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <span style="font-size: 10pt">
    <br />
    <asp:PlaceHolder ID="ph" runat="server" EnableViewState="False"></asp:PlaceHolder>
    </span>
    <br />
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label><br />
    <asp:Panel ID="pnl" runat="server" Height="100px" Width="500px">
        <table width="400">
            <tr>
                <td align="left">
                    <span style="font-size: 10pt">Çözüm:</span></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:TextBox ID="cozum" runat="server" BorderWidth="1px" Columns="5" Height="100px"
                        Rows="10" TextMode="MultiLine" Width="390px"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cozum"
                        ErrorMessage="*" Font-Bold="True" Font-Size="Large"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="ekle" runat="server" Height="30px" OnClick="ekle_Click" Text="Ekle"
                        Width="60px" /></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

