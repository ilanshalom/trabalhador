<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="WebEscolaMySQLPreparedStatement.Consulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema da escola</title>
    <style type="text/css">
        body {
            font-family: Calibri;
        }
        .style1
        {
            font-size: large;
            font-family: Verdana;
        }
        #form1
        {
            height: 352px;
            width: 1131px;
        }
        .style2
        {
            font-size: x-large;
            font-family: Verdana;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <strong>    
        <span class="style2">Consulta - tabela professores</span><span class="style1">&nbsp;&nbsp; -&nbsp;&nbsp; BD &#39;escola4&#39;, formato MySQL</span></strong><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" 
            style="font-size: large">Voltar</asp:LinkButton>
        <br />
        <br />
        Consultar professores do sexo: <br /><br />
        <asp:Panel ID="Panel1" runat="server" Height="98px" Width="196px">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                style="font-size: small">
                <asp:ListItem Selected="True">Todos</asp:ListItem>
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Feminino</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
    
    </div>
    <br/>
        Opcionalmente, digite uma parte do nome / sobrenome:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br/><br/><br/>
    <asp:Button ID="Button1" runat="server" 
        style="font-family: Verdana; font-size: large" Text="Buscar" Height="51px" 
        Width="129px" />
    <br /><br /><br />
    <asp:Label ID="Label1" runat="server" style="font-weight: 700"></asp:Label>
    <br /><br />

    <asp:Panel ID="Panel2" runat="server" BorderStyle="Outset" Height="303px" 
        ScrollBars="Both"></asp:Panel>
        
        <br />
        <br />
        <br />        
    </form>            
 </body>
</html>
