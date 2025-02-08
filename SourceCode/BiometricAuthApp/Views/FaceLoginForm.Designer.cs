namespace BiometricAuthApp.Views
{
    partial class FaceLoginForm
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
            CameraCapture = new PictureBox();
            loginByPasswordBytton = new Button();
            label1 = new Label();
            FoundNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)CameraCapture).BeginInit();
            SuspendLayout();
            // 
            // CameraCapture
            // 
            CameraCapture.Location = new Point(12, 12);
            CameraCapture.Margin = new Padding(3, 3, 3, 15);
            CameraCapture.Name = "CameraCapture";
            CameraCapture.Size = new Size(776, 385);
            CameraCapture.TabIndex = 0;
            CameraCapture.TabStop = false;
            // 
            // loginByPasswordBytton
            // 
            loginByPasswordBytton.Location = new Point(713, 415);
            loginByPasswordBytton.Name = "loginByPasswordBytton";
            loginByPasswordBytton.Size = new Size(75, 23);
            loginByPasswordBytton.TabIndex = 2;
            loginByPasswordBytton.Text = "Отмена";
            loginByPasswordBytton.UseVisualStyleBackColor = true;
            loginByPasswordBytton.Click += loginByPasswordBytton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(493, 419);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 3;
            label1.Text = "Распознан:";
            // 
            // FoundNameLabel
            // 
            FoundNameLabel.AutoSize = true;
            FoundNameLabel.Location = new Point(567, 419);
            FoundNameLabel.Name = "FoundNameLabel";
            FoundNameLabel.Size = new Size(83, 15);
            FoundNameLabel.TabIndex = 4;
            FoundNameLabel.Text = "Не распознан";
            // 
            // FaceLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FoundNameLabel);
            Controls.Add(label1);
            Controls.Add(loginByPasswordBytton);
            Controls.Add(CameraCapture);
            Name = "FaceLoginForm";
            Text = "FaceLoginForm";
            FormClosed += FaceLoginForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CameraCapture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox CameraCapture;
        private Button loginByPasswordBytton;
        private Label label1;
        private Label FoundNameLabel;
    }
}