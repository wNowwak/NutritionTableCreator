using NutritionCreatorFramework.DataObjects;
using NutritionCreatorFramework.HtmlFactory;
using NutritionCreatorFramework.LabelToPngGenerator.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace NutritionCreatorFramework.LabelToPngGenerator.Generator
{
    public class LabelGenerator : ILabelGenerator
    {
        private readonly HtmlGenerator _htmlGenerator;

        public LabelGenerator(HtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }

        public void GenerateLabel(string path, IList<IIngredient> ingredients)
        {
            var htmlContent = string.Empty;
            using (var reader = new StreamReader(path+@"\label.html"))
            {
                htmlContent = reader.ReadToEnd().Trim();
            }

            htmlContent = htmlContent.Replace("**ROWS**", CreateContent(ingredients));


            Image image = HtmlRender.RenderToImage(htmlContent);
            image.Save("image.png", ImageFormat.Png);

        }


        private string CreateContent(IList<IIngredient> ingredients)
        {
            return _htmlGenerator.GetHtml(ingredients);
        }
    }
}