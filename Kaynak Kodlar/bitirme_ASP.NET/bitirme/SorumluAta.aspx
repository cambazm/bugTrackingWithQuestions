<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SorumluAta.aspx.cs" Inherits="SorumluAta" Title="Hatadan Sorumlu Kiþi Atama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <br />
    <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="pnl" runat="server" Height="140px" Width="400px">
        <table style="width: 305px">
            <tr>
                <td style="height: 24px; text-align: left">
                    <span style="font-size: 10pt">Sorumlu:</span>&nbsp;
                </td>
                <td style="height: 24px; text-align: right">
                    <asp:DropDownList ID="sorumlular" runat="server" DataSourceID="odsSorumluDoldur" DataTextField="ISIM"
                        DataValueField="ID" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 16px; text-align: right">
                    <asp:Button ID="tamam" runat="server" OnClick="tamam_Click" Text="Tamam" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="link" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                        Visible="False">[link]</asp:HyperLink></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="odsSorumluDoldur" runat="server" SelectMethod="sorumluListesi"
            TypeName="_sorumlu.sorumlu"></asp:ObjectDataSource>
    </asp:Panel>
</asp:Content>

