
using System.Drawing;
using System.Drawing.Imaging;

namespace LabelGenerator
{
    public class Generator : ILabelGenerator
    {
        public void GenerateLabel(string path)
        {
            Image image = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(LabelData.label);
            image.Save("test.jpg", ImageFormat.Jpeg);
            
        }

        
    }

}



/*
 
 
 public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
        htmlPanel.Text = "<p><h1>Hello World</h1>This is html rendered text</p>";
        htmlPanel.Dock = DockStyle.Fill;
        Controls.Add(htmlPanel);
    }
}

***************************************************************************************************
********** Quick Start: Create image from HTML snippet

class Program
{
    private static void Main(string[] args)
    {
        Image image = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage("<p><h1>Hello World</h1>This is html rendered text</p>");
        image.Save("image.png", ImageFormat.Png);
    }
}
 */