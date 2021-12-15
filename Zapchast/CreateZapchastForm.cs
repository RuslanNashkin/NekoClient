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
    public partial class CreateZapchastForm : Form
    {
        MySqlConnection connection;
        public CreateZapchastForm(MySqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("'"))
            {
                return;
            }
            MySqlDataAdapter da = new MySqlDataAdapter
                ("INSERT INTO zapchast (ID_Zapchasti, Naimenovanie_zapchasti, Tsena) " +
                " VALUES (" + getNextId() + ",'" + textBox1.Text + "','" +
                numericUpDown1.Value + "')", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Close();
        }

        private int getNextId()
        {
            var query = $"SELECT MAX(ID_Zapchasti) from zapchast;";
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
