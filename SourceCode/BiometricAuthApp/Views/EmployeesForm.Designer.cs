namespace BiometricAuthApp.Views
{
    partial class EmployeesForm
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
            dataGridEmployees = new DataGridView();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtBirthDate = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtEmployeeCode = new TextBox();
            txtPositionCode = new TextBox();
            btnAdd = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnPhoto = new Button();
            btnBack = new Button();
            btnToScene = new Button();
            picPhoto = new PictureBox();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblMiddleName = new Label();
            lblBirthDate = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblPhoto = new Label();
            lblEmployeeCode = new Label();
            lblPositionCode = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // dataGridEmployees
            // 
            dataGridEmployees.AllowUserToAddRows = false;
            dataGridEmployees.AllowUserToDeleteRows = false;
            dataGridEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridEmployees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridEmployees.Font = new Font("Segoe UI", 9.75F);
            dataGridEmployees.Location = new Point(10, 10);
            dataGridEmployees.MultiSelect = false;
            dataGridEmployees.Name = "dataGridEmployees";
            dataGridEmployees.ReadOnly = true;
            dataGridEmployees.RowHeadersVisible = false;
            dataGridEmployees.ScrollBars = ScrollBars.Horizontal;
            dataGridEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEmployees.Size = new Size(932, 347);
            dataGridEmployees.TabIndex = 0;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtLastName.Location = new Point(166, 418);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(172, 20);
            txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtFirstName.Location = new Point(166, 445);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(172, 20);
            txtFirstName.TabIndex = 2;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtMiddleName.Location = new Point(166, 471);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(172, 20);
            txtMiddleName.TabIndex = 3;
            // 
            // txtBirthDate
            // 
            txtBirthDate.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtBirthDate.Location = new Point(166, 498);
            txtBirthDate.Name = "txtBirthDate";
            txtBirthDate.Size = new Size(172, 20);
            txtBirthDate.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtPhone.Location = new Point(411, 364);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(172, 20);
            txtPhone.TabIndex = 5;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtAddress.Location = new Point(411, 390);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(172, 20);
            txtAddress.TabIndex = 6;
            // 
            // txtEmployeeCode
            // 
            txtEmployeeCode.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtEmployeeCode.Location = new Point(166, 364);
            txtEmployeeCode.Name = "txtEmployeeCode";
            txtEmployeeCode.Size = new Size(172, 20);
            txtEmployeeCode.TabIndex = 9;
            // 
            // txtPositionCode
            // 
            txtPositionCode.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            txtPositionCode.Location = new Point(166, 391);
            txtPositionCode.Name = "txtPositionCode";
            txtPositionCode.Size = new Size(172, 20);
            txtPositionCode.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAdd.Location = new Point(10, 546);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(77, 26);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Добавить";
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSave.Location = new Point(96, 546);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(77, 26);
            btnSave.TabIndex = 13;
            btnSave.Text = "Сохранить";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnDelete.Location = new Point(182, 546);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(77, 26);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Удалить";
            // 
            // btnPhoto
            // 
            btnPhoto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnPhoto.Location = new Point(700, 547);
            btnPhoto.Name = "btnPhoto";
            btnPhoto.Size = new Size(146, 26);
            btnPhoto.TabIndex = 15;
            btnPhoto.Text = "Загрузить фото";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBack.Location = new Point(856, 547);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(77, 26);
            btnBack.TabIndex = 16;
            btnBack.Text = "Назад";
            // 
            // btnToScene
            // 
            btnToScene.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnToScene.Location = new Point(267, 546);
            btnToScene.Name = "btnToScene";
            btnToScene.Size = new Size(147, 26);
            btnToScene.TabIndex = 17;
            btnToScene.Text = "Вывести на смену";
            // 
            // picPhoto
            // 
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.Location = new Point(700, 391);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(146, 148);
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picPhoto.TabIndex = 18;
            picPhoto.TabStop = false;
            // 
            // lblLastName
            // 
            lblLastName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblLastName.Location = new Point(10, 416);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(60, 17);
            lblLastName.TabIndex = 19;
            lblLastName.Text = "Фамилия:";
            // 
            // lblFirstName
            // 
            lblFirstName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblFirstName.Location = new Point(10, 442);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(77, 17);
            lblFirstName.TabIndex = 20;
            lblFirstName.Text = "Имя:";
            // 
            // lblMiddleName
            // 
            lblMiddleName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblMiddleName.Location = new Point(10, 468);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(60, 17);
            lblMiddleName.TabIndex = 21;
            lblMiddleName.Text = "Отчество:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblBirthDate.Location = new Point(10, 494);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(86, 17);
            lblBirthDate.TabIndex = 22;
            lblBirthDate.Text = "Дата рождения:";
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPhone.Location = new Point(343, 364);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(60, 17);
            lblPhone.TabIndex = 24;
            lblPhone.Text = "Телефон:";
            // 
            // lblAddress
            // 
            lblAddress.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblAddress.Location = new Point(343, 390);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 17);
            lblAddress.TabIndex = 25;
            lblAddress.Text = "Адрес:";
            // 
            // lblPhoto
            // 
            lblPhoto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPhoto.Location = new Point(700, 365);
            lblPhoto.Name = "lblPhoto";
            lblPhoto.Size = new Size(60, 17);
            lblPhoto.TabIndex = 28;
            lblPhoto.Text = "Фото:";
            // 
            // lblEmployeeCode
            // 
            lblEmployeeCode.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblEmployeeCode.Location = new Point(10, 364);
            lblEmployeeCode.Name = "lblEmployeeCode";
            lblEmployeeCode.Size = new Size(117, 17);
            lblEmployeeCode.TabIndex = 29;
            lblEmployeeCode.Text = "Код сотрудника:";
            // 
            // lblPositionCode
            // 
            lblPositionCode.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPositionCode.Location = new Point(10, 390);
            lblPositionCode.Name = "lblPositionCode";
            lblPositionCode.Size = new Size(117, 17);
            lblPositionCode.TabIndex = 30;
            lblPositionCode.Text = "Код должности:";
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 590);
            Controls.Add(dataGridEmployees);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtMiddleName);
            Controls.Add(txtBirthDate);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtEmployeeCode);
            Controls.Add(txtPositionCode);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnPhoto);
            Controls.Add(btnBack);
            Controls.Add(btnToScene);
            Controls.Add(picPhoto);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblMiddleName);
            Controls.Add(lblBirthDate);
            Controls.Add(lblPhone);
            Controls.Add(lblAddress);
            Controls.Add(lblPhoto);
            Controls.Add(lblEmployeeCode);
            Controls.Add(lblPositionCode);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
            MinimumSize = new Size(859, 629);
            Name = "EmployeesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сотрудники";
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridEmployees;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtBirthDate;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtEmployeeCode;
        private TextBox txtPositionCode;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private Button btnPhoto;
        private Button btnBack;
        private Button btnToScene;
        private PictureBox picPhoto;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblMiddleName;
        private Label lblBirthDate;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblPhoto;
        private Label lblEmployeeCode;
        private Label lblPositionCode;
    }
}
