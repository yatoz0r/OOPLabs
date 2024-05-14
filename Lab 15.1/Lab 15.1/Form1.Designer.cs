namespace Lab_15._1
{
    partial class Form1
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
            this.startButton = new System.Windows.Forms.Button();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.slot1Label = new System.Windows.Forms.Label();
            this.slot2Label = new System.Windows.Forms.Label();
            this.slot3Label = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelThreadPriority1 = new System.Windows.Forms.Label();
            this.labelThreadPriority2 = new System.Windows.Forms.Label();
            this.labelThreadPriority3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(291, 181);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(193, 181);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(75, 23);
            this.analyzeButton.TabIndex = 1;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // slot1Label
            // 
            this.slot1Label.AutoSize = true;
            this.slot1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot1Label.Location = new System.Drawing.Point(180, 108);
            this.slot1Label.Name = "slot1Label";
            this.slot1Label.Size = new System.Drawing.Size(35, 37);
            this.slot1Label.TabIndex = 0;
            this.slot1Label.Text = "0";
            // 
            // slot2Label
            // 
            this.slot2Label.AutoSize = true;
            this.slot2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot2Label.Location = new System.Drawing.Point(240, 108);
            this.slot2Label.Name = "slot2Label";
            this.slot2Label.Size = new System.Drawing.Size(35, 37);
            this.slot2Label.TabIndex = 1;
            this.slot2Label.Text = "0";
            // 
            // slot3Label
            // 
            this.slot3Label.AutoSize = true;
            this.slot3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot3Label.Location = new System.Drawing.Point(300, 108);
            this.slot3Label.Name = "slot3Label";
            this.slot3Label.Size = new System.Drawing.Size(35, 37);
            this.slot3Label.TabIndex = 2;
            this.slot3Label.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 181);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 122);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(12, 60);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 7;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(187, 30);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 13);
            this.labelResult.TabIndex = 8;
            // 
            // labelThreadPriority1
            // 
            this.labelThreadPriority1.AutoSize = true;
            this.labelThreadPriority1.Location = new System.Drawing.Point(12, 41);
            this.labelThreadPriority1.Name = "labelThreadPriority1";
            this.labelThreadPriority1.Size = new System.Drawing.Size(110, 13);
            this.labelThreadPriority1.TabIndex = 9;
            this.labelThreadPriority1.Text = "Приоритет Потока 1";
            // 
            // labelThreadPriority2
            // 
            this.labelThreadPriority2.AutoSize = true;
            this.labelThreadPriority2.Location = new System.Drawing.Point(12, 106);
            this.labelThreadPriority2.Name = "labelThreadPriority2";
            this.labelThreadPriority2.Size = new System.Drawing.Size(110, 13);
            this.labelThreadPriority2.TabIndex = 10;
            this.labelThreadPriority2.Text = "Приоритет Потока 2";
            // 
            // labelThreadPriority3
            // 
            this.labelThreadPriority3.AutoSize = true;
            this.labelThreadPriority3.Location = new System.Drawing.Point(12, 165);
            this.labelThreadPriority3.Name = "labelThreadPriority3";
            this.labelThreadPriority3.Size = new System.Drawing.Size(110, 13);
            this.labelThreadPriority3.TabIndex = 11;
            this.labelThreadPriority3.Text = "Приоритет Потока 3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 216);
            this.Controls.Add(this.labelThreadPriority3);
            this.Controls.Add(this.labelThreadPriority2);
            this.Controls.Add(this.labelThreadPriority1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.slot3Label);
            this.Controls.Add(this.slot2Label);
            this.Controls.Add(this.slot1Label);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Однорукий бандит";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label slot1Label;
        private System.Windows.Forms.Label slot2Label;
        private System.Windows.Forms.Label slot3Label;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelThreadPriority1;
        private System.Windows.Forms.Label labelThreadPriority2;
        private System.Windows.Forms.Label labelThreadPriority3;
    }

    #endregion
}

