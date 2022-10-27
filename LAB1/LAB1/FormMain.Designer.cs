namespace LAB1
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewRecognizedTokens = new System.Windows.Forms.DataGridView();
            this.Токен = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecognizedTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Location = new System.Drawing.Point(29, 134);
            this.richTextBoxInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(485, 314);
            this.richTextBoxInput.TabIndex = 1;
            this.richTextBoxInput.Text = "";
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(189, 473);
            this.buttonAnalyze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(183, 42);
            this.buttonAnalyze.TabIndex = 2;
            this.buttonAnalyze.Text = "Анализировать текст";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Входной текст:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Слова первого типа: (111)*011(100)*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Слова второго типа: (a|b|c|d)+ без подстроки ab";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Комментарий: многострочный  (*  ........  *)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Распознанные токены:";
            // 
            // dataGridViewRecognizedTokens
            // 
            this.dataGridViewRecognizedTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecognizedTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Токен,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewRecognizedTokens.Location = new System.Drawing.Point(544, 134);
            this.dataGridViewRecognizedTokens.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewRecognizedTokens.Name = "dataGridViewRecognizedTokens";
            this.dataGridViewRecognizedTokens.ReadOnly = true;
            this.dataGridViewRecognizedTokens.RowHeadersWidth = 51;
            this.dataGridViewRecognizedTokens.Size = new System.Drawing.Size(524, 315);
            this.dataGridViewRecognizedTokens.TabIndex = 9;
            // 
            // Токен
            // 
            this.Токен.HeaderText = "№";
            this.Токен.MinimumWidth = 6;
            this.Токен.Name = "Токен";
            this.Токен.ReadOnly = true;
            this.Токен.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Токен";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Тип токена";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Индекс строки";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Индекс символа";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.Location = new System.Drawing.Point(29, 548);
            this.richTextBoxMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.Size = new System.Drawing.Size(1037, 101);
            this.richTextBoxMessages.TabIndex = 10;
            this.richTextBoxMessages.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 528);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сообщения:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 666);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxMessages);
            this.Controls.Add(this.dataGridViewRecognizedTokens);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.richTextBoxInput);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Лабораторная работа № 1 - Разработка лексического анализатора";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecognizedTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewRecognizedTokens;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Токен;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

