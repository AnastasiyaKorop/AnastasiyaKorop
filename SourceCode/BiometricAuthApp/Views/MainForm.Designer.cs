namespace BiometricAuthApp.Views 
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEmployees = new Button();
            btnUsers = new Button();
            btnEncryptionSettings = new Button();
            button1 = new Button();
            changePasswordButton = new Button();
            addUserButton = new Button();
            clientEmployeeButton = new Button();
            SuspendLayout();
            // 
            // btnEmployees
            // 
            btnEmployees.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEmployees.Location = new Point(14, 14);
            btnEmployees.Margin = new Padding(4, 3, 4, 3);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(303, 46);
            btnEmployees.TabIndex = 0;
            btnEmployees.Text = "Управление сотрудниками";
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += BtnEmployees_Click;
            // 
            // btnUsers
            // 
            btnUsers.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUsers.Location = new Point(14, 67);
            btnUsers.Margin = new Padding(4, 3, 4, 3);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(303, 46);
            btnUsers.TabIndex = 1;
            btnUsers.Text = "Управление пользователями";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += BtnUsers_Click;
            // 
            // btnEncryptionSettings
            // 
            btnEncryptionSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEncryptionSettings.Location = new Point(13, 171);
            btnEncryptionSettings.Margin = new Padding(4, 3, 4, 3);
            btnEncryptionSettings.Name = "btnEncryptionSettings";
            btnEncryptionSettings.Size = new Size(303, 46);
            btnEncryptionSettings.TabIndex = 2;
            btnEncryptionSettings.Text = "Настройки шифрования";
            btnEncryptionSettings.UseVisualStyleBackColor = true;
            btnEncryptionSettings.Click += BtnEncryptionSettings_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(11, 223);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(303, 46);
            button1.TabIndex = 3;
            button1.Text = "Сканировать лицо";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // changePasswordButton
            // 
            changePasswordButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            changePasswordButton.Location = new Point(12, 275);
            changePasswordButton.Margin = new Padding(4, 3, 4, 3);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(303, 46);
            changePasswordButton.TabIndex = 4;
            changePasswordButton.Text = "Изменить пароль";
            changePasswordButton.UseVisualStyleBackColor = true;
            changePasswordButton.Click += changePasswordButton_Click;
            // 
            // addUserButton
            // 
            addUserButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addUserButton.Location = new Point(12, 327);
            addUserButton.Margin = new Padding(4, 3, 4, 3);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(303, 46);
            addUserButton.TabIndex = 5;
            addUserButton.Text = "Добавить пользователя";
            addUserButton.UseVisualStyleBackColor = true;
            addUserButton.Click += addUserButton_Click;
            // 
            // clientEmployeeButton
            // 
            clientEmployeeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clientEmployeeButton.Location = new Point(15, 119);
            clientEmployeeButton.Margin = new Padding(4, 3, 4, 3);
            clientEmployeeButton.Name = "clientEmployeeButton";
            clientEmployeeButton.Size = new Size(303, 46);
            clientEmployeeButton.TabIndex = 6;
            clientEmployeeButton.Text = "Сотрудники - пользователи";
            clientEmployeeButton.UseVisualStyleBackColor = true;
            clientEmployeeButton.Click += clientEmployeeButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 390);
            Controls.Add(clientEmployeeButton);
            Controls.Add(addUserButton);
            Controls.Add(changePasswordButton);
            Controls.Add(button1);
            Controls.Add(btnEncryptionSettings);
            Controls.Add(btnUsers);
            Controls.Add(btnEmployees);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnEncryptionSettings;
        private Button button1;
        private Button changePasswordButton;
        private Button addUserButton;
        private Button clientEmployeeButton;
    }
}
