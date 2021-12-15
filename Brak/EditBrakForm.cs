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
    public partial class EditBrakForm : Form
    {
        MySqlConnection connection;
        int id;

        public EditBrakForm(int id, MySqlConnection connection)
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

            MySqlDataAdapter da2 = new MySqlDataAdapter
                ("SELECT * FROM zapchast", connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            zapchastiFilterComboBox.DataSource = dt2;
            zapchastiFilterComboBox.DisplayMember = "Naimenovanie_zapchasti";
            zapchastiFilterComboBox.ValueMember = "ID_Zapchasti";
        }

        private void LoadData()
        {
            var adapter = new MySqlDataAdapter
                ("SELECT * FROM brak WHERE ID_Brak = " + id, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            zapchastiFilterComboBox.SelectedValue = dataTable.Rows[0][1].ToString();
            postavshikFilterComboBox.SelectedValue = dataTable.Rows[0][2].ToString();
            textBox1.Text = dataTable.Rows[0][3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = $"DELETE FROM brak WHERE ID_Brak = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE brak SET " +
                $"Naimenovanie = '{textBox1.Text}', " + 
                $"ID_Zapchasti = {zapchastiFilterComboBox.SelectedValue}, " +
                $"ID_Postavshika = {postavshikFilterComboBox.SelectedValue} " +
                $"WHERE ID_Brak = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
