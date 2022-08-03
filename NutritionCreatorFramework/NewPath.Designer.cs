namespace NutritionCreatorFramework
{
    partial class NewPath
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.usrLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 12);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(611, 20);
            this.txtPath.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // usrLog
            // 
            this.usrLog.AutoSize = true;
            this.usrLog.ForeColor = System.Drawing.Color.Red;
            this.usrLog.Location = new System.Drawing.Point(12, 43);
            this.usrLog.Name = "usrLog";
            this.usrLog.Size = new System.Drawing.Size(133, 13);
            this.usrLog.TabIndex = 2;
            this.usrLog.Text = "Podany katalog nie istnieje";
            // 
            // NewPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 67);
            this.Controls.Add(this.usrLog);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPath);
            this.Name = "NewPath";
            this.Text = "NewPath";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label usrLog;
    }
}