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
    public partial class TableList : Form
    {
        private MySqlConnection connection;
        public TableList(MySqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new BrakForm(connection);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new DolzhnostForm(connection);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new KategoriaPostavshikaForm(connection);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new ZapchastForm(connection);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new VozvratBraka(connection);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new SkidkiForm(connection);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void TableList_Load(object sender, EventArgs e)
        {

        }
    }
}
