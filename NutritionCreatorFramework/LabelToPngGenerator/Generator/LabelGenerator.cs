using NutritionCreatorFramework.LabelToPngGenerator.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace NutritionCreatorFramework.LabelToPngGenerator.Generator
{
    public class LabelGenerator : ILabelGenerator
    {
        public void GenerateLabel(string path)
        {
            var htmlContent = string.Empty;
            using (var reader = new StreamReader(@"C:\Users\nowwa\source\repos\NutritionCreator\label.html"))
            {
                htmlContent = reader.ReadToEnd().Trim();
            }
            Image image = HtmlRender.RenderToImage(htmlContent);
            image.Save("image.png", ImageFormat.Png);

        }


    }
}