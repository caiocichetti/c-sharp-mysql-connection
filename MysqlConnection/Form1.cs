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
        MySqlConnection connection = new MySqlConnection("server-localhost; user-root; database-dbusers");

        public Form1()
        {
            InitializeComponent();
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
            } catch { 


            }

        }
    }
}
