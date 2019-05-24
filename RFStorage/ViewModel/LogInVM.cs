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
    /// <summary>
    /// Bruges til at styre login sekvensen og vise hvilken bruger der er logget ind i programmet. 
    /// </summary>
    /// <remarks> Bruges til at styre login sekvensen og vise hvilken bruger der er logget ind i programmet.</remarks>
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
        /// SetSelectedBruger() går igennem listen af brugere og prøver at matche det indtastede brugerID med brugerID i DB, og sætter dem til SelectedBruger hvis brugerID findes.
        /// </summary>
        /// <remarks> Exception: Ingen.</remarks>
        /// <remarks> Preconditions: For at være successfuld skal metoden have et brugerID input</remarks>
        /// <remarks> Postconditions: Sætter brugeren til SelectedBruger og break loop.</remarks>
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
        /// LoginCheckCommand() checker om brugerens input password matcher passwordet som brugeren har i DB. Og navigatere brugeren til den rigtige menu alt efter deres adgangsniveau.
        /// Exception: Hvis brugernavn eller password ikke er rigtigt, så skaber metoden en Message dialog for at underrette brugeren om at indtastningen og beholder brugeren på login pagen.
        /// </summary>
        /// <remarks> Exceptions: Hvis brugernavn eller password ikke er rigtigt, så skaber metoden en Message dialog for at underrette brugeren om at indtastningen og beholder brugeren på login pagen.</remarks>
        /// <remarks> Preconditions: SelectedBruger er set og at SelectedBruger.Password findes i DB.</remarks>
        /// <remarks> Postconditions: Navigere brugen til den rigtige menu alt efter deres adgangsniveau for at begrænse/åbne muligheder for brugeren</remarks>
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

        /// <summary>
        /// Rydder input-felter for indtastet data.
        /// </summary>
        /// <remarks> Exceptions: Ingen.</remarks>
        /// <remarks> Preconditions: Ingen.</remarks>
        /// <remarks> Postconditions: Rydder inout-felter for indtastet data, hvis til stede.</remarks>
        public void LogOut()
        {
            _selectedBruger = null;
            _brugerIDInput = null;
            _passwordInput = null;
        }
        #endregion
    }
}
