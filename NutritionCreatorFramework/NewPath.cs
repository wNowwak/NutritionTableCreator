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
        public string GetPath()
        {
            if (File.Exists("workingPath"))
            {
                using (var sr = new StreamReader("workingPath"))
                {
                   return sr.ReadToEnd().Trim();
                }
            }
            return string.Empty;
        }

        private void LoadPath()
        {
            txtPath.Text = GetPath();
            this.Refresh();
        }
    }
}
