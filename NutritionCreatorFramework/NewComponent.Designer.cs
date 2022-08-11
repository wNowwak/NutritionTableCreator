using NutritionCreatorFramework.DbConnection.MSSql;
using System.Linq;

namespace NutritionCreatorFramework
{
    partial class NewComponent
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
        /// 
        
       
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductNameField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MassUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReadyMass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unitDDL = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtBoxSize = new System.Windows.Forms.TextBox();
            this.txtProtionCount = new System.Windows.Forms.TextBox();
            this.lblBoxSize = new System.Windows.Forms.Label();
            this.lblPortionCount = new System.Windows.Forms.Label();
            this.boxUnit = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductNameField,
            this.Count,
            this.MassUnit});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 271);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ProductNameField
            // 
            this.ProductNameField.HeaderText = "Nazwa składnika";
            this.ProductNameField.MaxDropDownItems = 100;
            this.ProductNameField.Name = "ProductNameField";
            this.ProductNameField.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductNameField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductNameField.Width = 300;
            // 
            // Count
            // 
            this.Count.HeaderText = "Zawartość";
            this.Count.Name = "Count";
            this.Count.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MassUnit
            // 
            this.MassUnit.HeaderText = "Jednostka";
            this.MassUnit.Name = "MassUnit";
            this.MassUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MassUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(568, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(351, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Zapisz składnik i generuj etykietę";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReadyMass
            // 
            this.txtReadyMass.Location = new System.Drawing.Point(692, 5);
            this.txtReadyMass.Name = "txtReadyMass";
            this.txtReadyMass.Size = new System.Drawing.Size(100, 20);
            this.txtReadyMass.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Masa gotowego produktu";
            // 
            // unitDDL
            // 
            this.unitDDL.FormattingEnabled = true;
            this.unitDDL.Location = new System.Drawing.Point(798, 4);
            this.unitDDL.Name = "unitDDL";
            this.unitDDL.Size = new System.Drawing.Size(121, 21);
            this.unitDDL.TabIndex = 5;
            this.unitDDL.SelectedIndexChanged += new System.EventHandler(this.unitDDL_SelectedIndexChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(691, 37);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(228, 20);
            this.txtProductName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nazwa produktu";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(12, 297);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "lblError";
            // 
            // txtBoxSize
            // 
            this.txtBoxSize.Location = new System.Drawing.Point(692, 117);
            this.txtBoxSize.Name = "txtBoxSize";
            this.txtBoxSize.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSize.TabIndex = 9;
            // 
            // txtProtionCount
            // 
            this.txtProtionCount.Location = new System.Drawing.Point(692, 76);
            this.txtProtionCount.Name = "txtProtionCount";
            this.txtProtionCount.Size = new System.Drawing.Size(100, 20);
            this.txtProtionCount.TabIndex = 10;
            // 
            // lblBoxSize
            // 
            this.lblBoxSize.AutoSize = true;
            this.lblBoxSize.Location = new System.Drawing.Point(565, 120);
            this.lblBoxSize.Name = "lblBoxSize";
            this.lblBoxSize.Size = new System.Drawing.Size(106, 13);
            this.lblBoxSize.TabIndex = 11;
            this.lblBoxSize.Text = "Rozmiar opakowania";
            // 
            // lblPortionCount
            // 
            this.lblPortionCount.AutoSize = true;
            this.lblPortionCount.Location = new System.Drawing.Point(565, 76);
            this.lblPortionCount.Name = "lblPortionCount";
            this.lblPortionCount.Size = new System.Drawing.Size(60, 13);
            this.lblPortionCount.TabIndex = 12;
            this.lblPortionCount.Text = "Ilość porcji:";
            // 
            // boxUnit
            // 
            this.boxUnit.FormattingEnabled = true;
            this.boxUnit.Location = new System.Drawing.Point(798, 116);
            this.boxUnit.Name = "boxUnit";
            this.boxUnit.Size = new System.Drawing.Size(121, 21);
            this.boxUnit.TabIndex = 13;
            // 
            // NewComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 316);
            this.Controls.Add(this.boxUnit);
            this.Controls.Add(this.lblPortionCount);
            this.Controls.Add(this.lblBoxSize);
            this.Controls.Add(this.txtProtionCount);
            this.Controls.Add(this.txtBoxSize);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.unitDDL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReadyMass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NewComponent";
            this.Text = "Definiowanie nowego składnika";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductNameField;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewComboBoxColumn MassUnit;
        private System.Windows.Forms.TextBox txtReadyMass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox unitDDL;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtBoxSize;
        private System.Windows.Forms.TextBox txtProtionCount;
        private System.Windows.Forms.Label lblBoxSize;
        private System.Windows.Forms.Label lblPortionCount;
        private System.Windows.Forms.ComboBox boxUnit;
    }
}