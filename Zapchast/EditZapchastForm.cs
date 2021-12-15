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
    public partial class EditZapchastForm : Form
    {
        MySqlConnection connection;
        int id;
        public EditZapchastForm(int id, MySqlConnection connection)
        {
            this.id = id;
            this.connection = connection;
            InitializeComponent();
            var adapter = new MySqlDataAdapter
                ("SELECT * FROM zapchast WHERE ID_Zapchasti = " + id, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            textBox1.Text = dataTable.Rows[0][1].ToString();
            numericUpDown1.Value = int.Parse(dataTable.Rows[0][2].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = $"DELETE FROM zapchast WHERE ID_Zapchasti = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE zapchast SET " +
               $"Naimenovanie_zapchasti = '{textBox1.Text}', " +
               $"Tsena = {numericUpDown1.Value} " +
               $"WHERE ID_Zapchasti = {id}";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
