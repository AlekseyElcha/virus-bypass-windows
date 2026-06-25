namespace VirusBypass
{
    partial class SysHelper
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
            clearDisksButton = new Button();
            DNSCacheButton = new Button();
            defragDisksButton = new Button();
            deviceManagerButton = new Button();
            checkDisksButton = new Button();
            serviceManagementButton = new Button();
            groupPoliciesButton = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            resetHostsButton = new Button();
            unblockTaskmgrButton = new Button();
            unblockRegeditButton = new Button();
            resetAssociationsButton = new Button();
            groupBox4 = new GroupBox();
            normalBootButton = new Button();
            safeModeBootButton = new Button();
            restartExplorerButton = new Button();
            resetUpdateCenterButton = new Button();
            pcManagerButton = new Button();
            activateWindowsButton = new Button();
            groupBox3 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // clearDisksButton
            // 
            clearDisksButton.BackColor = Color.MistyRose;
            clearDisksButton.Location = new Point(6, 96);
            clearDisksButton.Name = "clearDisksButton";
            clearDisksButton.Size = new Size(338, 29);
            clearDisksButton.TabIndex = 1;
            clearDisksButton.Text = "Очистка дисков";
            clearDisksButton.UseVisualStyleBackColor = false;
            clearDisksButton.Click += clearDisksButton_Click;
            // 
            // DNSCacheButton
            // 
            DNSCacheButton.BackColor = Color.LemonChiffon;
            DNSCacheButton.Location = new Point(7, 61);
            DNSCacheButton.Name = "DNSCacheButton";
            DNSCacheButton.Size = new Size(331, 29);
            DNSCacheButton.TabIndex = 2;
            DNSCacheButton.Text = "Очистить кэш DNS";
            DNSCacheButton.UseVisualStyleBackColor = false;
            DNSCacheButton.Click += DNSCacheButton_Click;
            // 
            // defragDisksButton
            // 
            defragDisksButton.BackColor = Color.MistyRose;
            defragDisksButton.Location = new Point(6, 61);
            defragDisksButton.Name = "defragDisksButton";
            defragDisksButton.Size = new Size(338, 29);
            defragDisksButton.TabIndex = 3;
            defragDisksButton.Text = "Дефрагментация дисков";
            defragDisksButton.UseVisualStyleBackColor = false;
            defragDisksButton.Click += defragDisksButton_Click;
            // 
            // deviceManagerButton
            // 
            deviceManagerButton.BackColor = Color.LavenderBlush;
            deviceManagerButton.Location = new Point(7, 61);
            deviceManagerButton.Name = "deviceManagerButton";
            deviceManagerButton.Size = new Size(331, 29);
            deviceManagerButton.TabIndex = 4;
            deviceManagerButton.Text = "Диспетчер устройств";
            deviceManagerButton.UseVisualStyleBackColor = false;
            deviceManagerButton.Click += deviceManagerButton_Click;
            // 
            // checkDisksButton
            // 
            checkDisksButton.BackColor = Color.MistyRose;
            checkDisksButton.Location = new Point(6, 26);
            checkDisksButton.Name = "checkDisksButton";
            checkDisksButton.Size = new Size(338, 29);
            checkDisksButton.TabIndex = 5;
            checkDisksButton.Text = "Проверить диски на ошибки";
            checkDisksButton.UseVisualStyleBackColor = false;
            checkDisksButton.Click += checkDisksButton_Click;
            // 
            // serviceManagementButton
            // 
            serviceManagementButton.BackColor = Color.LemonChiffon;
            serviceManagementButton.Location = new Point(6, 26);
            serviceManagementButton.Name = "serviceManagementButton";
            serviceManagementButton.Size = new Size(332, 29);
            serviceManagementButton.TabIndex = 6;
            serviceManagementButton.Text = "Управление службами";
            serviceManagementButton.UseVisualStyleBackColor = false;
            serviceManagementButton.Click += serviceManagementButton_Click;
            // 
            // groupPoliciesButton
            // 
            groupPoliciesButton.BackColor = Color.LavenderBlush;
            groupPoliciesButton.Location = new Point(7, 26);
            groupPoliciesButton.Name = "groupPoliciesButton";
            groupPoliciesButton.Size = new Size(331, 29);
            groupPoliciesButton.TabIndex = 7;
            groupPoliciesButton.Text = "Групповые политики";
            groupPoliciesButton.UseVisualStyleBackColor = false;
            groupPoliciesButton.Click += groupPoliciesButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkDisksButton);
            groupBox1.Controls.Add(defragDisksButton);
            groupBox1.Controls.Add(clearDisksButton);
            groupBox1.Location = new Point(27, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 143);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Диски / оптимизация";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(serviceManagementButton);
            groupBox2.Controls.Add(DNSCacheButton);
            groupBox2.Controls.Add(resetHostsButton);
            groupBox2.Location = new Point(406, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(344, 143);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Службы, устройства и сеть";
            // 
            // resetHostsButton
            // 
            resetHostsButton.BackColor = Color.LemonChiffon;
            resetHostsButton.Location = new Point(7, 96);
            resetHostsButton.Name = "resetHostsButton";
            resetHostsButton.Size = new Size(331, 29);
            resetHostsButton.TabIndex = 13;
            resetHostsButton.Text = "Сброс файла Hosts";
            resetHostsButton.UseVisualStyleBackColor = false;
            resetHostsButton.Click += resetHostsButton_Click;
            // 
            // unblockTaskmgrButton
            // 
            unblockTaskmgrButton.BackColor = Color.OldLace;
            unblockTaskmgrButton.Location = new Point(6, 61);
            unblockTaskmgrButton.Name = "unblockTaskmgrButton";
            unblockTaskmgrButton.Size = new Size(332, 29);
            unblockTaskmgrButton.TabIndex = 11;
            unblockTaskmgrButton.Text = "Разблокировать Диспетчер задач";
            unblockTaskmgrButton.UseVisualStyleBackColor = false;
            unblockTaskmgrButton.Click += unblockTaskmgrButton_Click;
            // 
            // unblockRegeditButton
            // 
            unblockRegeditButton.BackColor = Color.OldLace;
            unblockRegeditButton.Location = new Point(6, 26);
            unblockRegeditButton.Name = "unblockRegeditButton";
            unblockRegeditButton.Size = new Size(332, 29);
            unblockRegeditButton.TabIndex = 12;
            unblockRegeditButton.Text = "Разблокировать Редактор реестра";
            unblockRegeditButton.UseVisualStyleBackColor = false;
            unblockRegeditButton.Click += unblockRegeditButton_Click;
            // 
            // resetAssociationsButton
            // 
            resetAssociationsButton.BackColor = Color.OldLace;
            resetAssociationsButton.Location = new Point(6, 96);
            resetAssociationsButton.Name = "resetAssociationsButton";
            resetAssociationsButton.Size = new Size(332, 29);
            resetAssociationsButton.TabIndex = 14;
            resetAssociationsButton.Text = "Сброс ассоциаций .exe / .lnk";
            resetAssociationsButton.UseVisualStyleBackColor = false;
            resetAssociationsButton.Click += resetAssociationsButton_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(resetAssociationsButton);
            groupBox4.Controls.Add(unblockRegeditButton);
            groupBox4.Controls.Add(unblockTaskmgrButton);
            groupBox4.Location = new Point(27, 348);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(350, 146);
            groupBox4.TabIndex = 15;
            groupBox4.TabStop = false;
            groupBox4.Text = "Снятие блокировок";
            // 
            // normalBootButton
            // 
            normalBootButton.BackColor = Color.PeachPuff;
            normalBootButton.Location = new Point(6, 61);
            normalBootButton.Name = "normalBootButton";
            normalBootButton.Size = new Size(338, 29);
            normalBootButton.TabIndex = 18;
            normalBootButton.Text = "Перезагрузить ПК";
            normalBootButton.UseVisualStyleBackColor = false;
            normalBootButton.Click += normalBootButton_Click;
            // 
            // safeModeBootButton
            // 
            safeModeBootButton.BackColor = Color.PeachPuff;
            safeModeBootButton.Location = new Point(6, 26);
            safeModeBootButton.Name = "safeModeBootButton";
            safeModeBootButton.Size = new Size(338, 29);
            safeModeBootButton.TabIndex = 17;
            safeModeBootButton.Text = "Запуск в безопасном режиме";
            safeModeBootButton.UseVisualStyleBackColor = false;
            safeModeBootButton.Click += safeModeBootButton_Click;
            // 
            // restartExplorerButton
            // 
            restartExplorerButton.BackColor = Color.PeachPuff;
            restartExplorerButton.Location = new Point(6, 96);
            restartExplorerButton.Name = "restartExplorerButton";
            restartExplorerButton.Size = new Size(338, 29);
            restartExplorerButton.TabIndex = 16;
            restartExplorerButton.Text = "Перезапустить проводника";
            restartExplorerButton.UseVisualStyleBackColor = false;
            restartExplorerButton.Click += restartExplorerButton_Click;
            // 
            // resetUpdateCenterButton
            // 
            resetUpdateCenterButton.BackColor = Color.LavenderBlush;
            resetUpdateCenterButton.Location = new Point(6, 131);
            resetUpdateCenterButton.Name = "resetUpdateCenterButton";
            resetUpdateCenterButton.Size = new Size(331, 29);
            resetUpdateCenterButton.TabIndex = 16;
            resetUpdateCenterButton.Text = "Сброс Центра обновлений";
            resetUpdateCenterButton.UseVisualStyleBackColor = false;
            resetUpdateCenterButton.Click += resetUpdateCenterButton_Click;
            // 
            // pcManagerButton
            // 
            pcManagerButton.BackColor = Color.LavenderBlush;
            pcManagerButton.Location = new Point(6, 96);
            pcManagerButton.Name = "pcManagerButton";
            pcManagerButton.Size = new Size(331, 29);
            pcManagerButton.TabIndex = 15;
            pcManagerButton.Text = "Управление компьютером";
            pcManagerButton.UseVisualStyleBackColor = false;
            pcManagerButton.Click += pcManagerButton_Click;
            // 
            // activateWindowsButton
            // 
            activateWindowsButton.BackColor = Color.PeachPuff;
            activateWindowsButton.Location = new Point(6, 135);
            activateWindowsButton.Name = "activateWindowsButton";
            activateWindowsButton.Size = new Size(338, 29);
            activateWindowsButton.TabIndex = 0;
            activateWindowsButton.Text = "Активация Windows";
            activateWindowsButton.UseVisualStyleBackColor = false;
            activateWindowsButton.Click += activateWindowsButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(restartExplorerButton);
            groupBox3.Controls.Add(normalBootButton);
            groupBox3.Controls.Add(activateWindowsButton);
            groupBox3.Controls.Add(safeModeBootButton);
            groupBox3.Location = new Point(27, 159);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(350, 183);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Перезапуск + активация";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(resetUpdateCenterButton);
            groupBox5.Controls.Add(deviceManagerButton);
            groupBox5.Controls.Add(groupPoliciesButton);
            groupBox5.Controls.Add(pcManagerButton);
            groupBox5.Location = new Point(406, 159);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(344, 183);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Администрирование";
            // 
            // SysHelper
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SysHelper";
            Size = new Size(780, 580);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button clearDisksButton;
        private Button DNSCacheButton;
        private Button defragDisksButton;
        private Button deviceManagerButton;
        private Button checkDisksButton;
        private Button serviceManagementButton;
        private Button groupPoliciesButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button unblockTaskmgrButton;
        private Button unblockRegeditButton;
        private Button resetHostsButton;
        private Button resetAssociationsButton;
        private GroupBox groupBox4;
        private Button resetUpdateCenterButton;
        private Button pcManagerButton;
        private Button restartExplorerButton;
        private Button safeModeBootButton;
        private Button normalBootButton;
        private Button activateWindowsButton;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
    }
}
