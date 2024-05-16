namespace Lab16._1
{
    partial class MainWindowForm
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
            randomFillButton = new Button();
            addElementButton = new Button();
            deleteElementButton = new Button();
            changeElementButton = new Button();
            findElementButton = new Button();
            filterCollectionButton = new Button();
            sortCollectionButton = new Button();
            saveCollectionButton = new Button();
            loadCollectionButton = new Button();
            syncAsyncTestButton = new Button();
            menuStrip1 = new MenuStrip();
            KeyTextBox1 = new TextBox();
            KeyTextBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ValueTextBox2 = new TextBox();
            ValueTextBox1 = new TextBox();
            label7 = new Label();
            ValueTextBox3 = new TextBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // randomFillButton
            // 
            randomFillButton.Location = new Point(38, 30);
            randomFillButton.Margin = new Padding(4, 3, 4, 3);
            randomFillButton.Name = "randomFillButton";
            randomFillButton.Size = new Size(163, 27);
            randomFillButton.TabIndex = 0;
            randomFillButton.Text = "Рандомное заполнение";
            randomFillButton.UseVisualStyleBackColor = true;
            randomFillButton.Click += randomFillButton_Click;
            // 
            // addElementButton
            // 
            addElementButton.Location = new Point(37, 63);
            addElementButton.Margin = new Padding(4, 3, 4, 3);
            addElementButton.Name = "addElementButton";
            addElementButton.Size = new Size(164, 27);
            addElementButton.TabIndex = 1;
            addElementButton.Text = "Добавить элемент";
            addElementButton.UseVisualStyleBackColor = true;
            addElementButton.Click += addElementButton_Click;
            // 
            // deleteElementButton
            // 
            deleteElementButton.Location = new Point(38, 97);
            deleteElementButton.Margin = new Padding(4, 3, 4, 3);
            deleteElementButton.Name = "deleteElementButton";
            deleteElementButton.Size = new Size(163, 27);
            deleteElementButton.TabIndex = 2;
            deleteElementButton.Text = "Удалить элемент";
            deleteElementButton.UseVisualStyleBackColor = true;
            deleteElementButton.Click += deleteElementButton_Click;
            // 
            // changeElementButton
            // 
            changeElementButton.Location = new Point(38, 130);
            changeElementButton.Margin = new Padding(4, 3, 4, 3);
            changeElementButton.Name = "changeElementButton";
            changeElementButton.Size = new Size(163, 27);
            changeElementButton.TabIndex = 3;
            changeElementButton.Text = "Изменить элемент";
            changeElementButton.UseVisualStyleBackColor = true;
            changeElementButton.Click += changeElementButton_Click;
            // 
            // findElementButton
            // 
            findElementButton.Location = new Point(38, 164);
            findElementButton.Margin = new Padding(4, 3, 4, 3);
            findElementButton.Name = "findElementButton";
            findElementButton.Size = new Size(163, 27);
            findElementButton.TabIndex = 4;
            findElementButton.Text = "Поиск элемента";
            findElementButton.UseVisualStyleBackColor = true;
            findElementButton.Click += findElementButton_Click;
            // 
            // filterCollectionButton
            // 
            filterCollectionButton.Location = new Point(38, 197);
            filterCollectionButton.Margin = new Padding(4, 3, 4, 3);
            filterCollectionButton.Name = "filterCollectionButton";
            filterCollectionButton.Size = new Size(163, 27);
            filterCollectionButton.TabIndex = 5;
            filterCollectionButton.Text = "Фильтрация Коллекции";
            filterCollectionButton.UseVisualStyleBackColor = true;
            filterCollectionButton.Click += filterCollectionButton_Click;
            // 
            // sortCollectionButton
            // 
            sortCollectionButton.Location = new Point(37, 230);
            sortCollectionButton.Margin = new Padding(4, 3, 4, 3);
            sortCollectionButton.Name = "sortCollectionButton";
            sortCollectionButton.Size = new Size(163, 27);
            sortCollectionButton.TabIndex = 7;
            sortCollectionButton.Text = "Сортировка";
            sortCollectionButton.UseVisualStyleBackColor = true;
            sortCollectionButton.Click += sortCollectionButton_Click;
            // 
            // saveCollectionButton
            // 
            saveCollectionButton.Location = new Point(38, 264);
            saveCollectionButton.Margin = new Padding(4, 3, 4, 3);
            saveCollectionButton.Name = "saveCollectionButton";
            saveCollectionButton.Size = new Size(163, 27);
            saveCollectionButton.TabIndex = 8;
            saveCollectionButton.Text = "Сохранение Коллекции";
            saveCollectionButton.UseVisualStyleBackColor = true;
            saveCollectionButton.Click += saveCollectionButton_Click;
            // 
            // loadCollectionButton
            // 
            loadCollectionButton.Location = new Point(38, 297);
            loadCollectionButton.Margin = new Padding(4, 3, 4, 3);
            loadCollectionButton.Name = "loadCollectionButton";
            loadCollectionButton.Size = new Size(163, 27);
            loadCollectionButton.TabIndex = 9;
            loadCollectionButton.Text = "Загрузка Коллекции";
            loadCollectionButton.UseVisualStyleBackColor = true;
            loadCollectionButton.Click += loadCollectionButton_Click;
            // 
            // syncAsyncTestButton
            // 
            syncAsyncTestButton.Location = new Point(38, 331);
            syncAsyncTestButton.Margin = new Padding(4, 3, 4, 3);
            syncAsyncTestButton.Name = "syncAsyncTestButton";
            syncAsyncTestButton.Size = new Size(163, 27);
            syncAsyncTestButton.TabIndex = 10;
            syncAsyncTestButton.Text = "Синх-Асинх";
            syncAsyncTestButton.UseVisualStyleBackColor = true;
            syncAsyncTestButton.Click += syncAsyncTestButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1094, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // KeyTextBox1
            // 
            KeyTextBox1.Location = new Point(264, 63);
            KeyTextBox1.Margin = new Padding(4, 3, 4, 3);
            KeyTextBox1.Name = "KeyTextBox1";
            KeyTextBox1.Size = new Size(96, 23);
            KeyTextBox1.TabIndex = 12;
            // 
            // KeyTextBox2
            // 
            KeyTextBox2.Location = new Point(368, 63);
            KeyTextBox2.Margin = new Padding(4, 3, 4, 3);
            KeyTextBox2.Name = "KeyTextBox2";
            KeyTextBox2.Size = new Size(93, 23);
            KeyTextBox2.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 36);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 14;
            label1.Text = "Ключ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 90);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 15;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(380, 90);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 16;
            label3.Text = "Возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(681, 90);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 21;
            label4.Text = "Возраст";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(590, 90);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 20;
            label5.Text = "Имя";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(546, 36);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 19;
            label6.Text = "Значение";
            // 
            // ValueTextBox2
            // 
            ValueTextBox2.Location = new Point(665, 63);
            ValueTextBox2.Margin = new Padding(4, 3, 4, 3);
            ValueTextBox2.Name = "ValueTextBox2";
            ValueTextBox2.Size = new Size(93, 23);
            ValueTextBox2.TabIndex = 18;
            // 
            // ValueTextBox1
            // 
            ValueTextBox1.Location = new Point(561, 63);
            ValueTextBox1.Margin = new Padding(4, 3, 4, 3);
            ValueTextBox1.Name = "ValueTextBox1";
            ValueTextBox1.Size = new Size(96, 23);
            ValueTextBox1.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(794, 90);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 23;
            label7.Text = "Вес";
            // 
            // ValueTextBox3
            // 
            ValueTextBox3.Location = new Point(765, 63);
            ValueTextBox3.Margin = new Padding(4, 3, 4, 3);
            ValueTextBox3.Name = "ValueTextBox3";
            ValueTextBox3.Size = new Size(93, 23);
            ValueTextBox3.TabIndex = 22;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(264, 120);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(809, 499);
            listBox1.TabIndex = 24;
            // 
            // MainWingowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 635);
            Controls.Add(listBox1);
            Controls.Add(label7);
            Controls.Add(ValueTextBox3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(ValueTextBox2);
            Controls.Add(ValueTextBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(KeyTextBox2);
            Controls.Add(KeyTextBox1);
            Controls.Add(syncAsyncTestButton);
            Controls.Add(loadCollectionButton);
            Controls.Add(saveCollectionButton);
            Controls.Add(sortCollectionButton);
            Controls.Add(filterCollectionButton);
            Controls.Add(findElementButton);
            Controls.Add(changeElementButton);
            Controls.Add(deleteElementButton);
            Controls.Add(addElementButton);
            Controls.Add(randomFillButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainWingowForm";
            Text = "Работа с Коллекцией";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button randomFillButton;
        private System.Windows.Forms.Button addElementButton;
        private System.Windows.Forms.Button deleteElementButton;
        private System.Windows.Forms.Button changeElementButton;
        private System.Windows.Forms.Button findElementButton;
        private System.Windows.Forms.Button filterCollectionButton;
        private System.Windows.Forms.Button sortCollectionButton;
        private System.Windows.Forms.Button saveCollectionButton;
        private System.Windows.Forms.Button loadCollectionButton;
        private System.Windows.Forms.Button syncAsyncTestButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox KeyTextBox1;
        private System.Windows.Forms.TextBox KeyTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ValueTextBox2;
        private System.Windows.Forms.TextBox ValueTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ValueTextBox3;
        private System.Windows.Forms.ListBox listBox1;
    }
       
}

