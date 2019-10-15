<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kullaniciEkle.aspx.cs" Inherits="kullaniciEkle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Kullanýcý ekleme</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size: 10pt; width: 521px; color: navy; font-family: 'Lucida Sans Unicode';
            height: 441px; background-color: silver; text-align: center">
            <br />
            <asp:Label ID="lblHata" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Maroon"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HataTakipConnectionString %>"
                SelectCommand="SELECT [ID], [TIP] FROM [KTip] ORDER BY [ID] DESC"></asp:SqlDataSource>
            <br />
            <br />
            <table>
                <tr>
                    <td style="text-align: left">Kullanýcý ismi
                    </td>
                    <td style="width: 212px; text-align: left;"><asp:TextBox ID="isim" runat="server" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="*" ControlToValidate="isim"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">Þifre
                    </td>
                    <td style="width: 212px; text-align: left;">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="sifre"
                            ControlToValidate="sifre2" ErrorMessage="Þifreler ayný olmalý" ForeColor="Maroon"
                            ValueToCompare="Text"></asp:CompareValidator>
                        <asp:TextBox ID="sifre" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="sifre"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="text-align: left">Þifre (yeniden)
                    </td>
                    <td style="width: 212px; text-align: left;"><asp:TextBox ID="sifre2" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="sifre2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">E-posta adresi
                    </td>
                    <td style="width: 212px; text-align: left;">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="mail"
                            ErrorMessage="Geçerli bir mail adresi girmelisiniz" ForeColor="Maroon" Width="215px"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="mail" runat="server" MaxLength="40"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="mail"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top">Bilgisayar özellikleri (opsiyonel)
                    </td>
                    <td style="width: 212px; text-align: left;"><asp:TextBox ID="blg" runat="server" Height="47px" TextMode="MultiLine" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2"><asp:Button ID="ekle" runat="server" Text="  Ekle  " OnClick="ekle_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:DropDownList ID="kullanicilar" runat="server" DataSourceID="SqlDataSource1" DataTextField="TIP" DataValueField="ID" Width="131px" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
