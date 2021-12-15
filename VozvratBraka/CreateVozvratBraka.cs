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
    public partial class CreateVozvratBraka : Form
    {
        MySqlConnection connection;

        public CreateVozvratBraka(MySqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter
                ("INSERT INTO vozvrat_braka (ID_Vozvrat_braka, ID_Zapchasti, ID_Brak) " +
                " VALUES (" + getNextId() + "," + zapchastiFilterComboBox.SelectedValue + "," +
                brakFilterComboBox.SelectedValue + ")", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Close();
        }

        private int getNextId()
        {
            var query = $"SELECT MAX(ID_Vozvrat_braka) from vozvrat_braka;";
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
