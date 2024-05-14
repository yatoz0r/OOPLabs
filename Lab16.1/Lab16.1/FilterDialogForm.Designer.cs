namespace Lab16._1
{
    partial class FilterDialogForm
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
            typeLabel = new Label();
            ComboBox1 = new ComboBox();
            fieldNameLabel = new Label();
            ComboBox2 = new ComboBox();
            applyButton = new Button();
            SuspendLayout();
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(12, 15);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(34, 15);
            typeLabel.TabIndex = 0;
            typeLabel.Text = "Type:";
            // 
            // typeComboBox
            // 
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Location = new Point(93, 12);
            ComboBox1.Name = "typeComboBox";
            ComboBox1.Size = new Size(121, 23);
            ComboBox1.TabIndex = 1;
            // 
            // fieldNameLabel
            // 
            fieldNameLabel.AutoSize = true;
            fieldNameLabel.Location = new Point(12, 48);
            fieldNameLabel.Name = "fieldNameLabel";
            fieldNameLabel.Size = new Size(70, 15);
            fieldNameLabel.TabIndex = 2;
            fieldNameLabel.Text = "Field Name:";
            // 
            // fieldNameTextBox
            // 
            ComboBox2.Location = new Point(93, 45);
            ComboBox2.Name = "fieldNameTextBox";
            ComboBox2.Size = new Size(121, 23);
            ComboBox2.TabIndex = 3;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(93, 81);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 4;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 119);
            Controls.Add(applyButton);
            Controls.Add(ComboBox2);
            Controls.Add(fieldNameLabel);
            Controls.Add(ComboBox1);
            Controls.Add(typeLabel);
            Name = "Form2";
            Text = "Filter Dialog";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label typeLabel;
        private ComboBox ComboBox1;
        private Label fieldNameLabel;
        private ComboBox ComboBox2;
        private Button applyButton;

        #endregion
    }
}