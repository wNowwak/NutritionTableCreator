using NutritionCreatorFramework.DbConnection.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NutritionCreatorFramework
{
    public partial class NewProduct : Form
    {
        private readonly ISqlRepository _sqlRepository;
        public NewProduct(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            bool result = false;

            foreach (DataGridViewRow row in products.Rows)
            {
                string value = row.Cells[0]?.Value?.ToString(); 
                if (string.IsNullOrEmpty(value))
                    continue;
                string query = "INSERT INTO Skladniki (Skaldnik_Nazwa) VALUES(@PRODUCT_VALUE)";
                SqlParameter sqlParameter = new SqlParameter() { ParameterName = "@PRODUCT_VALUE", Value = value, Size = 1024, DbType = DbType.String };
                result = _sqlRepository.AddProduct(query, new List<SqlParameter>() { sqlParameter }, out int newId);
                if (!result)
                {
                    errorLbl.Text = $"Błąd podczas zapisu produktu: {value}";
                    errorLbl.Visible = true;
                    errorLbl.ForeColor = System.Drawing.Color.Red;
                    this.Refresh();
                }
                
                    
            }
            if(result)
            {
                errorLbl.Text = $"Zapisano pomyślnie";
                errorLbl.Visible = true;
                errorLbl.ForeColor = System.Drawing.Color.Green;
                this.Refresh();
            }


        }
    }
}
