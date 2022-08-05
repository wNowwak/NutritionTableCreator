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
        }
        private object[] getUnitsName()
        {
            var units = _sqlRepository.GetUnits();
            return units.ToList().Select(x => x.Name).ToArray();

        }

        public void SetUnits()
        {
            var units = getUnitsName();
            this.MassUnit.Items.AddRange(units);
            this.TotalUnit.Items.AddRange(units);
        }

        protected void AddComponent()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newComponent = dataGridView1.Rows[0];
            var productName = newComponent.Cells[0].Value.ToString();
            var productContent = newComponent.Cells[1].Value.ToString();
            var massUnit = newComponent.Cells[2].Value.ToString();
            var totalMass = newComponent.Cells[3].Value.ToString();
            var totalMassUnit = newComponent.Cells[4].Value.ToString();

            

        }
    }
}
