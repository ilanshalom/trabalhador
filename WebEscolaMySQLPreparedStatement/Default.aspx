<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebEscolaMySQLPreparedStatement.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema da escola</title>
    <style type="text/css">
        body {
            font-family: Calibri;
            font-size: 22px;
        }
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Sistema da escola&nbsp;&nbsp;
    
        <strong>
    
                <span class="auto-style1"> BD &#39;escola4&#39;, formato MySQL</span></strong></h2>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Consulta.aspx">Consulta de professores</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Cadastro.aspx">Cadastrar ou alterar os dados dos professores</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Eliminar.aspx">Eliminar um professor</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>
