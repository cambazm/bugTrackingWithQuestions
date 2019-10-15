<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sorumluBelirle.aspx.cs" Inherits="sorumluBelirle" Title="Projeden Sorumlu Kiþi Belirleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    &nbsp;<asp:ObjectDataSource ID="odsProjeDoldur" runat="server" SelectMethod="isimIdListesi"
        TypeName="_proje.proje"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSorumluDoldur" runat="server" SelectMethod="sorumluListesi"
        TypeName="_sorumlu.sorumlu"></asp:ObjectDataSource>
    &nbsp;<span style="font-size: 10pt">
        &nbsp;</span>
    <br />
    <span style="font-size: 10pt"></span>
    <table style="width: 305px">
        <tr>
            <td style="text-align: left"><span style="font-size: 10pt">Proje:</span></td>
            <td style="text-align: right">
    <asp:DropDownList ID="projeler" runat="server" DataSourceID="odsProjeDoldur" DataTextField="ISIM"
        DataValueField="ID" Width="201px">
    </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 24px; text-align: left">
                <span style="font-size: 10pt">Sorumlu:</span>&nbsp;
            </td>
            <td style="height: 24px; text-align: right">
    <asp:DropDownList ID="sorumlular" runat="server" Width="200px" DataSourceID="odsSorumluDoldur" DataTextField="ISIM" DataValueField="ID">
    </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 16px; text-align: right" colspan="2">
                <asp:Button ID="tamam" runat="server" OnClick="tamam_Click" Text="Tamam" /></td>
        </tr>
    </table>
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label>
</asp:Content>

