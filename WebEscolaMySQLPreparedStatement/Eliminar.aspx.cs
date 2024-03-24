using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEscolaMySQLPreparedStatement
{
    public partial class Eliminar : System.Web.UI.Page
    {
        private MySqlConnection conexao;
        private MySqlCommand stm;
        private MySqlDataReader rs;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e) { // ELIMINAR UM PROFESSOR
            String paramCodigo = "";
            try {
                paramCodigo = Request["TextBox1"];
                if (paramCodigo == null) paramCodigo = "-1";
            }
            catch (Exception) { };
            try {
                conexao = new MySqlConnection("server=localhost; user id=root; password=12345; database=escola4; SSL Mode = None;");
                conexao.Open();
                stm = new MySqlCommand("DELETE FROM professores WHERE codigo = @codigo", conexao);
                stm.Parameters.AddWithValue("@codigo", paramCodigo);
                stm.Prepare();
                int qtde = stm.ExecuteNonQuery();
                if (qtde == 0) {
                    Label1.Text = "Naõ foi possível eliminar o professor com código: " + paramCodigo + ".";
                }
                else {
                    Label1.Text = "O professor especificado foi eliminado com sucesso: código " + paramCodigo + ".";
                }
            }
            catch (Exception exc) {
                Label1.Text = "Erro: " + exc.Message;
            }
            finally {
               stm.Dispose();
               conexao.Close();
            }
        }

    }
}