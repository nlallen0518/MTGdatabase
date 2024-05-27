using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MagicCardDatabase
{
    public class ThemeManager
    {
        public List<Theme> Themes { get; private set; } = new List<Theme>();
        public Theme CurrentTheme { get; set; }

        public ThemeManager()
        {
            // Initialize with default themes
            Themes.Add(new Theme { Name = "Light", Background = new SolidColorBrush(Colors.White), Foreground = new SolidColorBrush(Colors.Black) });
            Themes.Add(new Theme { Name = "Dark", Background = new SolidColorBrush(Color.FromRgb(0x22, 0x22, 0x22)), Foreground = new SolidColorBrush(Colors.White) });

            // Set initial theme
            CurrentTheme = Themes[0];
        }

        public void ApplyTheme(Theme theme, ResourceDictionary resources)
        {
            CurrentTheme = theme;
            resources["LightModeBackground"] = theme.Background;
            resources["LightModeForeground"] = theme.Foreground;
        }

       
    }

}
