using Windows.UI;

namespace FontSvgImageSource
{
    public static class ColorExtensions
    {
        public static Color Alpha(this Color original, byte alpha)
        {
            return Color.FromArgb(alpha, original.R, original.G, original.B);
        }
    }
}
