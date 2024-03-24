using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEscolaMySQLPreparedStatement
{
    public partial class Consulta : System.Web.UI.Page
    {
        private String paramSexo;   //variáveis para receber os parâmetros enviados para esta página
        private String paramNome;

        private MySqlConnection conexao=null;
        private MySqlCommand stm=null;        
        private MySqlDataReader dr=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            paramSexo = "";
            paramNome = "";
            try {
                paramSexo = Request["RadioButtonList1"];
                paramNome = Request["TextBox1"];
                if (paramSexo == null) paramSexo = "";
                if (paramNome == null) paramNome = "";
            }
            catch (Exception) { };

            Label1.Text = "Registros encontrados:";
            String filtro1 = "", filtro2 = "";

            if (paramSexo.Equals("Todos"))
            {
                filtro1 = " TRUE ";
            }
            else if (paramSexo.Equals("Masculino"))
            {
                filtro1 = " (sexo='M') ";
            }
            else if (paramSexo.Equals("Feminino"))
            {
                filtro1 = " (sexo='F') ";
            }
            else
            {
                filtro1 = " FALSE ";
                Label1.Text = "Resultados da busca:";
            }

            filtro2 = " (nome LIKE '%" + paramNome + "%') ";

            try
            {
                conexao = new MySqlConnection(
                    "server=localhost; user id=root; password=12345; database=escola4; SSL Mode = None;");
                conexao.Open();

                string sql = "SELECT * FROM professores WHERE "
                    + filtro1 + " AND " + filtro2 + " ORDER BY nome";
                stm = new MySqlCommand(sql, conexao);
                dr = stm.ExecuteReader();

                String strHTML = "";
                if (dr.HasRows)
                { //mostramos o cabeçalho da <table> somente se temos registros
                    strHTML = "<TABLE name=profs border=1 width='65%'> <TR style='font-size: 14px; font-family: verdana; text-align: center; font-weight: 900; color: #009;'>"
                        + "<TD>&nbsp;Código&nbsp;</TD><TD>&nbsp;Nome&nbsp;</TD>"
                        + "<TD>&nbsp;Sexo&nbsp;</TD><TD>&nbsp;Salário&nbsp;</TD></TR>";
                }

                while (dr.Read()) {
                    int codigo = dr.GetInt32(0); //codprof
                    String nome = dr.GetString(1); //nome
                    float salario = dr.GetFloat(2); //salário
                    String sexo = dr.GetString(3); //sexo
                    //para cada professor criamos uma linha de uma tabela HTML:
                    strHTML += "<TR><TD style='font-size: 12px; font-family: verdana; text-align: center;'>" 
                            + codigo
                            + "</TD><TD style='font-size: 12px; font-family: verdana; text-align: left;'>&nbsp;&nbsp;"
                            + nome + "</TD><TD style='font-size: 12px; font-family: verdana; text-align: center;'>"
                            + sexo + "</TD><TD style='font-size: 12px; font-family: verdana; text-align: center;'>"
                            + salario + "</TD></TR>";
                }

                strHTML += "</TABLE> <br/><br/><br/>";
                LiteralControl lc = new LiteralControl(strHTML);
                //mostramos a tabela HTML (com os professores) em um painel:
                Panel2.Controls.Add(lc);         
            }
            catch (Exception exc) {
                Label1.Text = "Erro no processamento do BD - " + exc.Message;
            }
            finally {
                try {
                    if (dr != null) dr.Close();
                    if (stm != null) stm.Dispose();
                    if (conexao != null) conexao.Close(); 
                } catch (Exception errorf) { }
            }
        }

    }
}