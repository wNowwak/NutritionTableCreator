using Ninject;
using NutritionCreatorFramework.DbConnection.Bindings;
using NutritionCreatorFramework.DbConnection.Interfaces;
using NutritionCreatorFramework.LabelToPngGenerator.Bindings;
using NutritionCreatorFramework.LabelToPngGenerator.Interfaces;
using NutritionCreatorFramework.UserLogger.Bindings;
using NutritionCreatorFramework.UserLogger.Interfaces;
using System;
using System.Windows.Forms;

namespace NutritionCreatorFramework
{
    public partial class MainForm : Form
    {
        private readonly ILabelGenerator _generator;
        private readonly IUserLogger _logger;
        private readonly ISqlConnector _sqlConnector;
        public MainForm()
        {
            InitializeComponent();
            using (var kernel = new StandardKernel(new LabelToPngGeneratorBindings(), new UserLoggerBindings(), new MSSqlConnectorBindings()))
            {
                _generator = kernel.Get<ILabelGenerator>();
                _logger = kernel.Get<ILoggerFactory>().Create("file");

                _sqlConnector = kernel.Get<ISqlConnector>();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var connectionWindow = new DataBaseConnector(_logger, _sqlConnector);
            connectionWindow.ShowDialog();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _generator.GenerateLabel(@"");
        }

        private void btnDefNutrition_Click(object sender, EventArgs e)
        {
            var newComponent = new NewComponent();
            newComponent.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newPath = new NewPath();
            newPath.ShowDialog();
        }
    }
}
