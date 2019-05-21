using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RFStorage.Annotations;
using RFStorage.Handler;
using RFStorage.Model;
using RFStorage.RelayCommands;
using RFStorage.View.NavigationsSystem;

namespace RFStorage.ViewModel
{
    class LogInVM : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Instance Fields

        
        private static string _passwordInput;
        private static Bruger _selectedBruger;
        private static string _brugerIDInput;

        #endregion

        #region Properties

        public BrugerSingleton BrugerSingleton { get; set; }

        public static Bruger SelectedBruger
        {
            get => _selectedBruger;
            set => _selectedBruger = value;
        }

        

        public string BrugerID { get; set; }
        public string Brugernavn { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }

        public string PasswordInput
        {
            get { return _passwordInput; }
            set { _passwordInput = value; OnPropertyChanged(); }
        }

        public string BrugerIDInput
        {
            get { return _brugerIDInput; }

            set { _brugerIDInput = value; OnPropertyChanged(); }
        }
        
        #endregion

        #region Contructor

        public LogInVM()
        {
            BrugerSingleton = BrugerSingleton.Instance;
        }

        #endregion

        #region Methods
        public void SetSelectedBruger()
        {
            foreach (var Bruger in BrugerSingleton.BrugerOC)
            {
                if (Bruger.BrugerID == BrugerIDInput)
                {
                    SelectedBruger = Bruger;
                    break;
                }
            }
        }

        public async void LoginCheckCommand()
        {
            if (SelectedBruger.Password == PasswordInput)
            {
                if (SelectedBruger.Type == true)
                {
                    Frame loginFrame = Window.Current.Content as Frame;
                    if (loginFrame != null)
                    {
                        loginFrame.Navigate(typeof(MainPage));
                    }
                }

                else
                {
                    Frame loginFrame = Window.Current.Content as Frame;
                    if (loginFrame != null)
                    {
                        loginFrame.Navigate(typeof(FrivilligNavigationV));
                    }
                }
            }

            else
            {
                // Create the message dialog and set its content
                var messageDialog = new MessageDialog("Username and Password does not match.");

                // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                messageDialog.Commands.Add(new UICommand("Ok", null));

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Set the command to be invoked when escape is pressed
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();
            }
        }

        public void LogOut()
        {
            _selectedBruger = null;
            _brugerIDInput = null;
            _passwordInput = null;
        }
        #endregion
    }
}
