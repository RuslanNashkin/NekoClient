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
    public partial class PostavshikForm : Form
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

        public PostavshikForm(MySqlConnection connection)
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
                query += $@" AND postavshik.Naimenovanie_postavshika LIKE '%{searchTextBox.Text}%' ";
                LoadTable();
            }
        }
    }
}
