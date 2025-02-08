using BiometricAuthApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiometricAuthApp.Views
{
    public partial class NewUserForm : Form
    {
        private readonly AuthService authService = new();
        public NewUserForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = nameBox.Text;
            string password = passwordBox.Text;
            string passwordRepeat = repeatPasswordBox.Text;
            try
            {
                await authService.AddUser(username, password, passwordRepeat);
                MessageBox.Show($"Пользователь {username} успешно добавлен", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка добавления пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
