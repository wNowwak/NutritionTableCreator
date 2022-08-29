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
            this.btnDefNutrition = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddRecipt = new System.Windows.Forms.Button();
            this.btnCheckRecipe = new System.Windows.Forms.Button();
            this.btnAddProtein = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(12, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ścieżka katalogu roboczego";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddRecipt
            // 
            this.btnAddRecipt.Location = new System.Drawing.Point(12, 42);
            this.btnAddRecipt.Name = "btnAddRecipt";
            this.btnAddRecipt.Size = new System.Drawing.Size(187, 23);
            this.btnAddRecipt.TabIndex = 4;
            this.btnAddRecipt.Text = "Dodaj recepturę";
            this.btnAddRecipt.UseVisualStyleBackColor = true;
            this.btnAddRecipt.Click += new System.EventHandler(this.btnAddRecipt_Click);
            // 
            // btnCheckRecipe
            // 
            this.btnCheckRecipe.Location = new System.Drawing.Point(12, 71);
            this.btnCheckRecipe.Name = "btnCheckRecipe";
            this.btnCheckRecipe.Size = new System.Drawing.Size(187, 23);
            this.btnCheckRecipe.TabIndex = 5;
            this.btnCheckRecipe.Text = "Podgląd receptur";
            this.btnCheckRecipe.UseVisualStyleBackColor = true;
            this.btnCheckRecipe.Click += new System.EventHandler(this.btnCheckRecipe_Click);
            // 
            // btnAddProtein
            // 
            this.btnAddProtein.Location = new System.Drawing.Point(13, 101);
            this.btnAddProtein.Name = "btnAddProtein";
            this.btnAddProtein.Size = new System.Drawing.Size(186, 23);
            this.btnAddProtein.TabIndex = 6;
            this.btnAddProtein.Text = "Dodaj białko";
            this.btnAddProtein.UseVisualStyleBackColor = true;
            this.btnAddProtein.Click += new System.EventHandler(this.btnAddProtein_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Konfiguracja";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddProtein);
            this.Controls.Add(this.btnCheckRecipe);
            this.Controls.Add(this.btnAddRecipt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDefNutrition);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainForm";
            this.Text = "Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDefNutrition;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddRecipt;
        private System.Windows.Forms.Button btnCheckRecipe;
        private System.Windows.Forms.Button btnAddProtein;
        private System.Windows.Forms.Label label1;
    }
}

