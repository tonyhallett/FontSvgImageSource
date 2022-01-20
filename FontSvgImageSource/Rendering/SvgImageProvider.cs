using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FontSvgImageSource
{

    public class SvgImageProvider : ISvgImageProvider
    {
        private readonly IFontSvgPathDataProvider fontSvgPathDataProvider;
        protected float FontSize { get; private set; }
        public SvgImageProvider(IFontSvgPathDataProvider fontSvgPathDataProvider)
        {
            this.fontSvgPathDataProvider = fontSvgPathDataProvider;
        }

        public Image Provide(string fontFamily, float fontSize, string glyph, Color iconColor)
        {
            this.FontSize = fontSize;
            var svgPathData = fontSvgPathDataProvider.Provide(fontFamily,  glyph, GetPathDataFontSize(fontSize));

            var svgImageSource = SvgImageSource(svgPathData, iconColor, SvgAttributes());
            ConfigureImageSource(svgImageSource);

            var svgImage = new Image { Source = svgImageSource };
            ConfigureImage(svgImage);
            return svgImage;
        }

        private SvgImageSource SvgImageSource(string svgPathData, Color color, string svgAttributes)
        {
            var svgColor = $"rgb({color.R},{color.G},{color.B})";
            var opacity = ((double)color.A) / 255;
            var svg = Svg($"<path fill-opacity=\"{opacity}\"  fill=\"{svgColor}\" d=\"{svgPathData}\"/>", svgAttributes);
            var imageSource = SvgImageSourceHelper.FromContentAsync(svg).GetAwaiter().GetResult();
            return imageSource;
        }

        protected virtual string SvgAttributes() { return string.Empty; }

        protected virtual void ConfigureImageSource(SvgImageSource svgImageSource) { }

        protected virtual void ConfigureImage(Image image) {}

        private string Svg(string contents, string svgAttributes)
        {
            return $"<svg {svgAttributes}  xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">{contents}</svg>";
        }

        
        protected virtual float GetPathDataFontSize(float fontSize) => fontSize;
    }


}
