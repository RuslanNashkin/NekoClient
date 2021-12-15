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
    public partial class SkidkiForm : Form
    {
        MySqlConnection connection;
        string query;
        static string _query = "SELECT skidki.ID_Skidki, skidki.Protsent_skidki, skidki.Zakaz, postavshik.Naimenovanie_postavshika " +
                               "FROM skidki, postavshik " +
                               "WHERE postavshik.ID_Postavshika=skidki.ID_Postavshika";


        private void LoadTable()
        {
            var da = new MySqlDataAdapter
                (query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public SkidkiForm(MySqlConnection connection)
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

            postavshikFilterComboBox.SelectedIndex = -1;
            postavshikFilterComboBox.SelectedIndexChanged += new EventHandler(changeIndex);
        }

        private void changeIndex(object sender, EventArgs e)
        {
            query = _query;

            foreach (ComboBox c in panel1.Controls)
            {
                if (c.Text != "")
                    query += " AND skidki." + c.Tag.ToString() + "=" + c.SelectedValue;
            }

            if (!(sender is null))
            {
                LoadTable();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(panel1.Visible = checkBox1.Checked))
            {
                postavshikFilterComboBox.SelectedIndex = -1;
                LoadTable();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            new CreateSkidki(connection).ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var id = int.Parse(row.Cells[0].Value.ToString());
                new EditSkidkiForm(id, connection).ShowDialog();
                LoadTable();
            }
        }
    }
}
