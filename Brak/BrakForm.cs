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
    public partial class BrakForm : Form
    {
        private MySqlConnection connection;
        string query;
        static string _query = @"SELECT brak.ID_Brak, brak.Naimenovanie, zapchast.Naimenovanie_zapchasti, postavshik.Naimenovanie_postavshika
                                 FROM brak,zapchast,postavshik
                                 WHERE zapchast.ID_Zapchasti=brak.ID_Zapchasti
                                 AND postavshik.ID_Postavshika=brak.ID_Postavshika";


        private void LoadTable()
        {
            var da = new MySqlDataAdapter
                (query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public BrakForm(MySqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            LoadComboBox();
            query = _query;
            LoadTable();
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
                ("SELECT * From zapchast", connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            zapchastiFilterComboBox.DataSource = dt2;
            zapchastiFilterComboBox.DisplayMember = "Naimenovanie_zapchasti";
            zapchastiFilterComboBox.ValueMember = "ID_Zapchasti";
            
            postavshikFilterComboBox.SelectedIndex = -1;
            zapchastiFilterComboBox.SelectedIndex = -1;
            zapchastiFilterComboBox.SelectedIndexChanged += new EventHandler(firmsNaim_SelectedIndexChanged);
            postavshikFilterComboBox.SelectedIndexChanged += new EventHandler(firmsNaim_SelectedIndexChanged);
        }

        private void firmsNaim_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = _query;

            foreach (ComboBox c in panel1.Controls)
            {
                if (c.Text != "")
                    query += " AND brak." + c.Tag.ToString() + "=" + c.SelectedValue;
            }

            if (!(sender is null))
            {
                searchTextBox.Clear();
                LoadTable();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(panel1.Visible = checkBox1.Checked))
            {
                zapchastiFilterComboBox.SelectedIndex = -1;
                postavshikFilterComboBox.SelectedIndex = -1;
                LoadTable();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            query = _query;
            firmsNaim_SelectedIndexChanged(null, null);
            if (!searchTextBox.Text.Contains("'"))
            {
                query += $@" AND brak.Naimenovanie LIKE '%{searchTextBox.Text}%' ";
                LoadTable();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            new CreateBrakForm(connection).ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var id = int.Parse(row.Cells[0].Value.ToString());
                new EditBrakForm(id, connection).ShowDialog();
                LoadTable();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void zapchastiFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void postavshikFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
