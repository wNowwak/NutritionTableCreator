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
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MassUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TotalMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.Count,
            this.MassUnit,
            this.TotalMass,
            this.TotalUnit});
            this.dataGridView1.Location = new System.Drawing.Point(19, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 271);
            this.dataGridView1.TabIndex = 0;
            // 
            // Nazwa
            // 
            this.Nazwa.HeaderText = "ComponentName";
            this.Nazwa.Name = "Nazwa";
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
            // TotalMass
            // 
            this.TotalMass.HeaderText = "Masa";
            this.TotalMass.Name = "TotalMass";
            // 
            // TotalUnit
            // 
            this.TotalUnit.HeaderText = "Jednostka";
            this.TotalUnit.Name = "TotalUnit";
            this.TotalUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TotalUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // NewComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 395);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NewComponent";
            this.Text = "Definiowanie nowego składnika";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewComboBoxColumn MassUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMass;
        private System.Windows.Forms.DataGridViewComboBoxColumn TotalUnit;
    }
}