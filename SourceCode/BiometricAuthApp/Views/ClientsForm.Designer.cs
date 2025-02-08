namespace BiometricAuthApp.Views
{
    partial class ClientsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridClients = new DataGridView();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtBirthDate = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtPassport = new TextBox();
            txtBU = new TextBox();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            btnSearch = new Button();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblMiddleName = new Label();
            lblBirthDate = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblPassport = new Label();
            lblBU = new Label();
            lblGender = new Label();
            cmbGender = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridClients).BeginInit();
            SuspendLayout();
            // 
            // dataGridClients
            // 
            dataGridClients.AllowUserToAddRows = false;
            dataGridClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridClients.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridClients.Font = new Font("Segoe UI", 9.75F);
            dataGridClients.Location = new Point(10, 36);
            dataGridClients.Name = "dataGridClients";
            dataGridClients.ReadOnly = true;
            dataGridClients.ScrollBars = ScrollBars.None;
            dataGridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.Size = new Size(823, 347);
            dataGridClients.TabIndex = 0;
            dataGridClients.SelectionChanged += DataGridClients_SelectionChanged;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtLastName.Location = new Point(103, 390);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(172, 20);
            txtLastName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtFirstName.Location = new Point(103, 416);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(172, 20);
            txtFirstName.TabIndex = 6;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtMiddleName.Location = new Point(103, 442);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(172, 20);
            txtMiddleName.TabIndex = 8;
            // 
            // txtBirthDate
            // 
            txtBirthDate.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtBirthDate.Location = new Point(103, 468);
            txtBirthDate.Name = "txtBirthDate";
            txtBirthDate.Size = new Size(172, 20);
            txtBirthDate.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtPhone.Location = new Point(435, 389);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(172, 20);
            txtPhone.TabIndex = 14;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtAddress.Location = new Point(435, 415);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(172, 20);
            txtAddress.TabIndex = 16;
            // 
            // txtPassport
            // 
            txtPassport.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtPassport.Location = new Point(435, 441);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(172, 20);
            txtPassport.TabIndex = 18;
            // 
            // txtBU
            // 
            txtBU.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtBU.Location = new Point(435, 467);
            txtBU.Name = "txtBU";
            txtBU.Size = new Size(172, 20);
            txtBU.TabIndex = 20;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.75F);
            txtSearch.Location = new Point(10, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск по фамилии...";
            txtSearch.Size = new Size(172, 25);
            txtSearch.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAdd.Location = new Point(10, 529);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(77, 26);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSave.Location = new Point(96, 529);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 26);
            btnSave.TabIndex = 22;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnDelete.Location = new Point(182, 529);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(77, 26);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Удалить";
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBack.Location = new Point(756, 529);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(77, 26);
            btnBack.TabIndex = 24;
            btnBack.Text = "Назад";
            btnBack.Click += BtnBack_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9.75F);
            btnSearch.Location = new Point(187, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(72, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Поиск";
            btnSearch.Click += BtnSearch_Click;
            // 
            // lblLastName
            // 
            lblLastName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblLastName.Location = new Point(10, 390);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(60, 17);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Фамилия:";
            // 
            // lblFirstName
            // 
            lblFirstName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblFirstName.Location = new Point(10, 416);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(60, 17);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "Имя:";
            // 
            // lblMiddleName
            // 
            lblMiddleName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblMiddleName.Location = new Point(10, 442);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(60, 17);
            lblMiddleName.TabIndex = 7;
            lblMiddleName.Text = "Отчество:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblBirthDate.Location = new Point(10, 468);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(86, 17);
            lblBirthDate.TabIndex = 9;
            lblBirthDate.Text = "Дата рождения:";
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPhone.Location = new Point(343, 390);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(60, 17);
            lblPhone.TabIndex = 13;
            lblPhone.Text = "Телефон:";
            // 
            // lblAddress
            // 
            lblAddress.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblAddress.Location = new Point(343, 416);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 17);
            lblAddress.TabIndex = 15;
            lblAddress.Text = "Адрес:";
            // 
            // lblPassport
            // 
            lblPassport.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPassport.Location = new Point(341, 441);
            lblPassport.Name = "lblPassport";
            lblPassport.Size = new Size(88, 17);
            lblPassport.TabIndex = 17;
            lblPassport.Text = "Паспорт:";
            // 
            // lblBU
            // 
            lblBU.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblBU.Location = new Point(343, 468);
            lblBU.Name = "lblBU";
            lblBU.Size = new Size(60, 17);
            lblBU.TabIndex = 19;
            lblBU.Text = "ВУ:";
            // 
            // lblGender
            // 
            lblGender.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblGender.Location = new Point(10, 494);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(60, 17);
            lblGender.TabIndex = 11;
            lblGender.Text = "Пол:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            cmbGender.Items.AddRange(new object[] { "Мужской", "Женский" });
            cmbGender.Location = new Point(103, 494);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(172, 21);
            cmbGender.TabIndex = 12;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 573);
            Controls.Add(dataGridClients);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblBirthDate);
            Controls.Add(txtBirthDate);
            Controls.Add(lblGender);
            Controls.Add(cmbGender);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblPassport);
            Controls.Add(txtPassport);
            Controls.Add(lblBU);
            Controls.Add(txtBU);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(859, 612);
            Name = "ClientsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Клиенты";
            ((System.ComponentModel.ISupportInitialize)dataGridClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridClients;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtBirthDate;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtPassport;
        private TextBox txtBU;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private Button btnBack;
        private Button btnSearch;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblMiddleName;
        private Label lblBirthDate;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblPassport;
        private Label lblBU;
        private Label lblGender;
        private ComboBox cmbGender;
    }
}
