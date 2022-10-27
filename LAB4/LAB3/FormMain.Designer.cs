namespace LAB4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.treeViewSyntaxTree = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.logicalSum = new System.Windows.Forms.Button();
            this.logicalMultiply = new System.Windows.Forms.Button();
            this.negative = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Location = new System.Drawing.Point(29, 241);
            this.richTextBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(527, 314);
            this.richTextBoxInput.TabIndex = 1;
            this.richTextBoxInput.Text = "¬(ac=cccccd)∨(011=cd)";
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(185, 576);
            this.buttonAnalyze.Margin = new System.Windows.Forms.Padding(4);
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
            this.label1.Location = new System.Drawing.Point(25, 222);
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
            this.label2.Size = new System.Drawing.Size(237, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Слова первого типа: (111)*011(100)* ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Слова второго типа: (a|b|c|d)+ ";
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
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.Location = new System.Drawing.Point(29, 655);
            this.richTextBoxMessages.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.Size = new System.Drawing.Size(1037, 101);
            this.richTextBoxMessages.TabIndex = 10;
            this.richTextBoxMessages.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 635);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сообщения:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(922, 112);
            this.label7.TabIndex = 12;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // treeViewSyntaxTree
            // 
            this.treeViewSyntaxTree.Location = new System.Drawing.Point(584, 241);
            this.treeViewSyntaxTree.Margin = new System.Windows.Forms.Padding(4);
            this.treeViewSyntaxTree.Name = "treeViewSyntaxTree";
            this.treeViewSyntaxTree.Size = new System.Drawing.Size(483, 314);
            this.treeViewSyntaxTree.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Синтаксическое дерево:";
            // 
            // logicalSum
            // 
            this.logicalSum.Location = new System.Drawing.Point(378, 219);
            this.logicalSum.Name = "logicalSum";
            this.logicalSum.Size = new System.Drawing.Size(75, 23);
            this.logicalSum.TabIndex = 13;
            this.logicalSum.Text = "∨";
            this.logicalSum.UseVisualStyleBackColor = true;
            this.logicalSum.Click += new System.EventHandler(this.logicalSum_Click);
            // 
            // logicalMultiply
            // 
            this.logicalMultiply.Location = new System.Drawing.Point(216, 219);
            this.logicalMultiply.Name = "logicalMultiply";
            this.logicalMultiply.Size = new System.Drawing.Size(75, 23);
            this.logicalMultiply.TabIndex = 14;
            this.logicalMultiply.Text = "∧";
            this.logicalMultiply.UseVisualStyleBackColor = true;
            this.logicalMultiply.Click += new System.EventHandler(this.logicalMultiply_Click);
            // 
            // negative
            // 
            this.negative.Location = new System.Drawing.Point(297, 219);
            this.negative.Name = "negative";
            this.negative.Size = new System.Drawing.Size(75, 23);
            this.negative.TabIndex = 15;
            this.negative.Text = "¬";
            this.negative.UseVisualStyleBackColor = true;
            this.negative.Click += new System.EventHandler(this.negative_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 772);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.treeViewSyntaxTree);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxMessages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.richTextBoxInput);
            this.Controls.Add(this.negative);
            this.Controls.Add(this.logicalMultiply);
            this.Controls.Add(this.logicalSum);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Лабораторная работа № 4";
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
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView treeViewSyntaxTree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button logicalSum;
        private System.Windows.Forms.Button logicalMultiply;
        private System.Windows.Forms.Button negative;
    }
}

