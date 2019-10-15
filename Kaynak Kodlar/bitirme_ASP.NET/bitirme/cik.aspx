<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cik.aspx.cs" Inherits="cik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Çýkýþ</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size: 10pt; width: 446px; color: navy; font-family: 'Lucida Sans Unicode';
            background-color: silver; text-align: center">
            <br />
            <br />
            <br />
            <asp:Label ID="lblHata" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"></asp:Label><br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="Small"
                ForeColor="Black" NavigateUrl="~/gir.aspx">Giriþ yapýn</asp:HyperLink><br />
            <br />
        </div>
    
    </div>
    </form>
</body>
</html>
