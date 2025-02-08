using BiometricAuthApp.Models;
using BiometricAuthApp.Services;

namespace BiometricAuthApp.Views
{
    public partial class EmployeesForm : Form
    {
        private readonly EmployeeService _employeeService;
        private Employee _currentEmployee;
        private bool _isModified;

        public EmployeesForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _isModified = false;
            btnSave.Enabled = false;
            InitializeEventHandlers();
            InitializeDataGridView();
            LoadEmployees();
        }

        private void InitializeEventHandlers()
        {
            // Добавляем обработчики событий для отслеживания изменений
            txtEmployeeCode.TextChanged += TextBox_TextChanged;
            txtPositionCode.TextChanged += TextBox_TextChanged;
            txtLastName.TextChanged += TextBox_TextChanged;
            txtFirstName.TextChanged += TextBox_TextChanged;
            txtMiddleName.TextChanged += TextBox_TextChanged;
            txtBirthDate.TextChanged += TextBox_TextChanged;
            txtPhone.TextChanged += TextBox_TextChanged;
            txtAddress.TextChanged += TextBox_TextChanged;

            // Добавляем обработчики для кнопок
            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnPhoto.Click += BtnPhoto_Click;
            btnBack.Click += BtnBack_Click;
            btnToScene.Click += BtnToScene_Click;

            // Добавляем обработчик для таблицы
            dataGridEmployees.SelectionChanged += DataGridEmployees_SelectionChanged;
        }

        private void InitializeDataGridView()
        {
            // Настройка внешнего вида
            dataGridEmployees.AutoGenerateColumns = false;
            dataGridEmployees.AllowUserToAddRows = false;
            dataGridEmployees.AllowUserToDeleteRows = false;
            dataGridEmployees.ReadOnly = true;
            dataGridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEmployees.MultiSelect = false;
            dataGridEmployees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridEmployees.RowHeadersVisible = false;
            dataGridEmployees.AllowUserToResizeRows = false;
            dataGridEmployees.VirtualMode = true;

            // Настройка скроллбара
            dataGridEmployees.ScrollBars = ScrollBars.Both;

            // Очистка и добавление колонок
            dataGridEmployees.Columns.Clear();

            var imageColumn = new DataGridViewImageColumn
            {
                Name = "Photo",
                HeaderText = @"Фото",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };

            dataGridEmployees.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "EmployeeCode",
                    HeaderText = @"Код сотрудника",
                    Width = 120,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "LastName",
                    HeaderText = @"Фамилия",
                    Width = 150,
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
                    DataPropertyName = "PositionCode",
                    HeaderText = @"Код Должности",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                imageColumn
            );

            // Настройка заголовков колонок
            dataGridEmployees.EnableHeadersVisualStyles = false;
            dataGridEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridEmployees.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridEmployees.Font, FontStyle.Bold);
            dataGridEmployees.ColumnHeadersHeight = 30;
            dataGridEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Настройка строк
            dataGridEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridEmployees.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridEmployees.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Настройка размера строк для фотографий
            dataGridEmployees.RowTemplate.Height = 100;

            // Добавляем обработчик для отрисовки изображений
            dataGridEmployees.CellFormatting += DataGridEmployees_CellFormatting;
        }

        private void DataGridEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridEmployees.Columns["Photo"].Index && e.Value != null)
            {
                if (e.Value is byte[] photoData)
                {
                    e.Value = CreateImageCopy(photoData);
                    e.FormattingApplied = true;
                }
            }
        }

        private Image CreateImageCopy(byte[] photoData)
        {
            if (photoData == null || photoData.Length == 0)
                return null;

            try
            {
                using var ms = new MemoryStream(photoData);
                // Создаем новую копию изображения
                return new Bitmap(Image.FromStream(ms));
            }
            catch
            {
                return null;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentEmployee == null) return;

            var textBox = (TextBox)sender;
            string currentValue = textBox.Text;
            string originalValue = GetOriginalValue(textBox);

            _isModified = IsAnyFieldModified();
            btnSave.Enabled = _isModified;
        }

        private string GetOriginalValue(TextBox textBox)
        {
            if (_currentEmployee == null) return string.Empty;

            return textBox.Name switch
            {
                "txtEmployeeCode" => _currentEmployee.EmployeeCode,
                "txtPositionCode" => _currentEmployee.PositionCode,
                "txtLastName" => _currentEmployee.LastName,
                "txtFirstName" => _currentEmployee.FirstName,
                "txtMiddleName" => _currentEmployee.MiddleName,
                "txtBirthDate" => _currentEmployee.DateOfBirth?.ToString("dd.MM.yyyy"),
                "txtPhone" => _currentEmployee.Phone,
                "txtAddress" => _currentEmployee.Address,
                _ => string.Empty
            };
        }

        private bool IsAnyFieldModified()
        {
            if (_currentEmployee == null) return false;

            return txtEmployeeCode.Text.Trim() != _currentEmployee.EmployeeCode ||
                   txtPositionCode.Text.Trim() != _currentEmployee.PositionCode ||
                   txtLastName.Text.Trim() != _currentEmployee.LastName ||
                   txtFirstName.Text.Trim() != _currentEmployee.FirstName ||
                   (txtMiddleName.Text.Trim() != (_currentEmployee.MiddleName ?? string.Empty)) ||
                   txtBirthDate.Text != _currentEmployee.DateOfBirth?.ToString("dd.MM.yyyy") ||
                   (txtPhone.Text.Trim() != (_currentEmployee.Phone ?? string.Empty)) ||
                   (txtAddress.Text.Trim() != (_currentEmployee.Address ?? string.Empty));
        }

        private async void LoadEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                if (employees == null)
                {
                    MessageBox.Show("Не удалось загрузить данные сотрудников", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Отключаем привязку на время обновления
                dataGridEmployees.DataSource = null;
                dataGridEmployees.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridEmployees.CurrentRow != null)
            {
                _currentEmployee = (Employee)dataGridEmployees.CurrentRow.DataBoundItem;
                DisplayEmployeeDetails(_currentEmployee);
                _isModified = false;
                btnSave.Enabled = false;
            }
        }

        private void DisplayEmployeeDetails(Employee employee)
        {
            if (employee == null) return;

            txtEmployeeCode.Text = employee.EmployeeCode;
            txtPositionCode.Text = employee.PositionCode;
            txtLastName.Text = employee.LastName;
            txtFirstName.Text = employee.FirstName;
            txtMiddleName.Text = employee.MiddleName ?? string.Empty;
            txtBirthDate.Text = employee.DateOfBirth?.ToString("dd.MM.yyyy");
            txtPhone.Text = employee.Phone ?? string.Empty;
            txtAddress.Text = employee.Address ?? string.Empty;

            try
            {
                if (employee.Photo != null && employee.Photo.Length > 0)
                {
                    using var ms = new MemoryStream(employee.Photo);
                    picPhoto.Image?.Dispose();
                    picPhoto.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фото: {ex.Message}", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                picPhoto.Image = null;
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeCode.Text) ||
                    string.IsNullOrWhiteSpace(txtPositionCode.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtBirthDate.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var employee = new Employee
                {
                    EmployeeCode = txtEmployeeCode.Text.Trim(),
                    PositionCode = txtPositionCode.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(txtBirthDate.Text),
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim()
                };

                if (picPhoto.Image != null)
                {
                    // Создаем новую копию изображения
                    using (var originalImage = new Bitmap(picPhoto.Image))
                    using (var ms = new MemoryStream())
                    {
                        originalImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        employee.Photo = ms.ToArray();
                    }
                }

                var newEmp =await _employeeService.AddEmployeeAsync(employee);
                LoadEmployees();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Ошибка при добавлении сотрудника: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (_currentEmployee == null || !_isModified) return;

            try
            {
                _currentEmployee.EmployeeCode = txtEmployeeCode.Text;
                _currentEmployee.PositionCode = txtPositionCode.Text;
                _currentEmployee.LastName = txtLastName.Text;
                _currentEmployee.FirstName = txtFirstName.Text;
                _currentEmployee.MiddleName = txtMiddleName.Text;
                _currentEmployee.DateOfBirth = DateTime.Parse(txtBirthDate.Text);
                _currentEmployee.Phone = txtPhone.Text;
                _currentEmployee.Address = txtAddress.Text;

                if (picPhoto.Image != null)
                {
                    using var ms = new MemoryStream();
                    picPhoto.Image.Save(ms, picPhoto.Image.RawFormat);
                    _currentEmployee.Photo = ms.ToArray();
                }

                await _employeeService.UpdateEmployeeAsync(_currentEmployee);
                LoadEmployees();
                _isModified = false;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Ошибка при обновлении сотрудника: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_currentEmployee is null) return;

            if (MessageBox.Show(@"Are you sure you want to delete this employee?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _employeeService.DeleteEmployeeAsync(_currentEmployee.Id);
                    LoadEmployees();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Ошибка при удалении сотрудника: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPhoto_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = @"Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG",
                Title = @"Select Photo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picPhoto.Image = Image.FromFile(openFileDialog.FileName);
                _isModified = true;
                btnSave.Enabled = true;
            }
        }

        private void ClearForm()
        {
            txtEmployeeCode.Text = string.Empty;
            txtPositionCode.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;

            if (picPhoto.Image != null)
            {
                picPhoto.Image.Dispose();
                picPhoto.Image = null;
            }

            _currentEmployee = null;
            _isModified = false;
            btnSave.Enabled = false;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (_isModified)
            {
                var result = MessageBox.Show(@"У вас есть несохраненные изменения. Хотите сохранить их перед выходом?",
                    @"Несохраненные изменения",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        BtnSave_Click(sender, e);
                        Close();
                        break;
                    case DialogResult.No:
                        Close();
                        break;
                }
            }
            else
            {
                Close();
            }
        }

        private void BtnToScene_Click(object sender, EventArgs e)
        {
            if (_currentEmployee == null)
            {
                MessageBox.Show(@"Пожалуйста, выберите сотрудника", @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(@"Функция вынесения на смену будет реализована позже", @"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
