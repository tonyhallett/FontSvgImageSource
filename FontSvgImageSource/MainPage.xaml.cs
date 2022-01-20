using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

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
            svgImageProvider = new WinUIDemoSvgImageProvider();

            // correct size icon, not blurry but button size is incorrect
            // svgImageProvider = new WinUIDemoSvgImageProvider2();

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
            var comparisonIcons = GetComparisonIcons(fontFamily, fontSize, glyph, iconColor);
            var svgImage = svgImageProvider.Provide(fontFamily, fontSize, glyph, iconColor);

            comparisonIcons.Concat(new UIElement[] { svgImage }).ToList().ForEach(icon =>
            {
                icon.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                AddIcon(inButton ? new Button { Content = icon } : icon );
            });
        }

        private void AddIcon(UIElement icon)
        {
            iconPanel.Children.Add(icon);
        }

        private Brush IconBrush => new SolidColorBrush(iconColor);

        private IEnumerable<UIElement> GetComparisonIcons(string fontFamily, float fontSize, string glyph, Color iconColor)
        {
            var canvasImage = ButtonRendererFontImage.Get(fontFamily, fontSize, glyph, iconColor);
            var textBlock = new TextBlock { FontSize = fontSize, Foreground = IconBrush, FontFamily = new FontFamily(fontFamily), Text = glyph };
            var geometry1 = GetGeometry(fontFamily, fontSize, glyph);
            var geometry2 = GetGeometry(fontFamily, fontSize, glyph);
            var path = new Path { Data = geometry1, Fill = IconBrush };
            var pathIcon = new PathIcon { Data = geometry2, Foreground = IconBrush };
            return new UIElement[] { canvasImage, textBlock, path, pathIcon };
        }

        private Geometry GetGeometry(string fontFamily, float fontSize, string glyph){
            return GeometryConverter.Convert(svgImageProvider.ProvideSvgPathData(fontFamily, fontSize, glyph));
        }

    }
}
