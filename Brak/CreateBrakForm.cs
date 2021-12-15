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
    public partial class CreateBrakForm : Form
    {
        private MySqlConnection connection;
        public CreateBrakForm(MySqlConnection connection)
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


            MySqlDataAdapter da2 = new MySqlDataAdapter
                ("SELECT * FROM zapchast", connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            zapchastiFilterComboBox.DataSource = dt2;
            zapchastiFilterComboBox.DisplayMember = "Naimenovanie_zapchasti";
            zapchastiFilterComboBox.ValueMember = "ID_Zapchasti";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("'"))
            {
                return;
            }
            MySqlDataAdapter da = new MySqlDataAdapter
                ("INSERT INTO brak (ID_Brak, ID_Zapchasti,ID_Postavshika,Naimenovanie) " +
                " VALUES (" + getNextId() + "," + zapchastiFilterComboBox.SelectedValue + "," +
                postavshikFilterComboBox.SelectedValue + ", '" +
                textBox1.Text + "')", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Close();
        }

        private int getNextId()
        {
            var query = $"SELECT MAX(ID_Brak) from brak;";
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
    }
}
