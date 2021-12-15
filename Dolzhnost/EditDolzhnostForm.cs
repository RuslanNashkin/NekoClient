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
    public partial class EditDolzhnostForm : Form
    {
        MySqlConnection connection;
        int id;
        public EditDolzhnostForm(int id, MySqlConnection connection)
        {
            this.id = id;
            this.connection = connection;
            InitializeComponent();
            var adapter = new MySqlDataAdapter
                ("SELECT * FROM dolzhnost WHERE ID_Dolzhnost = " + id, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            textBox1.Text = dataTable.Rows[0][1].ToString();
            numericUpDown1.Value = int.Parse(dataTable.Rows[0][2].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = $"DELETE FROM dolzhnost WHERE ID_Dolzhnost = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE dolzhnost SET " +
                $"NameDolzhnost = '{textBox1.Text}', " +
                $"Zarplata = {numericUpDown1.Value} " +
                $"WHERE ID_Dolzhnost = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
