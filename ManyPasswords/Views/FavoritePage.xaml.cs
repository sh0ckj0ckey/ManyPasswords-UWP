using ManyPasswords.Models;
using ManyPasswords.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ManyPasswords
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class FavoritePage : Page
    {
        public PasswordViewModel ViewModel = null;
        public static FavoritePage Current = null;
        public FavoritePage()
        {
            try
            {
                ViewModel = PasswordViewModel.Instance;
                this.InitializeComponent();
                Current = this;
            }
            catch { }
        }

        /// <summary>
        /// 点击取消收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button btn && btn.DataContext is PasswordItem password)
                {
                    ViewModel.RemoveFavorite(password, true);
                }
            }
            catch { }
        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                if (sender is Grid grid)
                {
                    var tb = grid.FindName("PasswordTextBlock");
                    if (tb is Button textBlock)
                    {
                        textBlock.Visibility = Visibility.Visible;
                    }

                    var tb2 = grid.FindName("HiddenPasswordTextBlock");
                    if (tb2 is TextBlock textBlock2)
                    {
                        textBlock2.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch { }
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                if (sender is Grid grid)
                {
                    var tb = grid.FindName("PasswordTextBlock");
                    if (tb is Button textBlock)
                    {
                        textBlock.Visibility = Visibility.Collapsed;
                    }

                    var tb2 = grid.FindName("HiddenPasswordTextBlock");
                    if (tb2 is TextBlock textBlock2)
                    {
                        textBlock2.Visibility = Visibility.Visible;
                    }
                }
            }
            catch { }
        }

        private void OnClickCopy(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button btn && btn.Tag != null)
                {
                    string text = btn.Tag.ToString();

                    Windows.ApplicationModel.DataTransfer.DataPackage dataPackage = new Windows.ApplicationModel.DataTransfer.DataPackage();
                    dataPackage.SetText(text);
                    Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
                }
            }
            catch { }
        }
    }
}
