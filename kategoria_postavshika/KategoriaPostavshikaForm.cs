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
    public partial class KategoriaPostavshikaForm : Form
    { 
        MySqlConnection connection;
        string query;
        static string _query = @"SELECT * FROM kategoria_postavshika WHERE TRUE";

        public KategoriaPostavshikaForm(MySqlConnection connection)
        {
            this.connection = connection;
            query = _query;
            InitializeComponent();
            LoadTable();
        }


        private void LoadTable()
        {
            var da = new MySqlDataAdapter
                (query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            query = _query;
            if (!searchTextBox.Text.Contains("'"))
            {
                query += $@" AND kategoria_postavshika.Tip_postavshika LIKE '%{searchTextBox.Text}%' ";
                LoadTable();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            new CreateKategoriaPostavshika(connection).ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var id = int.Parse(row.Cells[0].Value.ToString());
                new EditKategoriaPostavshica(id, connection).ShowDialog();
                LoadTable();
            }
        }
    }
}
