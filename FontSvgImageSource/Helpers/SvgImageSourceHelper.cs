using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace FontSvgImageSource
{
    public static class SvgImageSourceHelper
    {
        public static async Task<SvgImageSource> FromContentAsync(string content)
        {
            var svgImageSource = new SvgImageSource();
            var memoryStream = new InMemoryRandomAccessStream();
            await memoryStream.WriteContentAsync(content);
            _ =  svgImageSource.SetSourceAsync(memoryStream);
            return svgImageSource;
        }
    }


}
