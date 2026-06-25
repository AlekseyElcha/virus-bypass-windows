namespace VirusBypass
{
    partial class DiskHelper
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            updateInfoButton = new Button();
            listView1 = new ListView();
            deletePartitionButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // updateInfoButton
            // 
            updateInfoButton.BackColor = Color.Bisque;
            updateInfoButton.Location = new Point(445, 521);
            updateInfoButton.Name = "updateInfoButton";
            updateInfoButton.Size = new Size(276, 29);
            updateInfoButton.TabIndex = 0;
            updateInfoButton.Text = "Сканировать разделы";
            updateInfoButton.UseVisualStyleBackColor = false;
            updateInfoButton.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(39, 58);
            listView1.Name = "listView1";
            listView1.Size = new Size(704, 443);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // deletePartitionButton
            // 
            deletePartitionButton.BackColor = Color.Bisque;
            deletePartitionButton.Location = new Point(58, 521);
            deletePartitionButton.Name = "deletePartitionButton";
            deletePartitionButton.Size = new Size(276, 29);
            deletePartitionButton.TabIndex = 2;
            deletePartitionButton.Text = "Удалить выбранный раздел";
            deletePartitionButton.UseVisualStyleBackColor = false;
            deletePartitionButton.Click += deletePartitionButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(171, 15);
            label1.Name = "label1";
            label1.Size = new Size(436, 28);
            label1.TabIndex = 3;
            label1.Text = "Предупреждение: действуйте аккуратно!";
            // 
            // DiskHelper
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(deletePartitionButton);
            Controls.Add(listView1);
            Controls.Add(updateInfoButton);
            Name = "DiskHelper";
            Size = new Size(780, 580);
            Load += DiskHelper_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button updateInfoButton;
        private ListView listView1;
        private Button deletePartitionButton;
        private Label label1;
    }
}
