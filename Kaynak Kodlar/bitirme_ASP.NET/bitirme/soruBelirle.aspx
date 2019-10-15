<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="soruBelirle.aspx.cs" Inherits="soruBelirle" Title="Soru Belirleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
   <span style="font-size: 10pt">&nbsp;<br />
       <asp:ObjectDataSource ID="odsProjeIsimDoldur"
       runat="server" SelectMethod="isimIdListesi" TypeName="_proje.proje"></asp:ObjectDataSource>
       &nbsp; &nbsp;&nbsp;
        Soru belirlemek için aþaðýdaki alanlarý doldurunuz:<br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="23px" Width="373px">
            Proje Ýsmi:&nbsp;<asp:DropDownList ID="projeler" runat="server" DataSourceID="odsProjeIsimDoldur"
                DataTextField="ISIM" DataValueField="ID" Width="227px">
            </asp:DropDownList><asp:Button ID="tamam" runat="server" Text="Tamam" OnClick="tamam_Click" ValidationGroup="2" /></asp:Panel>
       &nbsp; &nbsp;<br />
        <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000">
        </asp:Label>&nbsp;<br />
       <br />
       <asp:Panel ID="panel" runat="server" Height="50px" Width="325px" Visible="False">
        <asp:Panel ID="Panel2" runat="server" Height="15px" Width="235px">
            Soru:
            <asp:TextBox ID="soru" runat="server" Height="70px" Width="211px" BorderWidth="1px" Columns="6" Rows="6" TextMode="MultiLine" MaxLength="100" ValidationGroup="1"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="soru" ErrorMessage="*"
                Font-Size="Medium"></asp:RequiredFieldValidator></asp:Panel>
        <br />
        <asp:Panel ID="Panel3" runat="server" Height="83px" Width="229px">
            Cevap:<br />
            <br />
            EVET ise&nbsp;
            <asp:CheckBox ID="evetsorusor" runat="server" Text="Yeni Soru Sor" Width="131px" /><br />
            HAYIR ise<asp:CheckBox ID="hayirsorusor" runat="server" Text="Yeni Soru Sor" Width="131px" /></asp:Panel>
        <br />
        <asp:Panel ID="Panel4" runat="server" Height="15px" Width="235px">
            Geliþtirici için not: (opsiyonel)
            <asp:TextBox ID="gnot" runat="server" Columns="6" Height="70px" MaxLength="100"
                TextMode="MultiLine" Width="211px" ValidationGroup="1"></asp:TextBox></asp:Panel>
        <br />
        <asp:Panel ID="Panel5" runat="server" Height="15px" Width="235px">
            Kullanýcý için not: (opsiyonel)
            <asp:TextBox ID="knot" runat="server" Height="70px" MaxLength="100" TextMode="MultiLine"
                Width="211px" ValidationGroup="1"></asp:TextBox></asp:Panel>
        <br />
        <asp:Button ID="devam" runat="server" Text="Devam" OnClick="devam_Click" ValidationGroup="1" />
        &nbsp; &nbsp;&nbsp;
        <input id="Reset1" type="reset" value="Sýfýrla" onclick="return Reset1_onclick()" /></asp:Panel>
       <br />
       <asp:PlaceHolder ID="ph" runat="server" Visible="False" EnableViewState="False"></asp:PlaceHolder>
   </span>
</asp:Content>

