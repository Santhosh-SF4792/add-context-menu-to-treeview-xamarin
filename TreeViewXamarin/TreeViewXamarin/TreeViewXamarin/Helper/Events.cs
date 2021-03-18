using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    #region EventHandler

    public delegate void ItemRightTappedEventHandler(object sender, ItemRightTappedEventArgs e);
    public delegate void KeyPressedEventHandler(object sender, KeyEventArgs e);

    #endregion

    #region EventArgs
    public class ItemRightTappedEventArgs : EventArgs
    {
        private object itemData = null;

        private Point position;

        public ItemRightTappedEventArgs(object itemData, Point position)
        {
            this.itemData = itemData;
            this.position = position;
        }

        public object ItemData
        {
            get { return itemData; }
        }

        public Point Position
        {
            get { return position; }
        }
    }

    public class KeyEventArgs : EventArgs
    {
        public string Key { get; set; }

        public KeyEventArgs()
        {

        }
    }
    #endregion
}
