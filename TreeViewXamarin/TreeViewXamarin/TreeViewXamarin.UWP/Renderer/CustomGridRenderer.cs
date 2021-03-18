using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewXamarin;
using TreeViewXamarin.UWP;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomGrid), typeof(CustomGridRenderer))]
namespace TreeViewXamarin.UWP
{
    public class CustomGridRenderer : VisualElementRenderer<CustomGrid, FrameworkElement>
    {
        public CustomGridRenderer()
        {
            this.RightTapped += CustomGridRenderer_RightTapped;
        }

        private void CustomGridRenderer_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            var treeViewNode = this.DataContext as TreeViewNode;
            var grid = this.Element as CustomGrid;
            if (treeViewNode != null)
            {
                var location = this.TransformToVisual(null).TransformPoint(e.GetPosition(this));
                var tappedEventArgs = new ItemRightTappedEventArgs(this.DataContext, new Xamarin.Forms.Point(location.X, location.Y));

                grid.TreeView.RaiseItemRightTapped(tappedEventArgs);
            }
        }
    }
}
