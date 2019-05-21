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
using RFStorage.Handler;
using RFStorage.View.NavigationsSystem;
using RFStorage.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RFStorage.View.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginV : Page
    {
        private LogInVM LoginVM { get; }

        public LoginV()
        {
            this.InitializeComponent();
            LoginVM = new LogInVM();
        }

        

        private void SetSelectedBrugerCommand(object sender, RoutedEventArgs e)
        {
            LoginVM.SetSelectedBruger();
            LoginVM.LoginCheckCommand();
        }

        private void ClearInputs(object sender, RoutedEventArgs e)
        {
            Username_Input.Text = "";
            Password_Input.Password = "";
        }
    }
}
