using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FontSvgImageSource
{
    public sealed partial class MainPage : Page
    {
        private readonly StackPanel iconPanel;
        private readonly ISvgImageProvider svgImageProvider;
        private readonly string fontFamily;

        private readonly float fontSize = 96; // change as required
        private Color iconColor = Colors.White.Alpha(255); // change as required

        public MainPage()
        {
            this.InitializeComponent();

            PathDataComparer.Compare();

            // correct size icon and button but blurry
            //svgImageProvider = new WinUIDemoSvgImageProvider();

            // correct size icon, not blurry but button size is incorrect
            svgImageProvider = new WinUIDemoSvgImageProvider2();

            IFontProvider fontProvider = new MaterialOutlineFontProvider(55); // change as required
            var cyclingGlyphs = new CyclingList<string>(fontProvider.Glyphs);
            fontFamily = fontProvider.FontFamily;

            string glyph = cyclingGlyphs.Next();

            var mainStackPanel = new StackPanel { Spacing = 10 };
            var nextGlyphButton = new Button { Content = "Next glyph" };
            mainStackPanel.Children.Add(nextGlyphButton);
            iconPanel = new StackPanel { Spacing = 10 };
            mainStackPanel.Children.Add(iconPanel);
            this.Content = mainStackPanel;

            nextGlyphButton.Click += (s, e) =>
            {
                AddIcons(cyclingGlyphs.Next());
            };

            AddIcons(glyph);
            
        }

        private void AddIcons(string glyph,bool inButton = true)
        {
            iconPanel.Children.Clear();
            var (canvasImage, textBlock) = GetComparisonIcons(fontFamily, fontSize, glyph, iconColor);
            var svgImage = svgImageProvider.Provide(fontFamily, fontSize, glyph, iconColor);

            canvasImage.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            svgImage.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Left);

            new List<UIElement> { canvasImage, textBlock, svgImage }.ForEach(icon =>
            {
                AddIcon(inButton ? new Button { Content = icon } : icon );
            });
        }

        private void AddIcon(UIElement icon)
        {
            iconPanel.Children.Add(icon);
        }

        private (Image canvasImage, TextBlock textBlock) GetComparisonIcons(string fontFamily, float fontSize, string glyph, Color iconColor)
        {
            var canvasImage = ButtonRendererFontImage.Get(fontFamily, fontSize, glyph, iconColor);
            var textBlock = new TextBlock { FontSize = fontSize, Foreground = new SolidColorBrush(iconColor), FontFamily = new FontFamily(fontFamily), Text = glyph };
            return (canvasImage, textBlock);
        }

    }
}
