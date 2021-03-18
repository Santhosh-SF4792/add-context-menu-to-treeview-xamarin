using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    #region CustomGrid
    public class CustomGrid : Grid
    {
        public static readonly BindableProperty TreeViewProperty = BindableProperty.Create(
            "TreeView",
            typeof(SfTreeViewExt),
            typeof(CustomGrid),
            null,
            BindingMode.Default,
            null, OnTreeViewPropertyChanged);

        private static void OnTreeViewPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {

        }

        public SfTreeViewExt TreeView
        {
            get
            {
                return (SfTreeViewExt)GetValue(TreeViewProperty);
            }

            set
            {
                SetValue(TreeViewProperty, value);
            }
        }

        public CustomGrid() { }
    }
    #endregion

    #region KeyDetectorGrid
    public class KeyDetector : Grid
    {
        public event KeyPressedEventHandler KeyPressed;

        public void RaiseKeyPressed(KeyEventArgs e)
        {
            if (KeyPressed != null)
                this.KeyPressed(this, e);
        }
    }
    #endregion
}
