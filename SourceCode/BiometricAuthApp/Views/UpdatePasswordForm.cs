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
    public partial class UpdatePasswordForm : Form
    {
        private readonly AuthService authService = new();
        public UpdatePasswordForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = nameBox.Text;
            string oldPassword = oldPasswordBox.Text;
            string newPassword = newPasswordBox.Text;
            string repeatPassword = repeatPasswordBox.Text;
            try
            {
               await authService.ChangePassword(username, oldPassword, newPassword, repeatPassword);
                MessageBox.Show("Пароль успешно изменен", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ArgumentException ex )
            {
                MessageBox.Show(ex.Message, @"Ошибка смены пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
