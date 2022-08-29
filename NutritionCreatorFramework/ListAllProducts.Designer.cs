namespace NutritionCreatorFramework
{
    partial class ListAllProducts
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
            this.receiptData = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.receiptData)).BeginInit();
            this.SuspendLayout();
            // 
            // receiptData
            // 
            this.receiptData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptData.Location = new System.Drawing.Point(12, 45);
            this.receiptData.Name = "receiptData";
            this.receiptData.Size = new System.Drawing.Size(776, 393);
            this.receiptData.TabIndex = 0;
            // 
            // productName
            // 
            this.productName.FormattingEnabled = true;
            this.productName.Location = new System.Drawing.Point(13, 13);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(177, 21);
            this.productName.TabIndex = 1;
            this.productName.SelectedIndexChanged += new System.EventHandler(this.productName_SelectedIndexChanged);
            // 
            // ListAllProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.receiptData);
            this.Name = "ListAllProducts";
            this.Text = "ListAllProducts";
            this.Load += new System.EventHandler(this.ListAllProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.receiptData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView receiptData;
        private System.Windows.Forms.ComboBox productName;
    }
}