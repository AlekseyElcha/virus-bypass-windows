namespace VirusBypass
{
    partial class CmdLineManager
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
            components = new System.ComponentModel.Container();
            restoreCmdLineButton = new Button();
            enableCursorButton = new Button();
            listView1 = new ListView();
            name = new ColumnHeader();
            value = new ColumnHeader();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            restoreWinlogonShellButton = new Button();
            restoreWinlogonUserinitButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // restoreCmdLineButton
            // 
            restoreCmdLineButton.BackColor = SystemColors.ControlLight;
            restoreCmdLineButton.Location = new Point(379, 77);
            restoreCmdLineButton.Name = "restoreCmdLineButton";
            restoreCmdLineButton.Size = new Size(188, 53);
            restoreCmdLineButton.TabIndex = 0;
            restoreCmdLineButton.Text = "Восстановить по умолчанию";
            restoreCmdLineButton.UseVisualStyleBackColor = false;
            restoreCmdLineButton.Click += restoreCmdLineButton_Click;
            // 
            // enableCursorButton
            // 
            enableCursorButton.BackColor = SystemColors.ControlLight;
            enableCursorButton.Location = new Point(379, 152);
            enableCursorButton.Name = "enableCursorButton";
            enableCursorButton.Size = new Size(188, 53);
            enableCursorButton.TabIndex = 1;
            enableCursorButton.Text = "Включить курсор в CmdLine";
            enableCursorButton.UseVisualStyleBackColor = false;
            enableCursorButton.Click += enableCursorButton_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { name, value });
            listView1.Location = new Point(28, 60);
            listView1.Name = "listView1";
            listView1.Size = new Size(340, 170);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // name
            // 
            name.Text = "Параметр";
            // 
            // value
            // 
            value.Text = "Значение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 23);
            label2.Name = "label2";
            label2.Size = new Size(200, 20);
            label2.TabIndex = 5;
            label2.Text = "Текущие значения CmdLine";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 33);
            label1.Name = "label1";
            label1.Size = new Size(210, 20);
            label1.TabIndex = 6;
            label1.Text = "Текущие значения WinLogon";
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView2.Location = new Point(28, 67);
            listView2.Name = "listView2";
            listView2.Size = new Size(340, 170);
            listView2.TabIndex = 7;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Параметр";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Значение";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(listView1);
            groupBox1.Controls.Add(enableCursorButton);
            groupBox1.Controls.Add(restoreCmdLineButton);
            groupBox1.Location = new Point(22, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(698, 265);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "CmdLine";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(restoreWinlogonShellButton);
            groupBox2.Controls.Add(restoreWinlogonUserinitButton);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(listView2);
            groupBox2.Location = new Point(22, 285);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(698, 273);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "WinLogon";
            // 
            // restoreWinlogonShellButton
            // 
            restoreWinlogonShellButton.BackColor = SystemColors.ControlLight;
            restoreWinlogonShellButton.Location = new Point(379, 166);
            restoreWinlogonShellButton.Name = "restoreWinlogonShellButton";
            restoreWinlogonShellButton.Size = new Size(188, 53);
            restoreWinlogonShellButton.TabIndex = 9;
            restoreWinlogonShellButton.Text = "Восстановить shell по умолчанию";
            restoreWinlogonShellButton.UseVisualStyleBackColor = false;
            restoreWinlogonShellButton.Click += restoreWinlogonShellButton_Click;
            // 
            // restoreWinlogonUserinitButton
            // 
            restoreWinlogonUserinitButton.BackColor = SystemColors.ControlLight;
            restoreWinlogonUserinitButton.Location = new Point(379, 91);
            restoreWinlogonUserinitButton.Name = "restoreWinlogonUserinitButton";
            restoreWinlogonUserinitButton.Size = new Size(188, 53);
            restoreWinlogonUserinitButton.TabIndex = 8;
            restoreWinlogonUserinitButton.Text = "Восстановить userinit по умолчанию";
            restoreWinlogonUserinitButton.UseVisualStyleBackColor = false;
            restoreWinlogonUserinitButton.Click += restoreWinlogonUserinitButton_Click;
            // 
            // CmdLineManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "CmdLineManager";
            Size = new Size(780, 580);
            Load += CmdLineManager_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button restoreCmdLineButton;
        private Button enableCursorButton;
        private ListView listView1;
        private ColumnHeader name;
        private ColumnHeader value;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button restoreWinlogonShellButton;
        private Button restoreWinlogonUserinitButton;
    }
}
