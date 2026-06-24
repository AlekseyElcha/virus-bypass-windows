namespace VirusBypass
{
    partial class w
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(w));
            groupBox1 = new GroupBox();
            processesButton = new Button();
            autoStartupButton = new Button();
            groupBox2 = new GroupBox();
            restoreUACButton = new Button();
            restoreFontsButton = new Button();
            resetLimitsButton = new Button();
            accessibilityToolRestoreButton = new Button();
            sfcScannowButton = new Button();
            restoreDISMButton = new Button();
            cmdLineButton = new Button();
            accessibilityToolSubstButton = new Button();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            utilsButton = new Button();
            aboutProgramButton = new Button();
            groupBox5 = new GroupBox();
            diskButton = new Button();
            label1 = new Label();
            OSVersionLabel = new Label();
            label2 = new Label();
            programVersionLabel = new Label();
            fileExplorerButton = new Button();
            groupBox6 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(processesButton);
            groupBox1.Controls.Add(autoStartupButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(233, 107);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Процессы и автозагрузка";
            // 
            // processesButton
            // 
            processesButton.Location = new Point(6, 61);
            processesButton.Name = "processesButton";
            processesButton.Size = new Size(219, 29);
            processesButton.TabIndex = 1;
            processesButton.Text = "Управление процессами";
            processesButton.UseVisualStyleBackColor = true;
            processesButton.Click += processesButton_Click;
            // 
            // autoStartupButton
            // 
            autoStartupButton.Location = new Point(6, 26);
            autoStartupButton.Name = "autoStartupButton";
            autoStartupButton.Size = new Size(219, 29);
            autoStartupButton.TabIndex = 0;
            autoStartupButton.Text = "Автозагрузка";
            autoStartupButton.UseVisualStyleBackColor = true;
            autoStartupButton.Click += autoStartupButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(restoreUACButton);
            groupBox2.Controls.Add(restoreFontsButton);
            groupBox2.Controls.Add(resetLimitsButton);
            groupBox2.Controls.Add(accessibilityToolRestoreButton);
            groupBox2.Controls.Add(sfcScannowButton);
            groupBox2.Controls.Add(restoreDISMButton);
            groupBox2.Controls.Add(cmdLineButton);
            groupBox2.Controls.Add(accessibilityToolSubstButton);
            groupBox2.Location = new Point(12, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(233, 314);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Быстрые действия";
            // 
            // restoreUACButton
            // 
            restoreUACButton.Location = new Point(6, 236);
            restoreUACButton.Name = "restoreUACButton";
            restoreUACButton.Size = new Size(221, 29);
            restoreUACButton.TabIndex = 9;
            restoreUACButton.Text = "Вернуть UAC";
            restoreUACButton.UseVisualStyleBackColor = true;
            restoreUACButton.Click += restoreUACButton_Click;
            // 
            // restoreFontsButton
            // 
            restoreFontsButton.BackgroundImage = (Image)resources.GetObject("restoreFontsButton.BackgroundImage");
            restoreFontsButton.Location = new Point(6, 271);
            restoreFontsButton.Name = "restoreFontsButton";
            restoreFontsButton.Size = new Size(221, 29);
            restoreFontsButton.TabIndex = 4;
            restoreFontsButton.UseVisualStyleBackColor = true;
            restoreFontsButton.Click += restoreFontsButton_Click;
            // 
            // resetLimitsButton
            // 
            resetLimitsButton.Location = new Point(8, 201);
            resetLimitsButton.Name = "resetLimitsButton";
            resetLimitsButton.Size = new Size(219, 29);
            resetLimitsButton.TabIndex = 8;
            resetLimitsButton.Text = "Сбросить ограничения";
            resetLimitsButton.UseVisualStyleBackColor = true;
            resetLimitsButton.Click += resetLimitsButton_Click;
            // 
            // accessibilityToolRestoreButton
            // 
            accessibilityToolRestoreButton.Location = new Point(6, 96);
            accessibilityToolRestoreButton.Name = "accessibilityToolRestoreButton";
            accessibilityToolRestoreButton.Size = new Size(221, 29);
            accessibilityToolRestoreButton.TabIndex = 5;
            accessibilityToolRestoreButton.Text = "Вернуть sethc и utilman";
            accessibilityToolRestoreButton.UseVisualStyleBackColor = true;
            accessibilityToolRestoreButton.Click += accessibilityToolRestoreButton_Click;
            // 
            // sfcScannowButton
            // 
            sfcScannowButton.Location = new Point(6, 131);
            sfcScannowButton.Name = "sfcScannowButton";
            sfcScannowButton.Size = new Size(221, 29);
            sfcScannowButton.TabIndex = 3;
            sfcScannowButton.Text = "sfc /scannow";
            sfcScannowButton.UseVisualStyleBackColor = true;
            sfcScannowButton.Click += sfcScannowButton_Click;
            // 
            // restoreDISMButton
            // 
            restoreDISMButton.Location = new Point(6, 166);
            restoreDISMButton.Name = "restoreDISMButton";
            restoreDISMButton.Size = new Size(221, 29);
            restoreDISMButton.TabIndex = 7;
            restoreDISMButton.Text = "Восстановить образ ОС";
            restoreDISMButton.UseVisualStyleBackColor = true;
            restoreDISMButton.Click += restoreDISMButton_Click;
            // 
            // cmdLineButton
            // 
            cmdLineButton.Location = new Point(6, 26);
            cmdLineButton.Name = "cmdLineButton";
            cmdLineButton.Size = new Size(221, 29);
            cmdLineButton.TabIndex = 1;
            cmdLineButton.Text = "CmdLine и Winlogon";
            cmdLineButton.UseVisualStyleBackColor = true;
            cmdLineButton.Click += cmdLineButton_Click;
            // 
            // accessibilityToolSubstButton
            // 
            accessibilityToolSubstButton.Location = new Point(8, 61);
            accessibilityToolSubstButton.Name = "accessibilityToolSubstButton";
            accessibilityToolSubstButton.Size = new Size(219, 29);
            accessibilityToolSubstButton.TabIndex = 0;
            accessibilityToolSubstButton.Text = "Подменить sethc и utilman";
            accessibilityToolSubstButton.UseVisualStyleBackColor = true;
            accessibilityToolSubstButton.Click += accessibilityToolSubstButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(265, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(810, 605);
            panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(278, 161);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 125);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(utilsButton);
            groupBox3.Location = new Point(12, 514);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(233, 74);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Восстановление+ (быстро)";
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(0, 80);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(233, 107);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Работа с дисками";
            // 
            // utilsButton
            // 
            utilsButton.Location = new Point(6, 26);
            utilsButton.Name = "utilsButton";
            utilsButton.Size = new Size(219, 29);
            utilsButton.TabIndex = 0;
            utilsButton.Text = "Открыть меню";
            utilsButton.UseVisualStyleBackColor = true;
            utilsButton.Click += utilsButton_Click;
            // 
            // aboutProgramButton
            // 
            aboutProgramButton.BackColor = SystemColors.Info;
            aboutProgramButton.Location = new Point(18, 672);
            aboutProgramButton.Name = "aboutProgramButton";
            aboutProgramButton.Size = new Size(219, 29);
            aboutProgramButton.TabIndex = 4;
            aboutProgramButton.Text = "О программе";
            aboutProgramButton.UseVisualStyleBackColor = false;
            aboutProgramButton.Click += aboutProgramButton_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(diskButton);
            groupBox5.Location = new Point(12, 585);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(233, 77);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "Работа с дисками";
            // 
            // diskButton
            // 
            diskButton.Location = new Point(6, 26);
            diskButton.Name = "diskButton";
            diskButton.Size = new Size(219, 29);
            diskButton.TabIndex = 0;
            diskButton.Text = "Открыть меню";
            diskButton.UseVisualStyleBackColor = true;
            diskButton.Click += diskButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 663);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 6;
            label1.Text = "ОС:";
            // 
            // OSVersionLabel
            // 
            OSVersionLabel.AutoSize = true;
            OSVersionLabel.Location = new Point(719, 663);
            OSVersionLabel.Name = "OSVersionLabel";
            OSVersionLabel.Size = new Size(114, 20);
            OSVersionLabel.TabIndex = 7;
            OSVersionLabel.Text = "какая-то винда";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 663);
            label2.Name = "label2";
            label2.Size = new Size(146, 20);
            label2.TabIndex = 8;
            label2.Text = "Версия программы";
            // 
            // programVersionLabel
            // 
            programVersionLabel.AutoSize = true;
            programVersionLabel.Location = new Point(438, 663);
            programVersionLabel.Name = "programVersionLabel";
            programVersionLabel.Size = new Size(50, 20);
            programVersionLabel.TabIndex = 9;
            programVersionLabel.Text = "label3";
            // 
            // fileExplorerButton
            // 
            fileExplorerButton.Location = new Point(8, 28);
            fileExplorerButton.Name = "fileExplorerButton";
            fileExplorerButton.Size = new Size(217, 29);
            fileExplorerButton.TabIndex = 10;
            fileExplorerButton.Text = "Файловая система";
            fileExplorerButton.UseVisualStyleBackColor = true;
            fileExplorerButton.Click += fileExplorerButton_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(fileExplorerButton);
            groupBox6.Location = new Point(12, 125);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(233, 63);
            groupBox6.TabIndex = 11;
            groupBox6.TabStop = false;
            groupBox6.Text = "Встроенный проводник";
            // 
            // w
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1088, 732);
            Controls.Add(groupBox6);
            Controls.Add(programVersionLabel);
            Controls.Add(label2);
            Controls.Add(OSVersionLabel);
            Controls.Add(label1);
            Controls.Add(groupBox5);
            Controls.Add(aboutProgramButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "w";
            Text = "VirusBypass - by Pelican4ik";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button processesButton;
        private Button autoStartupButton;
        private GroupBox groupBox2;
        private Button cmdLineButton;
        private Button accessibilityToolSubstButton;
        private Button restoreFontsButton;
        private Button sfcScannowButton;
        private Panel panel1;
        private Button accessibilityToolRestoreButton;
        private GroupBox groupBox3;
        private Button restoreDISMButton;
        private Button utilsButton;
        private Button resetLimitsButton;
        private Button aboutProgramButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button diskButton;
        private Label label1;
        private Label OSVersionLabel;
        private Label label2;
        private Label programVersionLabel;
        private Button restoreUACButton;
        private Button fileExplorerButton;
        private GroupBox groupBox6;
    }
}
