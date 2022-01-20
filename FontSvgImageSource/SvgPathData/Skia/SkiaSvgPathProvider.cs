using SkiaSharp;
using System.Reflection;

namespace FontSvgImageSource
{
    public static class SkiaSvgPathProvider
    {
        public static string GetPathData(string fullFontName, string glyph, float size)
        {
            return GetIconPath(GetTypeface(fullFontName), glyph, size).ToSvgPathData();
        }
        private static SKTypeface GetTypeface(string fullFontName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.SKTypefaceFromResource($"FontSvgImageSource.Resources.${fullFontName}");
        }

        private static SKPath GetIconPath(SKTypeface typeface, string glyph, float size)
        {
            using (SKPaint textPaint = new SKPaint { TextSize = size, Typeface = typeface, IsAntialias = true, FilterQuality = SKFilterQuality.High, SubpixelText = true })
            {
                SKRect bounds = new SKRect();
                textPaint.MeasureText(glyph, ref bounds);
                var midPointY = (-bounds.Top - (-bounds.Bottom)) / 2;
                var y = -bounds.Top + (size / 2 - midPointY);

                return textPaint.GetTextPath(glyph, 0, y);
            }
        }
    }
}
