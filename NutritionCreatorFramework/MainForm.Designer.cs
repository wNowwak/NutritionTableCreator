namespace NutritionCreatorFramework
{
    partial class MainForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnDefNutrition = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 415);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(187, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Połączenie  do bazy danych";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(576, 415);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(212, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generuj etykietę";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnDefNutrition
            // 
            this.btnDefNutrition.Location = new System.Drawing.Point(12, 13);
            this.btnDefNutrition.Name = "btnDefNutrition";
            this.btnDefNutrition.Size = new System.Drawing.Size(187, 23);
            this.btnDefNutrition.TabIndex = 2;
            this.btnDefNutrition.Text = "Definiuj składnik";
            this.btnDefNutrition.UseVisualStyleBackColor = true;
            this.btnDefNutrition.Click += new System.EventHandler(this.btnDefNutrition_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ścieżka katalogu roboczego";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDefNutrition);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainForm";
            this.Text = "Generator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnDefNutrition;
        private System.Windows.Forms.Button button1;
    }
}

