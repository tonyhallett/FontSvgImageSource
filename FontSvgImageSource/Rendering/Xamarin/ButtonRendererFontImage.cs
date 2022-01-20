using Windows.UI.Xaml.Controls;

namespace FontSvgImageSource
{
    internal static class ButtonRendererFontImage
    {
        public static Image Get(string fontFamily, float fontSize, string glyph, Windows.UI.Color iconColor)
        {
            var canvasImageSource = FontImageSourceHandler.CanvasImageSource(fontFamily, fontSize, glyph, iconColor);
            return  new Image
            {
                Source = canvasImageSource,
                Width = canvasImageSource.Size.Width,
                Height = canvasImageSource.Size.Height
            };
        } 
    }
}
