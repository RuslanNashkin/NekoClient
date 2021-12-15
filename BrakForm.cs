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
        static string _query = @"SELECT brak.Naimenovanie,zapchast.Naimenovanie_zapchasti,postavshik.Naimenovanie_postavshika
                                 FROM brak,zapchast,postavshik
                                 WHERE brak.ID_Zapchasti=zapchast.ID_Zapchasti 
                                 AND brak.ID_Postavshika=postavshik.ID_Postavshika";


        private void LoadTable()
        {
            MySqlConnection con = new MySqlConnection
                ("Server=127.0.0.1;Database=autoshop;" +
                "Uid=test;Pwd=test;SslMode=none;Charset=utf8");
            MySqlDataAdapter da = new MySqlDataAdapter
                (query, con);
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
            ///-------------------///

            MySqlDataAdapter da2 = new MySqlDataAdapter
                ("SELECT * From zapchast", connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            zapchastiFilterComboBox.DataSource = dt2;
            zapchastiFilterComboBox.DisplayMember = "Naimenovanie_zapchasti";
            zapchastiFilterComboBox.ValueMember = "ID_Zapchasti";
            ///-------------------///
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
            firmsNaim_SelectedIndexChanged(null, null);

            query += $@" AND brak.Naimenovanie LIKE '%{searchTextBox.Text}%' ";
            LoadTable();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            new CreateBrakForm(connection).ShowDialog();
            LoadTable();
        }
    }
}
