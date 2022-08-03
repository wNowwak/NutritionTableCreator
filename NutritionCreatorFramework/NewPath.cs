using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionCreatorFramework
{
    public partial class NewPath : Form
    {
        public NewPath()
        {
            InitializeComponent();
            usrLog.Visible = false;
            LoadPath();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {
                using (var sw = new StreamWriter("workingPath",false))
                {
                    sw.WriteLine(txtPath.Text);
                    usrLog.Visible = false;
                }
                
            }
            else
                usrLog.Visible = true;
            this.Refresh();
                
        }

        private void LoadPath()
        {
            if (File.Exists("workingPath"))
            {
                using (var sr = new StreamReader("workingPath"))
                {
                    txtPath.Text = sr.ReadToEnd();
                    this.Refresh();
                }
            }
            
        }
    }
}
