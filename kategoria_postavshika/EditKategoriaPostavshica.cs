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

namespace RuslanNashkinNekoClientApp
{
    public partial class EditKategoriaPostavshica : Form
    {
        MySqlConnection connection;
        int id;
        public EditKategoriaPostavshica(int id, MySqlConnection connection)
        {
            this.id = id;
            this.connection = connection;
            InitializeComponent();
            var adapter = new MySqlDataAdapter
                ("SELECT * FROM kategoria_postavshika WHERE ID_Kategoria_postavshika = " + id, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            textBox1.Text = dataTable.Rows[0][1].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = $"DELETE FROM kategoria_postavshika WHERE ID_Kategoria_postavshika = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE kategoria_postavshika SET " +
              $"Tip_postavshika = '{textBox1.Text}' " +
              $"WHERE ID_Kategoria_postavshika = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
