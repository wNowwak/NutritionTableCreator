using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionCreatorFramework
{
    public partial class NewComponent : Form
    {
        private IEnumerable<IUnit> units = new List<IUnit>();
        private readonly ISqlRepository _sqlRepository;
       
        public NewComponent(ISqlRepository sqlRepository)
        {
            
            _sqlRepository = sqlRepository;
            InitializeComponent();
            SetUnits();
            AddComponent();
        }
        private object[] getUnitsName()
        {
            units = _sqlRepository.GetUnits();
            return units.ToList().Select(x => x.Name).ToArray();

        }

        public void SetUnits()
        {
            var units = getUnitsName();
            this.MassUnit.Items.AddRange(units);
            this.unitDDL.Items.AddRange(units);
        }

        public void AddComponent()
        {
            var components = _sqlRepository.GetComponents();
            foreach (var component in components)
                this.ProductNameField.Items.AddRange(component);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = Queries.AddProduct;
            var parameter = new SqlParameter() { ParameterName = "@ProductValue", Value = txtProductName.Text , DbType = DbType.String, Size = 1024 };
            _sqlRepository.AddProduct(query, new List<SqlParameter>() { parameter }, out int newId);
            if(newId > 0)
            {
                var totalMass = StringExtensionMethod.GetDecimalFromString(txtReadyMass.Text ?? String.Empty);
                var totalUnitId = units.Where(unit => unit.Name.Equals(unitDDL.Text ?? String.Empty)).FirstOrDefault()?.Id;
                query = Queries.AddReciepe;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var parameters = new List<SqlParameter>();
                    var productName = row.Cells[0]?.Value?.ToString();
                    var productContent = StringExtensionMethod.GetDecimalFromString(row.Cells[1]?.Value?.ToString() ?? String.Empty);
                    var massUnit = row.Cells[2]?.Value?.ToString();

                    if(!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(massUnit) && productContent > 0  && totalUnitId > 0)
                    {
                        parameters.Add(CreateSqlParameter("@PRODUCT_ID", newId, "int"));
                        parameters.Add(CreateSqlParameter("@SKLADNIK_NAZWA", productName, "string", 1024));
                        parameters.Add(CreateSqlParameter("@UNIT_ID", units.Where(uni => uni.Name.Equals(massUnit)).FirstOrDefault().Id, "int"));
                        parameters.Add(CreateSqlParameter("@COMPONENT_QUANTITY", productContent, "decimal"));
                        parameters.Add(CreateSqlParameter("@TOTAL_MASS", totalMass, "decimal"));
                        parameters.Add(CreateSqlParameter("@TOTAL_UNIT_ID", totalUnitId, "int"));


                        _sqlRepository.AddProduct(query, parameters, out int x);
                    }
                }
               
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("AALA");
        }


        private SqlParameter CreateSqlParameter(string name, dynamic value, string type, int size = 0)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            if (type == "int")
                parameter.DbType = DbType.Int32;
            else if (type == "string")
            {
                parameter.DbType = DbType.String;
                parameter.Size = size;
            }
            else if (type == "decimal")
            {
                parameter.DbType = DbType.Decimal;
                parameter.Precision = 10;
                parameter.Scale = 4;
            }
            return parameter;
        }
    }
}
