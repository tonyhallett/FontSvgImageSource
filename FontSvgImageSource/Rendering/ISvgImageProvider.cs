using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace FontSvgImageSource
{
    public interface ISvgImageProvider
    {
        Image Provide(string fontFamily, float fontSize, string glyph, Color iconColor);
    }
}
