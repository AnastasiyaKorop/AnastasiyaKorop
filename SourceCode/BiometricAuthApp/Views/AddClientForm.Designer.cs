namespace BiometricAuthApp.Views
{
    partial class AddClientForm
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
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtBirthDate = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtPassport = new TextBox();
            txtBU = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
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
            SuspendLayout();

            // Labels
            lblLastName.Location = new Point(12, 15);
            lblLastName.Size = new Size(100, 23);
            lblLastName.Text = "Фамилия *";

            lblFirstName.Location = new Point(12, 45);
            lblFirstName.Size = new Size(100, 23);
            lblFirstName.Text = "Имя *";

            lblMiddleName.Location = new Point(12, 75);
            lblMiddleName.Size = new Size(100, 23);
            lblMiddleName.Text = "Отчество";

            lblBirthDate.Location = new Point(12, 105);
            lblBirthDate.Size = new Size(100, 23);
            lblBirthDate.Text = "Дата рождения *";

            lblGender.Location = new Point(12, 135);
            lblGender.Size = new Size(100, 23);
            lblGender.Text = "Пол";

            lblPhone.Location = new Point(12, 165);
            lblPhone.Size = new Size(100, 23);
            lblPhone.Text = "Телефон";

            lblAddress.Location = new Point(12, 195);
            lblAddress.Size = new Size(100, 23);
            lblAddress.Text = "Адрес";

            lblPassport.Location = new Point(12, 225);
            lblPassport.Size = new Size(100, 23);
            lblPassport.Text = "Паспорт";

            lblBU.Location = new Point(12, 255);
            lblBU.Size = new Size(100, 23);
            lblBU.Text = "БУ";

            // TextBoxes and ComboBox
            txtLastName.Location = new Point(120, 12);
            txtLastName.Size = new Size(200, 23);

            txtFirstName.Location = new Point(120, 42);
            txtFirstName.Size = new Size(200, 23);

            txtMiddleName.Location = new Point(120, 72);
            txtMiddleName.Size = new Size(200, 23);

            txtBirthDate.Location = new Point(120, 102);
            txtBirthDate.Size = new Size(200, 23);

            cmbGender.Location = new Point(120, 132);
            cmbGender.Size = new Size(200, 23);
            cmbGender.Items.AddRange(new object[] { "Мужской", "Женский" });
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;

            txtPhone.Location = new Point(120, 162);
            txtPhone.Size = new Size(200, 23);

            txtAddress.Location = new Point(120, 192);
            txtAddress.Size = new Size(200, 23);

            txtPassport.Location = new Point(120, 222);
            txtPassport.Size = new Size(200, 23);

            txtBU.Location = new Point(120, 252);
            txtBU.Size = new Size(200, 23);

            // Buttons
            btnSave.Location = new Point(120, 290);
            btnSave.Size = new Size(90, 30);
            btnSave.Text = "Сохранить";
            btnSave.Click += BtnSave_Click;

            btnCancel.Location = new Point(230, 290);
            btnCancel.Size = new Size(90, 30);
            btnCancel.Text = "Отмена";
            btnCancel.Click += BtnCancel_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 341);
            Controls.AddRange(new Control[] {
                lblLastName,
                txtLastName,
                lblFirstName,
                txtFirstName,
                lblMiddleName,
                txtMiddleName,
                lblBirthDate,
                txtBirthDate,
                lblGender,
                cmbGender,
                lblPhone,
                txtPhone,
                lblAddress,
                txtAddress,
                lblPassport,
                txtPassport,
                lblBU,
                txtBU,
                btnSave,
                btnCancel
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddClientForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtBirthDate;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtPassport;
        private TextBox txtBU;
        private Button btnSave;
        private Button btnCancel;
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
