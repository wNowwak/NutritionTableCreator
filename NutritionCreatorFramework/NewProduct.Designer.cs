namespace NutritionCreatorFramework
{
    partial class NewProduct
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
            this.products = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.products)).BeginInit();
            this.SuspendLayout();
            // 
            // products
            // 
            this.products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName});
            this.products.Location = new System.Drawing.Point(13, 13);
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(775, 384);
            this.products.TabIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Nazwa Produktu";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 1000;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(492, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Zapisz produkty";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.ForeColor = System.Drawing.Color.Red;
            this.errorLbl.Location = new System.Drawing.Point(13, 435);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(35, 13);
            this.errorLbl.TabIndex = 2;
            this.errorLbl.Text = "label1";
            this.errorLbl.Visible = false;
            // 
            // NewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.products);
            this.Name = "NewProduct";
            this.Text = "NewProduct";
            ((System.ComponentModel.ISupportInitialize)(this.products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView products;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label errorLbl;
    }
}