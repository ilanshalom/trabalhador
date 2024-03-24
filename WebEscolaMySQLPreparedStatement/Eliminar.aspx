<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="WebEscolaMySQLPreparedStatement.Eliminar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema da escola</title>
    <style type="text/css">
        body {
            font-family: Calibri;
            font-size: 18px;
        }
        .auto-style1 {
            font-size: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="auto-style1"><strong>
        <h2>Eliminar um professor</strong></span></h2>
        <br class="auto-style1" />
        <span class="auto-style1">Digite o código do professor a eliminar:&nbsp; </span>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>
        <br class="auto-style1" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="font-weight: 700; " Text="Eliminar" Height="41px" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#000066" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" 
            style="font-family: Verdana; font-size: large">Voltar</asp:LinkButton>
        <br />
        <br class="auto-style1" />
    
    </div>
    </form>
</body>
</html>
