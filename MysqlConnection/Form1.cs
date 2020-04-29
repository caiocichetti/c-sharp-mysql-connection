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
    public partial class Form1 : Form
    {
        // Criando a conexão com o servidor e acessando o banco de dados
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=dbusers");

        public Form1()
        {
            InitializeComponent();

            // Abrindo a conexão
            connection.Open();              
            // Visualizar valores do BD
            showValuesDb();
            // Fechando a conexão
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            try { 
                // Inserção de dados com o INSERT

                // Abrindo a conexão
                connection.Open();

                string SQL = "INSERT INTO tblusers(name, user, password) VALUES(@Name, @User, @Password)";
                MySqlCommand INSERT = new MySqlCommand(SQL, connection);
                INSERT.Parameters.AddWithValue("@Name", textBox1.Text);
                INSERT.Parameters.AddWithValue("@User", textBox2.Text);
                INSERT.Parameters.AddWithValue("@Password", textBox3.Text);
                INSERT.ExecuteNonQuery();

                // Visualizar valores do BD
                showValuesDb();

                // Fechando a conexão
                connection.Close();

                // Limpa TextBox
                emptyTextBox();

                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            catch {
                // Limpa TextBox
                emptyTextBox();

                MessageBox.Show("Não foi possível cadastrar!", "ERRO DE CONEXÂO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void showValuesDb()
        {
            // Mostrando os valores do BD
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM tblusers", connection);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        public void emptyTextBox()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.Focus();
        }
    }
}
