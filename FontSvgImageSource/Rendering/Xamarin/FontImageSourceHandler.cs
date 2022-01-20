using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;

namespace FontSvgImageSource
{
    public static class FontImageSourceHandler
    {
        static readonly float _minimumDpi = 300;
        public static CanvasImageSource CanvasImageSource(string fontFamily, float fontSize, string glyph, Windows.UI.Color iconColor)
        {
            var device = CanvasDevice.GetSharedDevice();
            var dpi = Math.Max(_minimumDpi, Windows.Graphics.Display.DisplayInformation.GetForCurrentView().LogicalDpi);

            var textFormat = new CanvasTextFormat
            {
                FontFamily = fontFamily,
                FontSize = fontSize,
                HorizontalAlignment = CanvasHorizontalAlignment.Left,
                VerticalAlignment = CanvasVerticalAlignment.Center,
                Options = CanvasDrawTextOptions.Default
            };

            using (var layout = new CanvasTextLayout(device, glyph, textFormat, fontSize, fontSize))
            {
                var canvasWidth = (float)layout.LayoutBounds.Width + 2;
                var canvasHeight = (float)layout.LayoutBounds.Height + 2;

                var imageSource = new CanvasImageSource(device, canvasWidth, canvasHeight, dpi);
                using (var ds = imageSource.CreateDrawingSession(Windows.UI.Colors.Transparent))
                {
                    // offset by 1 as we added a 1 inset
                    ds.DrawTextLayout(layout, 1f, 1f, iconColor);
                }

                return imageSource;
            }
        }
    }
}
