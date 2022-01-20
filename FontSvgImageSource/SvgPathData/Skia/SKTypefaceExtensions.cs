using SkiaSharp;
using System.Reflection;

namespace FontSvgImageSource
{
    public static class SKTypefaceExtensions
    {
        public static SKTypeface SKTypefaceFromResource(this Assembly assembly, string resource)
        {
            SKTypeface result;

            var stream = assembly.GetManifestResourceStream(resource);
            if (stream == null)
                return null;

            result = SKTypeface.FromStream(stream);
            return result;
        }
    }
}
