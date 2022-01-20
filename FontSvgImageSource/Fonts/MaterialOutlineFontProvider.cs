using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FontSvgImageSource
{
    public class MaterialOutlineFontProvider : AssetsFontProvider
    {
        private readonly int startingGlyphIndex;
        protected override string FileName => "MaterialIconsOutlined-Regular.otf";

        protected override string FontName => "Material Icons Outlined";

        public MaterialOutlineFontProvider(int startingGlyphIndex = 0)
        {
            this.startingGlyphIndex = startingGlyphIndex;
        }

        public override IEnumerable<string> Glyphs
        {
            get
            {
                FieldInfo[] glyphFields = typeof(GoogleFontIcons.MaterialIconsOutlined).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                var glyphs = glyphFields.Select(p => p.GetValue(null) as string);
                return glyphs.Skip(startingGlyphIndex - 1);
            }
        }

       
    }

}
