namespace BiometricAuthApp.Views
{
    partial class UserEmployeeForm
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
            treeView1 = new TreeView();
            addButton = new Button();
            clientCombo = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            employeeCombo = new ComboBox();
            ChengeSortButton = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(776, 346);
            treeView1.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(21, 376);
            addButton.Name = "addButton";
            addButton.Size = new Size(107, 27);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // clientCombo
            // 
            clientCombo.FormattingEnabled = true;
            clientCombo.Location = new Point(235, 379);
            clientCombo.Name = "clientCombo";
            clientCombo.Size = new Size(136, 23);
            clientCombo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 382);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 3;
            label1.Text = "Клиента";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(400, 382);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 5;
            label2.Text = "Работнику";
            // 
            // employeeCombo
            // 
            employeeCombo.FormattingEnabled = true;
            employeeCombo.Location = new Point(473, 379);
            employeeCombo.Name = "employeeCombo";
            employeeCombo.Size = new Size(136, 23);
            employeeCombo.TabIndex = 4;
            // 
            // ChengeSortButton
            // 
            ChengeSortButton.Location = new Point(657, 375);
            ChengeSortButton.Name = "ChengeSortButton";
            ChengeSortButton.Size = new Size(107, 27);
            ChengeSortButton.TabIndex = 6;
            ChengeSortButton.Text = "По клиентам";
            ChengeSortButton.UseVisualStyleBackColor = true;
            ChengeSortButton.Click += ChengeSortButton_Click;
            // 
            // UserEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChengeSortButton);
            Controls.Add(label2);
            Controls.Add(employeeCombo);
            Controls.Add(label1);
            Controls.Add(clientCombo);
            Controls.Add(addButton);
            Controls.Add(treeView1);
            Name = "UserEmployeeForm";
            Text = "UserEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button addButton;
        private ComboBox clientCombo;
        private Label label1;
        private Label label2;
        private ComboBox employeeCombo;
        private Button ChengeSortButton;
    }
}