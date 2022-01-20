using System.Collections.Generic;
using System.Linq;

namespace FontSvgImageSource
{
    public class MaterialDesignIconsFontProvider : AssetsFontProvider
    {
        public override IEnumerable<string> Glyphs => new string[]
        {
             "f0002",
             "f0018",
              "f625"
        }.Select(cp => GetGlyph(cp));

        protected override string FileName => "materialdesignicons-webfont.ttf";

        protected override string FontName => "Material Design Icons";
    }


}
