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
    public partial class ZapchastForm : Form
    {
        MySqlConnection connection;
        string query;
        static string _query = @"SELECT * FROM zapchast WHERE TRUE";


        private void LoadTable()
        {
            var da = new MySqlDataAdapter
                (query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public ZapchastForm(MySqlConnection connection)
        {
            this.connection = connection;
            query = _query;
            InitializeComponent();
            LoadTable();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            query = _query;
            if (!searchTextBox.Text.Contains("'"))
            {
                query += $@" AND zapchast.Naimenovanie_zapchasti LIKE '%{searchTextBox.Text}%' ";
                LoadTable();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            new CreateZapchastForm(connection).ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var id = int.Parse(row.Cells[0].Value.ToString());
                new EditZapchastForm(id, connection).ShowDialog();
                LoadTable();
            }
        }
    }
}
