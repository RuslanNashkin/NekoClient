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
    public partial class EditSkidkiForm : Form
    {
        MySqlConnection connection;
        int id;

        public EditSkidkiForm(int id, MySqlConnection connection)
        {
            this.id = id;
            this.connection = connection;
            InitializeComponent();
            LoadComboBox();
            LoadData();
        }

        private void LoadComboBox()
        {
            MySqlDataAdapter da1 = new MySqlDataAdapter
                ("SELECT * FROM postavshik", connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            postavshikFilterComboBox.DataSource = dt1;
            postavshikFilterComboBox.DisplayMember = "Naimenovanie_postavshika";
            postavshikFilterComboBox.ValueMember = "ID_Postavshika";
        }

        private void LoadData()
        {
            var adapter = new MySqlDataAdapter
                ("SELECT * FROM skidki WHERE ID_Skidki = " + id, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            textBox1.Text = dataTable.Rows[0][1].ToString();
            textBox2.Text = dataTable.Rows[0][2].ToString();
            postavshikFilterComboBox.SelectedValue = dataTable.Rows[0][3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = $"DELETE FROM skidki WHERE ID_Skidki = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE skidki SET " +
                $"Protsent_skidki = '{textBox1.Text}', " +
                $"Zakaz = '{textBox2.Text}', " +
                $"ID_Postavshika = {postavshikFilterComboBox.SelectedValue} " +
                $"WHERE ID_Skidki = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
