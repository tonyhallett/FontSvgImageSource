using System.Collections.Generic;

namespace FontSvgImageSource
{
    public interface IFontProvider
    {
        string FontFamily { get; }
        IEnumerable<string> Glyphs { get; }
    }
}
