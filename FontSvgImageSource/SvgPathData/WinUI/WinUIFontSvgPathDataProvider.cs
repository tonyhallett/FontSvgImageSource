using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.Text;

namespace FontSvgImageSource
{
    public class WinUIFontSvgPathDataProvider : IFontSvgPathDataProvider
    {
        public string Provide(string fontFamily, string glyph, float fontSize)
        {
            var canvasTextFormat = new CanvasTextFormat
            {
                FontFamily = fontFamily,
                FontSize = fontSize,
            };
            var canvasTextLayout = new CanvasTextLayout(CanvasDevice.GetSharedDevice(), glyph, canvasTextFormat, fontSize, fontSize);
            canvasTextLayout.HorizontalAlignment = CanvasHorizontalAlignment.Left;
            var canvasGeometry = CanvasGeometry.CreateText(canvasTextLayout);
            var pathReader = new CanvasGeometryToSvgPathReader();
            canvasGeometry.SendPathTo(pathReader);
            return pathReader.Path;
        }
    }
}
