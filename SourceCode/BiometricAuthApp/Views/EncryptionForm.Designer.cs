namespace BiometricAuthApp.Views
{
    partial class EncryptionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSaveKeys;
        private System.Windows.Forms.Button btnLoadKeys;
        private System.Windows.Forms.Button btnSignFile;
        private System.Windows.Forms.Button btnVerifyFile;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;

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
            btnGenerate = new Button();
            btnSaveKeys = new Button();
            btnLoadKeys = new Button();
            btnSignFile = new Button();
            btnVerifyFile = new Button();
            txtB = new TextBox();
            txtX = new TextBox();
            txtY = new TextBox();
            lblB = new Label();
            lblX = new Label();
            lblY = new Label();
            EncodeButton = new Button();
            DecodeButton = new Button();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 211);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(100, 30);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Генерация";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += GenerateButton_Click;
            // 
            // btnSaveKeys
            // 
            btnSaveKeys.Location = new Point(234, 211);
            btnSaveKeys.Name = "btnSaveKeys";
            btnSaveKeys.Size = new Size(100, 30);
            btnSaveKeys.TabIndex = 1;
            btnSaveKeys.Text = "Сохранить";
            btnSaveKeys.UseVisualStyleBackColor = true;
            btnSaveKeys.Click += SaveKeysButton_Click;
            // 
            // btnLoadKeys
            // 
            btnLoadKeys.Location = new Point(128, 211);
            btnLoadKeys.Name = "btnLoadKeys";
            btnLoadKeys.Size = new Size(100, 30);
            btnLoadKeys.TabIndex = 2;
            btnLoadKeys.Text = "Загрузить";
            btnLoadKeys.UseVisualStyleBackColor = true;
            btnLoadKeys.Click += LoadKeysButton_Click;
            // 
            // btnSignFile
            // 
            btnSignFile.Location = new Point(234, 283);
            btnSignFile.Name = "btnSignFile";
            btnSignFile.Size = new Size(100, 30);
            btnSignFile.TabIndex = 3;
            btnSignFile.Text = "Подписать файл";
            btnSignFile.UseVisualStyleBackColor = true;
            btnSignFile.Click += SignFileButton_Click;
            // 
            // btnVerifyFile
            // 
            btnVerifyFile.Location = new Point(128, 283);
            btnVerifyFile.Name = "btnVerifyFile";
            btnVerifyFile.Size = new Size(100, 30);
            btnVerifyFile.TabIndex = 4;
            btnVerifyFile.Text = "Проверить файл";
            btnVerifyFile.UseVisualStyleBackColor = true;
            btnVerifyFile.Click += VerifyFileButton_Click;
            // 
            // txtB
            // 
            txtB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtB.Location = new Point(134, 12);
            txtB.Name = "txtB";
            txtB.Size = new Size(200, 23);
            txtB.TabIndex = 7;
            // 
            // txtX
            // 
            txtX.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtX.Location = new Point(134, 41);
            txtX.Name = "txtX";
            txtX.Size = new Size(200, 23);
            txtX.TabIndex = 10;
            // 
            // txtY
            // 
            txtY.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtY.Location = new Point(134, 71);
            txtY.Name = "txtY";
            txtY.Size = new Size(200, 23);
            txtY.TabIndex = 11;
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblB.Location = new Point(12, 12);
            lblB.Name = "lblB";
            lblB.Size = new Size(116, 15);
            lblB.TabIndex = 14;
            lblB.Text = "Ключ B (параметр):";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblX.Location = new Point(12, 41);
            lblX.Name = "lblX";
            lblX.Size = new Size(116, 15);
            lblX.TabIndex = 17;
            lblX.Text = "Ключ X (параметр):";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblY.Location = new Point(12, 71);
            lblY.Name = "lblY";
            lblY.Size = new Size(116, 15);
            lblY.TabIndex = 18;
            lblY.Text = "Ключ Y (параметр):";
            // 
            // EncodeButton
            // 
            EncodeButton.Location = new Point(128, 247);
            EncodeButton.Name = "EncodeButton";
            EncodeButton.Size = new Size(100, 30);
            EncodeButton.TabIndex = 20;
            EncodeButton.Text = "Зашифровать";
            EncodeButton.UseVisualStyleBackColor = true;
            EncodeButton.Click += EncodeButton_Click_1;
            // 
            // DecodeButton
            // 
            DecodeButton.Location = new Point(234, 247);
            DecodeButton.Name = "DecodeButton";
            DecodeButton.Size = new Size(100, 30);
            DecodeButton.TabIndex = 19;
            DecodeButton.Text = "Расшифровать";
            DecodeButton.UseVisualStyleBackColor = true;
            DecodeButton.Click += DecodeButton_Click;
            // 
            // EncryptionForm
            // 
            ClientSize = new Size(353, 325);
            Controls.Add(EncodeButton);
            Controls.Add(DecodeButton);
            Controls.Add(lblY);
            Controls.Add(lblX);
            Controls.Add(lblB);
            Controls.Add(txtY);
            Controls.Add(txtX);
            Controls.Add(txtB);
            Controls.Add(btnVerifyFile);
            Controls.Add(btnSignFile);
            Controls.Add(btnLoadKeys);
            Controls.Add(btnSaveKeys);
            Controls.Add(btnGenerate);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Name = "EncryptionForm";
            Text = "Шифрование";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button EncodeButton;
        private Button DecodeButton;
    }
}
