namespace BiometricAuthApp.Views
{
    partial class NewAdminFaceScannerForm
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
            NameTextbox = new TextBox();
            loginByPasswordBytton = new Button();
            CameraCapture = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)CameraCapture).BeginInit();
            SuspendLayout();
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(470, 415);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(227, 23);
            NameTextbox.TabIndex = 6;
            // 
            // loginByPasswordBytton
            // 
            loginByPasswordBytton.Location = new Point(713, 415);
            loginByPasswordBytton.Name = "loginByPasswordBytton";
            loginByPasswordBytton.Size = new Size(75, 23);
            loginByPasswordBytton.TabIndex = 5;
            loginByPasswordBytton.Text = "Добавить";
            loginByPasswordBytton.UseVisualStyleBackColor = true;
            loginByPasswordBytton.Click += loginByPasswordBytton_Click;
            // 
            // CameraCapture
            // 
            CameraCapture.Location = new Point(12, 12);
            CameraCapture.Margin = new Padding(3, 3, 3, 15);
            CameraCapture.Name = "CameraCapture";
            CameraCapture.Size = new Size(776, 385);
            CameraCapture.TabIndex = 4;
            CameraCapture.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(339, 419);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 7;
            label1.Text = "Имя администратора";
            // 
            // NewAdminFaceScannerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(NameTextbox);
            Controls.Add(loginByPasswordBytton);
            Controls.Add(CameraCapture);
            Name = "NewAdminFaceScannerForm";
            Text = "NewAdminFaceScannerForm";
            FormClosed += FaceLoginForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CameraCapture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextbox;
        private Button loginByPasswordBytton;
        private PictureBox CameraCapture;
        private Label label1;
    }
}