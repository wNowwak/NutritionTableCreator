using NutritionCreatorFramework.DataObjects;
using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.LabelToPngGenerator.Interfaces;
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
        private readonly ILabelGenerator _generator;
        private IEnumerable<IUnit> units = new List<IUnit>();
        private readonly ISqlRepository _sqlRepository;
        private IEnumerable<IProduct> Products = new List<IProduct>();
        private IEnumerable<string> Components = new List<string>();
        private readonly string _workingDirectoryPath;


        public NewComponent(ISqlRepository sqlRepository, ILabelGenerator generator, string workingDirectoryPath)
        {
            
            _sqlRepository = sqlRepository;
            _generator = generator;
            _workingDirectoryPath = workingDirectoryPath;
            InitializeComponent();
            SetUnits();
            AddComponent();
            //HideUnusedLabels();
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
            this.boxUnit.Items.AddRange(units);
        }

        public void AddComponent()
        {
            Components = _sqlRepository.GetComponents();
            Products  = _sqlRepository.GetProducts();
            foreach (var component in Components)
                this.ProductNameField.Items.AddRange(component);
            foreach (var product in Products)
                this.ProductNameField.Items.AddRange(product.Name);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = Queries.AddProduct;
            var parameter = new SqlParameter() { ParameterName = "@ProductValue", Value = txtProductName.Text , DbType = DbType.String, Size = 1024 };
            _sqlRepository.AddProduct(query, new List<SqlParameter>() { parameter }, out int newId);
            var ingredients = new List<IIngredient>();
            if(newId > 0)
            {
                
                    
                var totalUnitId = units.Where(unit => unit.Name.Equals(unitDDL.Text ?? String.Empty)).FirstOrDefault()?.Id ?? 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var productName = row.Cells[0]?.Value?.ToString();
                    var productContent = StringExtensionMethod.GetDecimalFromString(row.Cells[1]?.Value?.ToString() ?? String.Empty);
                    var massUnit = row.Cells[2]?.Value?.ToString();
                    bool result = false;
                    var unitProduct = units.Where(x => x.Name == massUnit).FirstOrDefault();
                    if(!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(massUnit) && productContent > 0  && totalUnitId > 0)
                    {
                        if (Components.Contains(productName))
                        {
                            result = _sqlRepository.SaveReciepeToDataBase(newId, productName, massUnit, productContent, totalUnitId, txtReadyMass?.Text);
                            ingredients.Add(new Ingredient(productName, newId, productContent, unitProduct));
                        }
                        else
                        {
                            var product = Products.Where(x => x.Name.Equals(productName)).FirstOrDefault();
                            if (product != null)
                            {
                                foreach (var ingerdient in product.GetIngredients())
                                {
                                    decimal qty = Convert.ToDecimal(Math.Pow(10, units.Where(x => x.Name == massUnit).Select(x => x.Counter).FirstOrDefault())) * ingerdient.Quantity * productContent;
                                    qty = qty / product.Quantity;
                                    qty = ConvertToNewUnit(qty, out IUnit newUnit);
                                    result = _sqlRepository.SaveReciepeToDataBase(newId, ingerdient.Name, newUnit.Name, qty, totalUnitId, txtReadyMass?.Text);
                                    ingredients.Add(new Ingredient(ingerdient.Name, newId, qty, newUnit));
                                }
                            }
                        }
                        
                    }
                }
                var readyMass = StringExtensionMethod.GetDecimalFromString(txtReadyMass.Text);
                var readyUnit = GetUnit(unitDDL.Text);
                var boxMass = StringExtensionMethod.GetDecimalFromString(txtBoxSize.Text);
                var boxUnit = GetUnit(this.boxUnit.Text);
                var portionCount = StringExtensionMethod.GetDecimalFromString(txtProtionCount.Text);
                _generator.GenerateLabel($"{_workingDirectoryPath}", ingredients, new Box(boxUnit, boxMass),new Box(readyUnit, readyMass), portionCount, this.units, $"/{ txtProductName.Text.Trim()}.jpg");

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = newId == -2146232060 ? "Podany produkt już istnieje" : "Błąd w zapisie produktu";
                lblError.ForeColor = Color.Red;
                this.Refresh();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private decimal ConvertToNewUnit(decimal quantity, out IUnit unit)
        {
            unit = null;
            decimal counter;
            if (quantity >= Convert.ToDecimal(Math.Pow(10, 3)))
            {
                counter = 1000;
                quantity = quantity / counter;

                unit = GetUnit(3);
                return quantity;
            }
            else if(quantity < 0 && quantity >= Convert.ToDecimal(Math.Pow(10, -6)))
            {
                counter = Convert.ToDecimal(Math.Pow(10, -3));
                quantity = quantity / counter;
                unit= GetUnit(-3);
                return quantity;
            }
            else if(quantity < Convert.ToDecimal(Math.Pow(10, -6)))
            {
                counter = Convert.ToDecimal(Math.Pow(10, -6));
                quantity = quantity / counter;
                unit= GetUnit(-6);
                return quantity;
            }
            else
            {
                unit = GetUnit(0);
                return quantity;
            }

            

        }
        private IUnit GetUnit(int counter)
        {
            return units.Where(x => x.Counter == counter && !x.IsLiquid).FirstOrDefault();
        }
        private IUnit GetUnit(string name)
        {
            return units.Where(x => x.Name == name).FirstOrDefault();
        }

        private void unitDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var ddl = (ComboBox)sender;
            //var unit = GetUnit(ddl.SelectedItem.ToString());
            //if(unit != null)
            //{
            //        lblBoxSize.Visible = unit.IsLiquid;
            //        lblPortionCount.Visible = unit.IsLiquid;
            //        txtProtionCount.Visible = unit.IsLiquid;
            //        txtBoxSize.Visible = unit.IsLiquid;
            //        boxUnit.Visible = unit.IsLiquid;

                

            //}
            
        }
        private void HideUnusedLabels()
        {
            lblBoxSize.Visible = false;
            lblPortionCount.Visible = false;
            txtProtionCount.Visible = false;
            txtBoxSize.Visible = false;
            boxUnit.Visible = false;
            lblError.Visible = false;
        }
    }
}
