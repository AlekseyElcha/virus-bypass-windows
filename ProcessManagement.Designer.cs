namespace VirusBypass
{
    partial class ProcessManagement
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
            dataGridView1 = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            pid = new DataGridViewTextBoxColumn();
            isCritical = new DataGridViewTextBoxColumn();
            path = new DataGridViewTextBoxColumn();
            user = new DataGridViewTextBoxColumn();
            memory = new DataGridViewTextBoxColumn();
            threads = new DataGridViewTextBoxColumn();
            terminateProcessButton = new Button();
            makeNotCriticalButton = new Button();
            loadProcessesButton = new Button();
            infoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { name, pid, isCritical, path, user, memory, threads });
            dataGridView1.Location = new Point(17, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(738, 478);
            dataGridView1.TabIndex = 0;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            // 
            // name
            // 
            name.HeaderText = "Процесс";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 125;
            // 
            // pid
            // 
            pid.HeaderText = "PID";
            pid.MinimumWidth = 6;
            pid.Name = "pid";
            pid.ReadOnly = true;
            pid.Width = 125;
            // 
            // isCritical
            // 
            isCritical.HeaderText = "Критичный?";
            isCritical.MinimumWidth = 6;
            isCritical.Name = "isCritical";
            isCritical.ReadOnly = true;
            isCritical.Width = 125;
            // 
            // path
            // 
            path.HeaderText = "Путь";
            path.MinimumWidth = 6;
            path.Name = "path";
            path.ReadOnly = true;
            path.Width = 125;
            // 
            // user
            // 
            user.HeaderText = "Пользователь";
            user.MinimumWidth = 6;
            user.Name = "user";
            user.ReadOnly = true;
            user.Width = 125;
            // 
            // memory
            // 
            memory.HeaderText = "Память";
            memory.MinimumWidth = 6;
            memory.Name = "memory";
            memory.ReadOnly = true;
            memory.Width = 125;
            // 
            // threads
            // 
            threads.HeaderText = "Потоки";
            threads.MinimumWidth = 6;
            threads.Name = "threads";
            threads.ReadOnly = true;
            threads.Width = 125;
            // 
            // terminateProcessButton
            // 
            terminateProcessButton.Location = new Point(36, 19);
            terminateProcessButton.Name = "terminateProcessButton";
            terminateProcessButton.Size = new Size(178, 29);
            terminateProcessButton.TabIndex = 1;
            terminateProcessButton.Text = "Завершить процесс";
            terminateProcessButton.UseVisualStyleBackColor = true;
            terminateProcessButton.Click += terminateProcessButton_Click;
            // 
            // makeNotCriticalButton
            // 
            makeNotCriticalButton.Location = new Point(291, 19);
            makeNotCriticalButton.Name = "makeNotCriticalButton";
            makeNotCriticalButton.Size = new Size(178, 29);
            makeNotCriticalButton.TabIndex = 2;
            makeNotCriticalButton.Text = "Снять критичность";
            makeNotCriticalButton.UseVisualStyleBackColor = true;
            makeNotCriticalButton.Click += makeNotCriticalButton_Click;
            // 
            // loadProcessesButton
            // 
            loadProcessesButton.Location = new Point(566, 19);
            loadProcessesButton.Name = "loadProcessesButton";
            loadProcessesButton.Size = new Size(178, 29);
            loadProcessesButton.TabIndex = 3;
            loadProcessesButton.Text = "Обновить список";
            loadProcessesButton.UseVisualStyleBackColor = true;
            loadProcessesButton.Click += loadProcessesButton_Click;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            infoLabel.Location = new Point(256, 535);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(254, 31);
            infoLabel.TabIndex = 4;
            infoLabel.Text = "Загружаем процессы...";
            // 
            // ProcessManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(infoLabel);
            Controls.Add(loadProcessesButton);
            Controls.Add(makeNotCriticalButton);
            Controls.Add(terminateProcessButton);
            Controls.Add(dataGridView1);
            Name = "ProcessManagement";
            Size = new Size(780, 580);
            Load += ProcessManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn pid;
        private DataGridViewTextBoxColumn isCritical;
        private DataGridViewTextBoxColumn path;
        private DataGridViewTextBoxColumn user;
        private DataGridViewTextBoxColumn memory;
        private DataGridViewTextBoxColumn threads;
        private Button terminateProcessButton;
        private Button makeNotCriticalButton;
        private Button loadProcessesButton;
        private Label infoLabel;
    }
}
