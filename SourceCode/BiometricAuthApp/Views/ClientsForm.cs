using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BiometricAuthApp.Models;
using BiometricAuthApp.Services;

namespace BiometricAuthApp.Views
{
    public partial class ClientsForm : Form
    {
        private readonly ClientService _clientService = new();
        private List<Client> _clients = new();
        private Client _currentClient;
        private bool _isModified;
        private BindingSource _bindingSource;

        public ClientsForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            _bindingSource = new BindingSource();
            dataGridClients.DataSource = _bindingSource;
            LoadClients();
            InitializeEventHandlers();
        }

        private void InitializeDataGridView()
        {
            // Настройка внешнего вида
            dataGridClients.AutoGenerateColumns = false;
            dataGridClients.AllowUserToAddRows = false;
            dataGridClients.AllowUserToDeleteRows = false;
            dataGridClients.ReadOnly = true;
            dataGridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.MultiSelect = false;
            dataGridClients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridClients.RowHeadersVisible = false;
            dataGridClients.AllowUserToResizeRows = false;

            // Настройка скроллбара
            dataGridClients.ScrollBars = ScrollBars.Both;

            // Очистка и добавление колонок
            dataGridClients.Columns.Clear();
            dataGridClients.Columns.AddRange(
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "LastName", 
                    HeaderText = @"Фамилия", 
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "FirstName", 
                    HeaderText = @"Имя", 
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "MiddleName", 
                    HeaderText = @"Отчество", 
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "DateOfBirth", 
                    HeaderText = @"Дата рождения",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "Gender", 
                    HeaderText = @"Пол", 
                    Width = 60,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 60
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "Phone", 
                    HeaderText = @"Телефон", 
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "Address", 
                    HeaderText = @"Адрес", 
                    Width = 150,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 150
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "Passport", 
                    HeaderText = @"Паспорт", 
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn 
                { 
                    DataPropertyName = "BU", 
                    HeaderText = @"ВУ", 
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                }
            );

            // Настройка заголовков колонок
            dataGridClients.EnableHeadersVisualStyles = false;
            dataGridClients.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridClients.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridClients.Font, FontStyle.Bold);
            dataGridClients.ColumnHeadersHeight = 30;
            dataGridClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Настройка строк
            dataGridClients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridClients.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridClients.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private async void LoadClients()
        {
            try
            {
                _clients = await _clientService.GetAllClientsAsync();
                _bindingSource.DataSource = _clients;
                
                if (_clients.Any())
                {
                    dataGridClients.Rows[0].Selected = true;
                }
                else
                {
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEventHandlers()
        {
            txtLastName.TextChanged += TextBox_TextChanged;
            txtFirstName.TextChanged += TextBox_TextChanged;
            txtMiddleName.TextChanged += TextBox_TextChanged;
            txtBirthDate.TextChanged += TextBox_TextChanged;
            txtPhone.TextChanged += TextBox_TextChanged;
            txtAddress.TextChanged += TextBox_TextChanged;
            txtPassport.TextChanged += TextBox_TextChanged;
            txtBU.TextChanged += TextBox_TextChanged;
        }

        private void DisplayClientDetails(Client client)
        {
            if (client == null)
            {
                ClearForm();
                return;
            }

            txtLastName.Text = client.LastName;
            txtFirstName.Text = client.FirstName;
            txtMiddleName.Text = client.MiddleName;
            txtBirthDate.Text = client.DateOfBirth?.ToShortDateString();
            txtPhone.Text = client.Phone;
            txtAddress.Text = client.Address;
            txtPassport.Text = client.Passport;
            txtBU.Text = client.BU;
            cmbGender.Text = client.Gender;
        }

        private void ClearForm()
        {
            _currentClient = null;
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPassport.Text = string.Empty;
            txtBU.Text = string.Empty;
            cmbGender.Text = string.Empty;
            _isModified = false;
            btnSave.Enabled = false;
        }

        private void DataGridClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridClients.CurrentRow?.DataBoundItem is Client client)
            {
                _currentClient = client;
                DisplayClientDetails(_currentClient);
                _isModified = false;
                btnSave.Enabled = false;
            }
            else
            {
                ClearForm();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            var filteredClients = _clients.Where(c => 
                c.LastName.ToLower().Contains(searchText) ||
                c.FirstName.ToLower().Contains(searchText) ||
                c.MiddleName?.ToLower().Contains(searchText) == true ||
                c.Phone?.ToLower().Contains(searchText) == true
            ).ToList();

            _bindingSource.DataSource = filteredClients;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddClientForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newClient = addForm.NewClient;
                    _clients.Add(newClient);
                    _bindingSource.DataSource = null;
                    _bindingSource.DataSource = _clients;
                    
                    // Выбираем добавленного клиента
                    var index = _clients.IndexOf(newClient);
                    if (index >= 0 && index < dataGridClients.Rows.Count)
                    {
                        dataGridClients.Rows[index].Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Ошибка при добавлении клиента: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentClient == null || !_isModified) return;

            try
            {
                _currentClient.LastName = txtLastName.Text;
                _currentClient.FirstName = txtFirstName.Text;
                _currentClient.MiddleName = txtMiddleName.Text;
                _currentClient.DateOfBirth = DateTime.Parse(txtBirthDate.Text);
                _currentClient.Phone = txtPhone.Text;
                _currentClient.Address = txtAddress.Text;
                _currentClient.Passport = txtPassport.Text;
                _currentClient.BU = txtBU.Text;
                _currentClient.Gender = cmbGender.Text;

                await _clientService.UpdateClientAsync(_currentClient);
                _isModified = false;
                btnSave.Enabled = false;
                
                // Обновляем отображение
                _bindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_currentClient == null) return;

            if (MessageBox.Show("Вы действительно хотите удалить этого клиента?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _clientService.DeleteClientAsync(_currentClient.Id);
                    _clients.Remove(_currentClient);
                    _bindingSource.DataSource = null;
                    _bindingSource.DataSource = _clients;
                    
                    if (_clients.Any())
                    {
                        dataGridClients.Rows[0].Selected = true;
                    }
                    else
                    {
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentClient != null)
            {
                _isModified = true;
                btnSave.Enabled = true;
            }
        }
    }
}
