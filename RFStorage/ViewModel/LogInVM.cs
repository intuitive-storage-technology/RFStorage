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

        /// <summary>
        /// PasswordInput and BrugerInput has OnPropertyChanged() implemented to set the value correctly
        /// </summary>
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
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        public LogInVM()
        {
            BrugerSingleton = BrugerSingleton.Instance;
        }

        #endregion

        #region Methods
        /// <summary>
        /// SetSelectedBruger() goes through the List of users in the DB and finds the user and selects them from the username input.
        /// </summary>
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

        /// <summary>
        /// LoginCheckCommand() checks if user's input password matches the password the user has in DB. And navigates the user to the right menu depending on their access level.
        /// If the username or the password is not correct it creates a message box to notify the user and keeps them on the login page.
        /// </summary>
        public async void LoginCheckCommand()
        {
            try
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
            }

            catch (Exception)
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
