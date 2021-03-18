using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewXamarin;
using TreeViewXamarin.UWP;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(KeyDetector), typeof(KeyDetectorRenderer))]
namespace TreeViewXamarin.UWP
{
    public class KeyDetectorRenderer : VisualElementRenderer<KeyDetector, FrameworkElement>
    {
        private KeyEventArgs KeyEventArgs;

        public KeyDetectorRenderer()
        {
            KeyEventArgs = new KeyEventArgs();
            this.KeyDown += KeyDetectorRenderer_KeyDown;
            this.Tapped += KeyDetectorRenderer_Tapped;
        }

        private void KeyDetectorRenderer_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var grid = this.Element as KeyDetector;

            if (grid != null)
            {
                //To dismiss the popup menu, when tapping the other elements in the UI.
                KeyEventArgs.Key = "Dismiss";
                grid.RaiseKeyPressed(KeyEventArgs);
            }
        }

        private void KeyDetectorRenderer_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            var grid = this.Element as KeyDetector;

            if(grid != null)
            {
                //To dismiss the popup menu, when escape key is pressed.
                KeyEventArgs.Key = e.Key.ToString();
                grid.RaiseKeyPressed(KeyEventArgs);
            }
        }
    }
}
