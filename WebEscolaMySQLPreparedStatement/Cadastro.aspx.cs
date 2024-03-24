using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEscolaMySQLPreparedStatement
{
    public partial class Cadastro : System.Web.UI.Page
    {
        private MySqlConnection conexao = null;
        private MySqlCommand command = null;
        private MySqlDataReader rs;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        { //INSERIR UM PROFESSOR
            Label4.Visible = false;
            Label5.Visible = false;

            String paramCodigo = "";
            String paramNome = "";
            String paramSexo = "";
            String paramSalario = "";
            try
            {
                paramCodigo = Request["TextBox1"];
                paramNome = Request["TextBox2"];
                paramSexo = Request["TextBox3"];
                paramSalario = Request["TextBox4"];
                if (paramCodigo == null) paramCodigo = "";
                if (paramNome == null) paramNome = "";
                if (paramSexo == null) paramSexo = "";
                if (paramSalario == null) paramSalario = "";
            }
            catch (Exception) { };

            try {
                conexao = new MySqlConnection(
                    "server=localhost; user id=root; password=12345; database=escola4; SSL Mode = None;");
                conexao.Open();
                String sql = "INSERT INTO professores (codigo,nome,salario,sexo) "
                       + " VALUES (@codigo,@nome,@salario,@sexo)";
                //ou: String sql = "INSERT INTO professores (codigo,nome,salario,sexo) "
                                       //+ " VALUES (?,?,?,?)";
                command = new MySqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@codigo", paramCodigo);
                command.Parameters.AddWithValue("@nome", paramNome);
                command.Parameters.AddWithValue("@salario", paramSalario);
                command.Parameters.AddWithValue("@sexo", paramSexo);               
                command.Prepare();
                int qtde = command.ExecuteNonQuery();
                if (qtde == 0){
                    Label4.Visible = false;
                    Label5.Visible = true; //erro
                }
                else {
                    Label4.Visible = true;  //inserido com sucesso
                    Label5.Visible = false;
                }
            }
            catch (Exception exc) {
                Label5.Text = "Erro ao inserir. Verifique que não tenha outro prof. com esse código." 
                    + " --- " + exc.Message;
                Label4.Visible = false;
                Label5.Visible = true; //erro
            }
            finally {
                if(command != null) command.Dispose();
                if(conexao != null) conexao.Close();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        { //ALTERAR UM PROFESSOR
            Label4.Visible = false;
            Label5.Visible = false;

            String paramCodigo = "";
            String paramNome = "";
            String paramSexo = "";
            String paramSalario = "";
            try
            {
                paramCodigo = Request["TextBox1"];
                paramNome = Request["TextBox2"];
                paramSexo = Request["TextBox3"];
                paramSalario = Request["TextBox4"];
                if (paramCodigo == null) paramCodigo = "";
                if (paramNome == null) paramNome = "";
                if (paramSexo == null) paramSexo = "";
                if (paramSalario == null) paramSalario = "";
            }
            catch (Exception) { };

            try
            {
                conexao = new MySqlConnection(
                    "server=localhost; user id=root; password=12345; database=escola4; SSL Mode = None;");
                conexao.Open();

                //Usando prepared statements:
                string sql = "UPDATE professores SET nome=@nome , sexo=@sexo, salario=@salario WHERE codigo=@codigo";
                command = new MySqlCommand(sql, conexao);
                
                command.Parameters.AddWithValue("@nome", paramNome);
                command.Parameters.AddWithValue("@salario", paramSalario);
                command.Parameters.AddWithValue("@sexo", paramSexo);                
                command.Parameters.AddWithValue("@codigo", paramCodigo);
                command.Prepare();
                int qtde = command.ExecuteNonQuery();

                if (qtde == 0)
                {
                    Label4.Visible = false;
                    Label5.Text = "Naõ foi possível alterar o professor com código: " + paramCodigo + ".";
                    Label5.Visible = true; //erro
                }
                else
                {
                    Label4.Text = "Registro alterado com sucesso: professor código " + paramCodigo + ".";
                    Label4.Visible = true;  //inserido com sucesso
                    Label5.Visible = false;
                }

                command.Dispose();
                conexao.Close();
            }
            catch (Exception exc)
            {
                Label4.Visible = false;
                Label5.Visible = true; //erro
                Label5.Text = exc.Message;
            }
        }

    }
}