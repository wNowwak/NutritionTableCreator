using NutritionCreatorFramework.Units;
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
    public partial class NewComponent : Form
    {
        private List<IUnit> units = new List<IUnit>();

        private void InitializeUnits()
        {

        }
        public NewComponent()
        {
            InitializeComponent();
            
        }
    }
}
