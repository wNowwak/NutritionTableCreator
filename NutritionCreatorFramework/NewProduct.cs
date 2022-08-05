using NutritionCreatorFramework.DbConnection.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            

            foreach (DataGridViewRow row in products.Rows)
            {
                string value = row.Cells[0]?.Value?.ToString(); 
                if (string.IsNullOrEmpty(value))
                    continue;
                string query = "INSERT INTO Skladniki (Skaldnik_Nazwa) VALUES(@PRODUCT_VALUE)";
                SqlParameter sqlParameter = new SqlParameter() { ParameterName = "@PRODUCT_VALUE", Value = value, Size = 1024, DbType = DbType.String };
                var result = _sqlRepository.AddProduct(query, sqlParameter);
                if (!result)
                {
                    errorLbl.Text = $"Błąd podczas zapisu produktu: {value}";
                    errorLbl.Visible = true;
                    this.Refresh();
                }
                
                    
            }
            


        }
    }
}
