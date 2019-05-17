using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Xaml.Interactions.Core;
using RFStorage.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RFStorage.View.LagerOgItem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditItemV : Page
    {
        private bool EditUse;

        public EditItemV()
        {
            this.InitializeComponent();
        }


        private void ListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }
        

        private void EditClick(object sender, RoutedEventArgs e)
        {
            CreateItemGrid.Visibility = Visibility.Visible;

            Edit.Visibility = Visibility.Collapsed;

            Update.Visibility = Visibility.Visible;
        }


        private void Update_Click_1(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(this.GetType());
            CreateItemGrid.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Visible;
            this.Frame.Navigate(this.GetType());
        }


        
    }
}
