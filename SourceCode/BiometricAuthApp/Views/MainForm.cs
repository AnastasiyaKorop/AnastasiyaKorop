using System;
using System.Windows.Forms;

namespace BiometricAuthApp.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            var employeesForm = new EmployeesForm();
            employeesForm.ShowDialog();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            var clientsFormForm = new ClientsForm();
            clientsFormForm.ShowDialog();
        }

        private void BtnEncryptionSettings_Click(object sender, EventArgs e)
        {
            var encryptionForm = new EncryptionForm();
            encryptionForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newFaceForm = new NewAdminFaceScannerForm();
            newFaceForm.ShowDialog();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            var newFaceForm = new UpdatePasswordForm();
            newFaceForm.ShowDialog();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            var newFaceForm = new NewUserForm();
            newFaceForm.ShowDialog();
        }

        private void clientEmployeeButton_Click(object sender, EventArgs e)
        {
            var newFaceForm = new UserEmployeeForm();
            newFaceForm.ShowDialog();
        }
    }
}
