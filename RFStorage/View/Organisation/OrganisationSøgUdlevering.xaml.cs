using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
using RFStorage.Converter;
using RFStorage.Model;
using RFStorage.ViewModel;
using static RFStorage.ViewModel.OrganisationVM;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RFStorage.View.Organisation 
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrganisationSøgUdlevering : Page
    {
        
        private OrganisationVM OrganisationVm { get; set; }
     

        public OrganisationSøgUdlevering()
        {
            this.InitializeComponent();
            OrganisationVm = new OrganisationVM();
          

        }

        private void SuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var filtered1 = Model.OrganisationsSingleton.Instance.OrganisationOC.Where(i =>
                    i.OrganisationNavn.CaseInsensitiveContains(this.SuggestBox.Text));
              
                OrganList.ItemsSource = filtered1;
            }
           
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OrganisationVM.ListeSortering();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           OrganisationVm.UdleveringsSortering();
        }


        private void ButtonBase_OnClickUdlever(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KvitteringV));
        }
    }
}
