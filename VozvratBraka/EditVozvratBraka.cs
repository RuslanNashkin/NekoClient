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
    public partial class EditVozvratBraka : Form
    {
        MySqlConnection connection;
        int id;
        public EditVozvratBraka(int id, MySqlConnection connection)
        {
            this.connection = connection;
            this.id = id;
            InitializeComponent();
            LoadComboBox();
            LoadData();
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

        private void LoadData()
        {
            var adapter = new MySqlDataAdapter
                ("SELECT * FROM vozvrat_braka WHERE ID_Vozvrat_braka = " + id, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            zapchastiFilterComboBox.SelectedValue = dataTable.Rows[0][1].ToString();
            brakFilterComboBox.SelectedValue = dataTable.Rows[0][2].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = $"DELETE FROM vozvrat_braka WHERE ID_Vozvrat_braka = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE vozvrat_braka SET " +
               $"ID_Zapchasti = {zapchastiFilterComboBox.SelectedValue}, " +
               $"ID_Brak = {brakFilterComboBox.SelectedValue} " +
               $"WHERE ID_Vozvrat_braka = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
