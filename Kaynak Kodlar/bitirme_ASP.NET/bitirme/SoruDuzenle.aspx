<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoruDuzenle.aspx.cs" Inherits="SoruDuzenle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Soru Düzenleme Sayfasý</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size: 10pt; width: 573px; color: navy; font-family: 'Lucida Sans Unicode';
            background-color: silver; text-align: center">
            <br />
            <asp:Label ID="lblHata" runat="server" Font-Size="Small" ForeColor="#C00000">
        </asp:Label><br />
            <br />
            <asp:PlaceHolder ID="ph2" runat="server" Visible="False"></asp:PlaceHolder>
            <br />
            &nbsp;<br />
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="panel" runat="server" Height="36px" Width="255px">
                            <asp:Panel ID="Panel1" runat="server" Height="23px" Width="235px">
                                Proje:&nbsp;<br />
                                &nbsp;<asp:Label ID="projeIsmi" runat="server" Font-Bold="True" ForeColor="Maroon"
                                    Height="32px" Text="Label" Width="226px"></asp:Label></asp:Panel>
                            <br />
                            <span></span>
                            <asp:Panel ID="Panel2" runat="server" Height="15px" Width="235px">
                                Soru:
                                <asp:TextBox ID="soru" runat="server" BorderWidth="1px" Columns="6" Height="70px"
                                    MaxLength="100" Rows="6" TextMode="MultiLine" Width="211px" EnableViewState="False"></asp:TextBox><asp:RequiredFieldValidator
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
                                <asp:TextBox ID="gnot" runat="server" Columns="6" Height="70px" MaxLength="100" TextMode="MultiLine"
                                    Width="211px" EnableViewState="False"></asp:TextBox></asp:Panel>
                            <br />
                            <asp:Panel ID="Panel5" runat="server" Height="15px" Width="235px">
                                Kullanýcý için not: (opsiyonel)
                                <asp:TextBox ID="knot" runat="server" Height="70px" MaxLength="100" TextMode="MultiLine"
                                    Width="211px" EnableViewState="False"></asp:TextBox></asp:Panel>
                            <br />
                            <asp:Button ID="devam" runat="server" OnClick="devam_Click" Text="Düzelt" />
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        </asp:Panel>
                    </td>
                    <td valign="top">
                        <strong><span style="color: black"></span></strong>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="Sonraki Sorular:"></asp:Label><br />
                        <asp:PlaceHolder ID="ph" runat="server" EnableViewState="False"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
