namespace BiometricAuthApp.Views
{
    partial class NewUserForm
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
            nameBox = new TextBox();
            passwordBox = new TextBox();
            repeatPasswordBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.Location = new Point(141, 61);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(199, 23);
            nameBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(141, 112);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(199, 23);
            passwordBox.TabIndex = 1;
            // 
            // repeatPasswordBox
            // 
            repeatPasswordBox.Location = new Point(141, 160);
            repeatPasswordBox.Name = "repeatPasswordBox";
            repeatPasswordBox.Size = new Size(199, 23);
            repeatPasswordBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 63);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 115);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 163);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 5;
            label3.Text = "Повтор пароля";
            // 
            // button1
            // 
            button1.Location = new Point(64, 213);
            button1.Name = "button1";
            button1.Size = new Size(221, 36);
            button1.TabIndex = 6;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NewUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 276);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(repeatPasswordBox);
            Controls.Add(passwordBox);
            Controls.Add(nameBox);
            Name = "NewUserForm";
            Text = "NewUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameBox;
        private TextBox passwordBox;
        private TextBox repeatPasswordBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}