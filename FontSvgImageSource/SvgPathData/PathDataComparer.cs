namespace FontSvgImageSource
{
    public static class PathDataComparer
    {
        public static void Compare()
        {
            var glyph = GoogleFontIcons.MaterialIconsOutlined.AccessAlarm;
            var size = 24;
            var skia = SkiaSvgPathProvider.GetPathData("MaterialIconsOutlined-Regular.otf", glyph, size);

            var fontFamily = new MaterialOutlineFontProvider().FontFamily;
            var winUI = new WinUIFontSvgPathDataProvider().Provide(fontFamily, glyph,size);
        }
    }
}
