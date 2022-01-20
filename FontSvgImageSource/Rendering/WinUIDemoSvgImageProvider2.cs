namespace FontSvgImageSource
{
    public class WinUIDemoSvgImageProvider2 : SvgImageProvider
    {
        public WinUIDemoSvgImageProvider2() : base(new WinUIFontSvgPathDataProvider())
        { }

        protected override float GetPathDataFontSize(float fontSize)
        {
            var displayInfo = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
            var rawPixelsPerViewPixel = displayInfo.RawPixelsPerViewPixel;
            return fontSize * (float)rawPixelsPerViewPixel;
        }

    }

}
