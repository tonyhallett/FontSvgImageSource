using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace FontSvgImageSource
{
    public static class GeometryConverter
    {
        public static Geometry Convert(string pathData)
        {
            return (Geometry)XamlReader.Load(
            "<Geometry xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>"
            + pathData + "</Geometry>");
        }
    }
}
