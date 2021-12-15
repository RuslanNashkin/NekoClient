using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RuslanNashkinNekoClientApp
    {
        public partial class AuthorizationForm : Form
        {
            public AuthorizationForm() => InitializeComponent();
            private void loginTextBox_TextChanged(object sender, EventArgs e) => UpdateAuthorizationButtonStatus();

            private void passwordTextBox_TextChanged(object sender, EventArgs e) => UpdateAuthorizationButtonStatus();

            private void UpdateAuthorizationButtonStatus() => authorizationButton.Enabled = loginTextBox.Text != "" && passwordTextBox.Text != "";

            private void authorizationButton_Click(object sender, EventArgs e)
            {
                var connection = new MySqlConnection($"host=127.0.0.1;user={loginTextBox.Text};password={passwordTextBox.Text};SSL Mode=0;Database=autoshop;");

                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    onAuthorizationFailed();
                    return;
                }

                var window = new TableList(connection);

                window.Show();
            }

            private void onAuthorizationFailed()
            {
                MessageBox.Show("Авторизация неудачна.", "Ошибка авторизации.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginTextBox.Text = "";
                passwordTextBox.Text = "";
                UpdateAuthorizationButtonStatus();
            }
        }
    }
