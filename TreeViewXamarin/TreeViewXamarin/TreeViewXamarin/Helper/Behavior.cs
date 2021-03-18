using Syncfusion.TreeView.Engine;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class ContextManuBehavior : Behavior<ContentPage>
    {
        #region Fields

        SfTreeViewExt TreeView;
        SfPopupLayout popupLayout;
        KeyDetector KeyDetectorGrid;
        TreeViewNode Node;
        FileManagerViewModel ViewModel;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            TreeView = bindable.FindByName<SfTreeViewExt>("treeView");
            KeyDetectorGrid = bindable.FindByName<KeyDetector>("keyDetectorGrid");
            ViewModel = bindable.BindingContext as FileManagerViewModel;

            InitializePopupLayout();

            if (Device.RuntimePlatform == Device.UWP)
            {
                TreeView.ItemRightTapped += TreeView_ItemRightTapped;
                KeyDetectorGrid.KeyPressed += KeyDetectorGrid_KeyPressed;
            }
            else
            {
                TreeView.ItemHolding += TreeView_ItemHolding;
            }

            TreeView.ItemTapped += TreeView_ItemTapped;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                TreeView.ItemRightTapped -= TreeView_ItemRightTapped;
                KeyDetectorGrid.KeyPressed -= KeyDetectorGrid_KeyPressed;
            }
            else
            {
                TreeView.ItemHolding -= TreeView_ItemHolding;
            }
            TreeView.ItemTapped -= TreeView_ItemTapped;
            TreeView = null;
            popupLayout = null;
            KeyDetectorGrid = null;
            ViewModel = null;
            Node = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Private methods
        private void InitializePopupLayout()
        {
            popupLayout = new SfPopupLayout();
            popupLayout.PopupView.HeightRequest = 70;
            popupLayout.PopupView.WidthRequest = 100;
            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                var mainStack = new StackLayout() { BackgroundColor = Color.FromHex("#a6a9b6"), Spacing = 1 };

                var deletedButton = new Button()
                {
                    Text = "Delete",
                    HeightRequest = 35,
                    BackgroundColor = Color.FromHex("#e8e8e8")
                };
                deletedButton.Clicked += DeletedButton_Clicked;
                var editButton = new Button()
                {
                    Text = "Edit",
                    HeightRequest = 35,
                    BackgroundColor = Color.FromHex("#e8e8e8")
                };
                editButton.Clicked += EditButton_Clicked;
                mainStack.Children.Add(deletedButton);
                mainStack.Children.Add(editButton);
                return mainStack;
            });
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.ShowFooter = false;
        }

        private void ShowEditor(FileManager item)
        {
            var textEditPopup = new SfPopupLayout() { IsOpen = true };
            textEditPopup.PopupView.AutoSizeMode = AutoSizeMode.Height;
            textEditPopup.PopupView.ShowHeader = false;
            textEditPopup.PopupView.ShowFooter = false;
            var editor = new Editor() { Text = item.ItemName };
            textEditPopup.PopupView.ContentTemplate = new DataTemplate(() => { return editor; });
            editor.Completed += (sender, args) =>
            {
                item.ItemName = editor.Text;
                textEditPopup.Dismiss();
            };
        }

        private void ShowPopup(Point position)
        {
            if (position.Y + 100 <= TreeView.Height && position.X + 100 > TreeView.Width)
                popupLayout.Show((double)(position.X - 100), (double)(position.Y));
            else if (position.Y + 100 > TreeView.Height && position.X + 100 < TreeView.Width)
                popupLayout.Show((double)position.X, (double)(position.Y - 100));
            else if (position.Y + 100 > TreeView.Height && position.X + 100 > TreeView.Width)
                popupLayout.Show((double)(position.X - 100), (double)(position.Y - 100));
            else
                popupLayout.Show((double)position.X, (double)(position.Y));
        }
        #endregion

        #region Call backs

        private void TreeView_ItemTapped(object sender, Syncfusion.XForms.TreeView.ItemTappedEventArgs e)
        {
            popupLayout.Dismiss();
        }

        private void TreeView_ItemHolding(object sender, Syncfusion.XForms.TreeView.ItemHoldingEventArgs e)
        {
            if (popupLayout.IsOpen) popupLayout.Dismiss();

            Node = e.Node;
            ShowPopup(e.Position);
        }

        private void TreeView_ItemRightTapped(object sender, ItemRightTappedEventArgs e)
        {
            if (popupLayout.IsOpen) popupLayout.Dismiss();

            Node = e.ItemData as TreeViewNode;
            ShowPopup(e.Position);
        }

        private void KeyDetectorGrid_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == "Escape" || e.Key == "Dismiss")
            {
                popupLayout.Dismiss();
            }
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            popupLayout.Dismiss();
            var item = Node.Content as FileManager;
            ShowEditor(item);
        }

        private void DeletedButton_Clicked(object sender, EventArgs e)
        {
            var item = Node.Content as FileManager;

            if (Node.ParentNode != null)
            {
                var parentNode = Node.ParentNode.Content as FileManager;
                parentNode.SubFiles.Remove(item);
            }
            else
                ViewModel.ImageNodeInfo.Remove(item);

            popupLayout.Dismiss();
        }

        #endregion
    }
}
