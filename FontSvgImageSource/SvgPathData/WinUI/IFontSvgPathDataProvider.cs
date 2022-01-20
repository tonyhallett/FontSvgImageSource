namespace FontSvgImageSource
{
    public interface IFontSvgPathDataProvider
    {
        string Provide(string fontFamily, string glyph, float fontSize);
    }
}