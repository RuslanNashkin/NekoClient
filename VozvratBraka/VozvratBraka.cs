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
    public partial class VozvratBraka : Form
    {
        MySqlConnection connection;
        string query;
        static string _query = @"SELECT vozvrat_braka.ID_Vozvrat_braka, zapchast.Naimenovanie_zapchasti, brak.Naimenovanie
                                 FROM vozvrat_braka, zapchast, brak
                                 WHERE zapchast.ID_Zapchasti=vozvrat_braka.ID_Zapchasti
                                 AND brak.ID_Brak=vozvrat_braka.ID_Brak";

        private void LoadTable()
        {
            var da = new MySqlDataAdapter
                (query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public VozvratBraka(MySqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            query = _query;
            LoadTable();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            MySqlDataAdapter da1 = new MySqlDataAdapter
                ("SELECT * FROM brak", connection);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            brakFilterComboBox.DataSource = dt1;
            brakFilterComboBox.DisplayMember = "Naimenovanie";
            brakFilterComboBox.ValueMember = "ID_Brak";
            ///-------------------///

            MySqlDataAdapter da2 = new MySqlDataAdapter
                ("SELECT * FROM zapchast", connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            zapchastiFilterComboBox.DataSource = dt2;
            zapchastiFilterComboBox.DisplayMember = "Naimenovanie_zapchasti";
            zapchastiFilterComboBox.ValueMember = "ID_Zapchasti";
            ///-------------------///
            brakFilterComboBox.SelectedIndex = -1;
            zapchastiFilterComboBox.SelectedIndex = -1;
            zapchastiFilterComboBox.SelectedIndexChanged += new EventHandler(filterChangeIndex);
            brakFilterComboBox.SelectedIndexChanged += new EventHandler(filterChangeIndex);
        }

        private void filterChangeIndex(object sender, EventArgs e)
        {
            query = _query;

            foreach (ComboBox c in panel1.Controls)
            {
                if (c.Text != "")
                    query += " AND vozvrat_braka." + c.Tag.ToString() + "=" + c.SelectedValue;
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
                zapchastiFilterComboBox.SelectedIndex = -1;
                brakFilterComboBox.SelectedIndex = -1;
                LoadTable();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            new CreateVozvratBraka(connection).ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var id = int.Parse(row.Cells[0].Value.ToString());
                new EditVozvratBraka(id, connection).ShowDialog();
                LoadTable();
            }
        }
    }
}
