namespace VirusBypass
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            submitInputFormButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 1;
            label1.Text = "Новое значение:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(430, 20);
            label2.TabIndex = 2;
            label2.Text = "Введите новое значение и нажмите на кнопку \"Применить\"";
            // 
            // submitInputFormButton
            // 
            submitInputFormButton.Location = new Point(12, 118);
            submitInputFormButton.Name = "submitInputFormButton";
            submitInputFormButton.Size = new Size(489, 29);
            submitInputFormButton.TabIndex = 3;
            submitInputFormButton.Text = "Применить";
            submitInputFormButton.UseVisualStyleBackColor = true;
            submitInputFormButton.Click += submitInputFormButton_Click;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 159);
            Controls.Add(submitInputFormButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InputForm";
            Text = "Изменение значения";
            Load += InputForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button submitInputFormButton;
    }
}