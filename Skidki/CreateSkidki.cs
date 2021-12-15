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
    public partial class CreateSkidki : Form
    {
        MySqlConnection connection;
        public CreateSkidki(MySqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            LoadComboBox();
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

        private int getNextId()
        {
            var query = $"SELECT MAX(ID_Skidki) from skidki;";
            var adapter = new MySqlDataAdapter(query, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            try
            {
                return int.Parse(dataTable.Rows[0][0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("'") || textBox2.Text.Contains("'"))
            {
                return;
            }
            MySqlDataAdapter da = new MySqlDataAdapter
                ("INSERT INTO skidki (ID_Skidki, Protsent_skidki, Zakaz, ID_Postavshika) " +
                " VALUES (" + getNextId() + "," + $"'{textBox1.Text}'," + $"'{textBox2.Text}'," + postavshikFilterComboBox.SelectedValue + ")", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Close();
        }
    }
}
