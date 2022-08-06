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
            this.btnSave = new System.Windows.Forms.Button();
            this.ProductNameField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MassUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtReadyMass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unitDDL = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(182, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(193, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Zapisz składnik";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // txtReadyMass
            // 
            this.txtReadyMass.Location = new System.Drawing.Point(147, 293);
            this.txtReadyMass.Name = "txtReadyMass";
            this.txtReadyMass.Size = new System.Drawing.Size(100, 20);
            this.txtReadyMass.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Masa gotowego produktu";
            // 
            // unitDDL
            // 
            this.unitDDL.FormattingEnabled = true;
            this.unitDDL.Location = new System.Drawing.Point(254, 292);
            this.unitDDL.Name = "unitDDL";
            this.unitDDL.Size = new System.Drawing.Size(121, 21);
            this.unitDDL.TabIndex = 5;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(147, 320);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(228, 20);
            this.txtProductName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nazwa produktu";
            // 
            // NewComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 395);
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
    }
}