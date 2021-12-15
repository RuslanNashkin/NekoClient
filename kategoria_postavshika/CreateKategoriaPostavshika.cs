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
    public partial class CreateKategoriaPostavshika : Form
    {
        MySqlConnection connection;
        public CreateKategoriaPostavshika(MySqlConnection connection)
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
                ("INSERT INTO kategoria_postavshika (ID_Kategoria_postavshika, Tip_postavshika) " +
                " VALUES (" + getNextId() + ",'" + textBox1.Text + "')", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Close();
        }

        private int getNextId()
        {
            var query = $"SELECT MAX(ID_Kategoria_postavshika) from kategoria_postavshika;";
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
