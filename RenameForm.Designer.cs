namespace VirusBypass
{
    partial class RenameForm
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
            txtNewName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(107, 18);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(307, 27);
            txtNewName.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(260, 67);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(107, 29);
            btnOk.TabIndex = 1;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(46, 67);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 3;
            label1.Text = "Новое имя:";
            // 
            // RenameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 115);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtNewName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RenameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Переименование файла";
            Load += RenameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNewName;
        private Button btnOk;
        private Button btnCancel;
        private Label label1;
    }
}