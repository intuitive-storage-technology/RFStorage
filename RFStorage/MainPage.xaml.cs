using System;
using System.Collections.Generic;
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
using Microsoft.Xaml.Interactions.Core;
using RFStorage.View.LagerOgItem;
using RFStorage.View.Login;
using RFStorage.View.Organisation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RFStorage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Frame1.Navigate(typeof(LagerstatusV));
        }      

        private void ToLagerstatus(object sender, TappedRoutedEventArgs e)
        {
            Frame1.Navigate(typeof(LagerstatusV));
            MenuBar.Header = "Lagerstatus";
        }

        private void ToUdlevering(object sender, TappedRoutedEventArgs e)
        {
            Frame1.Navigate(typeof(OrganisationSøgUdlevering));
            MenuBar.Header = "Udlevering";
        }

        private void ToIndlevering(object sender, TappedRoutedEventArgs e)
        {
            Frame1.Navigate(typeof(OrganisationListeIndleveringV));
            MenuBar.Header = "Tilbagelevering";
        }

        private void ToCreateVare(object sender, TappedRoutedEventArgs e)
        {
            Frame1.Navigate(typeof(CreateItemV));
            MenuBar.Header = "Opret vare";
        }

        private void ToEditVare(object sender, TappedRoutedEventArgs e)
        {
            Frame1.Navigate(typeof(EditItemV));
            MenuBar.Header = "Redigér vare";
        }

        private void ToCreateRemoveBruger(object sender, TappedRoutedEventArgs e)
        {
            Frame1.Navigate(typeof(CreateRemoveBrugerV));
            MenuBar.Header = "Opret bruger";
        }

        private void ToLogin(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginV));
        }
    }
}
