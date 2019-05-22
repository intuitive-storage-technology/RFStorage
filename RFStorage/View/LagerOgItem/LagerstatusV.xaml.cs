using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RFStorage.Converter;
using RFStorage.RelayCommands;
using RFStorage.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RFStorage.View.LagerOgItem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LagerstatusV : Page
    {
        public LagerstatusV()
        {
            this.InitializeComponent();
        }

        private void SuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var filtered1 = Model.LagerstatusSingleton.Instance.VareOC.Where(i =>
                    i.VareNavn.CaseInsensitiveContains(this.SuggestBox2.Text));
                LagerstatuslistView.ItemsSource = filtered1;
            }

        }

    }
}
