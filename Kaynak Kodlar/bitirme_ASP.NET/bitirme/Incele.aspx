<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Incele.aspx.cs" Inherits="Incele" Title="Tek Hata İnceleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <span style="font-size: 10pt">
        <br />
        <br />
        <asp:PlaceHolder
            ID="ph" runat="server" EnableViewState="False"></asp:PlaceHolder>
        <br />
        <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000"></asp:Label><br />
        <br /> 
    </span>

        <asp:Panel ID="pnl" runat="server" Height="100px" Width="500px">
        <table width="400">
        <tr><td align="left">
            <span style="font-size: 10pt">Fikir belirtin:</span></td></tr>
        <tr><td align="left"><asp:TextBox id="fikir" runat="server" Height="100px" Width="390px" TextMode="MultiLine" Rows="10" Columns="5" BorderWidth="1px"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="fikir" Font-Bold="True" Font-Size="Large"></asp:RequiredFieldValidator></td></tr>
        <tr><td align="right"><asp:Button id="yolla" runat="server" Text="Yolla" Height="30px" Width="60px" OnClick="yolla_Click"></asp:Button></td></tr>
        </table>
        </asp:Panel>
</asp:Content>

