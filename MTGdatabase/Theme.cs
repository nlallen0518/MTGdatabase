using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MagicCardDatabase
{
    public class Theme
    {
        public string Name { get; set; }
        public SolidColorBrush Background { get; set; }
        public SolidColorBrush Foreground { get; set; }

        // Add a Brush for text input backgrounds for better dark mode contrast.
        public SolidColorBrush TextInputBackground { get; set; }
    }

}
