using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.Units;
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
    public partial class AddProtein : Form
    {
        private readonly ISqlRepository _sqlRepository;
        private readonly IEnumerable<IUnit> _units;
        public AddProtein(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
            _units = _sqlRepository.GetUnits();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtProteinName.Text;
            var humidity = StringExtensionMethod.GetDecimalFromString(txtHumidity.Text);
            var proteinContent = StringExtensionMethod.GetDecimalFromString(txtProteinContent.Text);
            List<SqlParameter> parameters = new List<SqlParameter>() { 
            new SqlParameter(){ ParameterName = "@ProductValue", Value = name, DbType = DbType.String, Size = 255} };

            _sqlRepository.AddProduct(Queries.AddProduct, parameters, out int newId);
            parameters.Clear();
            var total = CountProteinContent(humidity, proteinContent);
            _sqlRepository.SaveReciepeToDataBase(newId, "BIAŁKO", "gram", total, _units.Where(x => x.Counter == 0).FirstOrDefault().Id, "100");
            
        }

        private decimal CountProteinContent(decimal humidity, decimal proteinContent)
        {
            decimal total = Math.Round(proteinContent *((100-humidity)/100),2);
            
            return total;
        }
    }
}
