using System;
using System.Windows.Forms;
using BiometricAuthApp.Models;
using BiometricAuthApp.Services;

namespace BiometricAuthApp.Views
{
    public partial class AddClientForm : Form
    {
        private readonly ClientService _clientService = new();
        public Client NewClient { get; private set; }

        public AddClientForm()
        {
            InitializeComponent();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtBirthDate.Text))
            {
                MessageBox.Show(@"Пожалуйста, заполните обязательные поля", @"Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var client = new Client
                {
                    LastName = txtLastName.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(txtBirthDate.Text),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Passport = txtPassport.Text.Trim(),
                    BU = txtBU.Text.Trim()
                };

                NewClient = await _clientService.AddClientAsync(client);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Ошибка при сохранении: {ex.Message}", @"Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
