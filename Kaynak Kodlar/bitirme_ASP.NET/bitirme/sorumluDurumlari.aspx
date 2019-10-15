<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sorumluDurumlari.aspx.cs" Inherits="sorumluDurumlari" Title="Sorumlularýn durumlarý" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <br />
    <br />
    <strong>
    <span style="font-size: 9pt">PROJELERDEN SORUMLU KÝÞÝLER</span><br />
    </strong>
    <asp:GridView ID="projeSorumlulari" runat="server" CellPadding="4" EnableViewState="False"
        ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="odsProjeSorumlulari" Font-Size="Small">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Proje" HeaderText="Proje" />
            <asp:BoundField DataField="Sorumlu" HeaderText="Sorumlu" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsProjeSorumlulari" runat="server" SelectMethod="projeSorumlulari"
        TypeName="_sorumlu.sorumlu"></asp:ObjectDataSource>
    <br />
    <br />
    <br />
    <span style="font-size: 10pt"><span style="font-size: 9pt"><strong>HATALARDAN SORUMLU KÝÞÝLER</strong></span>&nbsp;<asp:GridView ID="hataSorumlulari" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="odsHataSorumlulari" EnableViewState="False" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Hata" DataNavigateUrlFormatString="Incele.aspx?id={0}"
                DataTextField="Hata" HeaderText="Hata" />
            <asp:BoundField DataField="Sorumlu" HeaderText="Sorumlu" ReadOnly="True" />
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </span>
    <asp:ObjectDataSource ID="odsHataSorumlulari" runat="server" SelectMethod="hataSorumlulari"
                    TypeName="_sorumlu.sorumlu"></asp:ObjectDataSource>

    &nbsp;
</asp:Content>

