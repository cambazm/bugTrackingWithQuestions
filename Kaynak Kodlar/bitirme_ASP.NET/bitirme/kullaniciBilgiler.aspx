<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kullaniciBilgiler.aspx.cs" Inherits="kullaniciBilgiler" Title="Bilgi düzenleme sayfasý" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <br />
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="Maroon"></asp:Label><br />
    <span style="font-size: 10pt">&nbsp;</span><table style="font-size: 10pt">
        <tr>
            <td style="text-align: left; width: 158px;">
                Kullanýcý ismi
            </td>
            <td style="width: 149px; text-align: left">
                <asp:TextBox ID="isim" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 158px;">
                Mevcut Þifre
            </td>
            <td style="width: 149px; text-align: left">
                <asp:TextBox ID="mevcutsifre" runat="server" MaxLength="10" TextMode="Password" ValidationGroup="1"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="sifre" ErrorMessage="*"
                    ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>        
        <tr>
            <td style="text-align: left; height: 39px; width: 158px;">
                Þifre
            </td>
            <td style="width: 149px; text-align: left; height: 39px;">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Þifreler ayný olmalý"
                    ForeColor="Maroon" ValidationGroup="1" ValueToCompare="Text" ControlToCompare="sifre" ControlToValidate="sifre2"></asp:CompareValidator>
                <asp:TextBox ID="sifre" runat="server" MaxLength="10" TextMode="Password" ValidationGroup="1"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="sifre" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="text-align: left; width: 158px;">
                Þifre (yeniden)
            </td>
            <td style="width: 149px; text-align: left">
                <asp:TextBox ID="sifre2" runat="server" MaxLength="10" TextMode="Password" ValidationGroup="1"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="sifre2" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Button ID="sifredegistir" runat="server" Text="Þifre deðiþtir" OnClick="sifredegistir_Click" ValidationGroup="1" />               
            </td>
        </tr>        
        <tr>
            <td style="text-align: left; width: 158px;">
                E-posta adresi
            </td>
            <td style="width: 149px; text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="mail"
                    ErrorMessage="Geçerli bir mail adresi girmelisiniz" ForeColor="Maroon" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="2" Width="216px"></asp:RegularExpressionValidator>
                <asp:TextBox ID="mail" runat="server" MaxLength="40" ValidationGroup="2" EnableViewState="False"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="mail" ErrorMessage="*" ValidationGroup="2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left; width: 158px;">
                Bilgisayar özellikleri (opsiyonel)
            </td>
            <td style="width: 149px; text-align: left">
                <asp:TextBox ID="blg" runat="server" Height="47px" TextMode="MultiLine" Width="216px" EnableViewState="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Button ID="guncelle" runat="server" Text="Bilgileri güncelle" OnClick="guncelle_Click" ValidationGroup="2" />                
            </td>
        </tr>        
    </table>
</asp:Content>

