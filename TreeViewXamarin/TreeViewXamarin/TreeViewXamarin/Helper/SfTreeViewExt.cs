using Syncfusion.XForms.TreeView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class SfTreeViewExt : SfTreeView
    {
        public event ItemRightTappedEventHandler ItemRightTapped;
        
        public void RaiseItemRightTapped(ItemRightTappedEventArgs e)
        {
            if (ItemRightTapped != null)
                this.ItemRightTapped(this, e);
        }
    }
}
