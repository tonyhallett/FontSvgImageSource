using System.Collections.Generic;

namespace FontSvgImageSource
{
    public abstract class AssetsFontProvider : IFontProvider
    {
        protected abstract string FileName { get; }
        protected abstract string FontName { get; }
        public string FontFamily => $"Assets/Fonts/{FileName}#{FontName}";
        public abstract IEnumerable<string> Glyphs { get; }

        protected string GetGlyph(string codePoint)
        {
            int p = int.Parse(codePoint, System.Globalization.NumberStyles.HexNumber);
            return char.ConvertFromUtf32(p);
        }
    }


}
