using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MysqlConnection
{
    public partial class Form2 : Form
    {
        int id;
        // Criando a conexão com o servidor e acessando o banco de dados
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=dbusers");

        public Form2()
        {
            InitializeComponent();
            // Abrindo a conexão
            connection.Open();
            // Fechando a conexão
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;

            try
            {   
                // Abrindo a conexão
                connection.Open();
                if (value.Trim().Length > 0)
                {
                    string SQL = "DELETE FROM tblusers WHERE id = @id ";
                    MySqlCommand DELETE = new MySqlCommand(SQL, connection);
                    DELETE.Parameters.AddWithValue("@id", id);
                    DELETE.ExecuteNonQuery();

                    MessageBox.Show("Deletado com sucesso");


                    // Fechando a conexão
                    connection.Close();
                    this.Close();
                    Form1 form = new Form1();
                    form.Show();
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível cadastrar!", "ERRO DE CONEXÂO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Valor inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
