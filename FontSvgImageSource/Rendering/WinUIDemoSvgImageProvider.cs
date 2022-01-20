using Windows.UI.Xaml.Controls;

namespace FontSvgImageSource
{
    public class WinUIDemoSvgImageProvider : SvgImageProvider
    {
        public WinUIDemoSvgImageProvider() : base(new WinUIFontSvgPathDataProvider())
        { }

        protected override void ConfigureImage(Image image)
        {
            image.Width = FontSize;
            image.Height = FontSize;
            base.ConfigureImage(image);
        }

        protected override string SvgAttributes()
        {
            return $"viewBox=\"0 0 { FontSize} {FontSize }\"";
        }
    }

}
