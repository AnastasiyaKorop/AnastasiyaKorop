namespace BiometricAuthApp.Views
{
    partial class UpdatePasswordForm
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
            oldPasswordBox = new TextBox();
            newPasswordBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            repeatPasswordBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.Location = new Point(156, 38);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(246, 23);
            nameBox.TabIndex = 0;
            // 
            // oldPasswordBox
            // 
            oldPasswordBox.Location = new Point(156, 87);
            oldPasswordBox.Name = "oldPasswordBox";
            oldPasswordBox.Size = new Size(246, 23);
            oldPasswordBox.TabIndex = 1;
            // 
            // newPasswordBox
            // 
            newPasswordBox.Location = new Point(156, 136);
            newPasswordBox.Name = "newPasswordBox";
            newPasswordBox.Size = new Size(246, 23);
            newPasswordBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 38);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 90);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 4;
            label2.Text = "Старый пароль";
            // 
            // repeatPasswordBox
            // 
            repeatPasswordBox.Location = new Point(156, 186);
            repeatPasswordBox.Name = "repeatPasswordBox";
            repeatPasswordBox.Size = new Size(246, 23);
            repeatPasswordBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 139);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 6;
            label3.Text = "Новый пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 189);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 7;
            label4.Text = "Повтор пароля";
            // 
            // button1
            // 
            button1.Location = new Point(91, 246);
            button1.Name = "button1";
            button1.Size = new Size(262, 46);
            button1.TabIndex = 8;
            button1.Text = "Обновить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UpdatePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 304);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(repeatPasswordBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newPasswordBox);
            Controls.Add(oldPasswordBox);
            Controls.Add(nameBox);
            Name = "UpdatePasswordForm";
            Text = "UpdatePasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameBox;
        private TextBox oldPasswordBox;
        private TextBox newPasswordBox;
        private Label label1;
        private Label label2;
        private TextBox repeatPasswordBox;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}