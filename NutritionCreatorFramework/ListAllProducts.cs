using NutritionCreatorFramework.DbConnection.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionCreatorFramework
{
    public partial class ListAllProducts : Form
    {
        private readonly ISqlRepository _sqlRepository;
        private IDictionary<int, string> _reciepes;
        public ListAllProducts(ISqlRepository repository)
        {
            _sqlRepository = repository;
            InitializeComponent();
        }
       

        private DataTable GetProducts(int id)
        {
            var products = _sqlRepository.GetIngredientsForProduct(id);
            var dataTable = new DataTable();
            dataTable.Columns.Add("Nazwa", typeof(string));
            dataTable.Columns.Add("Ilość", typeof(decimal));
            dataTable.Columns.Add("Jendostka", typeof(string));
            dataTable.Columns.Add("Masa całkowita produktu", typeof(string));
            foreach (var ingredient in products.Ingredients)
            {
                dataTable.Rows.Add(new object[] { ingredient.Name, ingredient.Quantity, ingredient.Unit.Name , $"{products.Quantity} {products.Unit.Name}"});
            }

            return dataTable;
        }
        private IList<string> GetProductsName()
        {
            _reciepes = _sqlRepository.GetReciepes();
            return _reciepes.Select(x => x.Value).ToList();
        }

        private void ListAllProducts_Load(object sender, EventArgs e)
        {
            productName.DataSource = GetProductsName();
        }

        private void productName_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiptData.DataSource =  GetProducts(_reciepes.Where(x => x.Value.Equals(((ComboBox)sender).SelectedItem.ToString())).FirstOrDefault().Key);
        }
    }
}
