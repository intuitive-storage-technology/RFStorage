using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using RFStorage.Annotations;
using RFStorage.Handler;
using RFStorage.Model;
using RFStorage.RelayCommands;

namespace RFStorage.ViewModel
{
    class OrganisationVM : INotifyPropertyChanged
    {
        #region Properties
        #region Instance Field
        private ICommand _selectOrganisationCommand;
        private ICommand _selectedVareCommand;
        #endregion
        #region OC-Props
        public static ObservableCollection<Vare> SortOC { get; set; }
        public static Organisation SelectedOrganisation { get; set; }
        public static ObservableCollection<Vare> UdleveringsOC { get; set; }
        public static ObservableCollection<Vare> TilbageLeveringsOC { get; set; }
        #endregion
        #region Singleton og Handler props
        public OrganisationsSingleton OrganisationsSingleton { get; set; }
        public Handler.VareHandler VareHandler { get; set; }
        public static Vare SelectedVare { get; set; }
        public Handler.OrganHandler OrganHandler { get; set; }
        #endregion
        #region Vare props
        public string VareNavn { get; set; }
        public int VareID { get; set; }
        public string VareType { get; set; }
        public int VareAntal { get; set; }
        #endregion
        #region ICommand props
        public ICommand SelectedVareCommand
        {
            get
            {
                return _selectedVareCommand ?? (_selectedVareCommand =
                           new RelayArgsCommands<Vare>(Vare => VareHandler.SetSelectedVare(Vare)));
            }
            set { _selectedVareCommand = value; }
        }
        public ICommand SelectOrganisationCommand
        {
            get
            {
                return _selectOrganisationCommand ?? (_selectOrganisationCommand =
                           new RelayArgsCommands<Organisation>(organ => OrganHandler.SetSelectedOrganisation(organ)));
            }
            set => _selectOrganisationCommand = value;
        }
        #endregion
        #endregion




        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public OrganisationVM()
        {
            OrganisationsSingleton = OrganisationsSingleton.Instance;
            OrganisationsSingleton.TestOrgan();
            OrganHandler = new Handler.OrganHandler(this);
            VareHandler = new Handler.VareHandler(this);
            SortOC = new ObservableCollection<Vare>();
            UdleveringsOC = new ObservableCollection<Vare>();
            TilbageLeveringsOC = new ObservableCollection<Vare>();
        }
        #endregion
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public static void ListeSortering()
        {
            SortOC.Clear();
            if (SelectedOrganisation != null)
            {
                foreach (var e in SelectedOrganisation.UdleveretVareOC)
                {
                    SortOC.Add(e);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public async void UdleveringsSortering()
        {
            if (SelectedVare != null)
            {
                
                UdleveringsOC.Add(new Vare(SelectedVare.VareNavn,SelectedVare.VareID,SelectedVare.VareType,SelectedVare.VareAntal));
                var messageDialog = new MessageDialog("Varen er tilføjet til udlevering");
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("Ingen vare valgt - husk at klikke på varen");
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        public async void TilbageleveringsSortering()
        {
            if (SelectedVare != null)
            {
                TilbageLeveringsOC.Add(new Vare(SelectedVare.VareNavn,SelectedVare.VareID,SelectedVare.VareType,SelectedVare.VareAntal));
                var messagedialog = new MessageDialog("Varen er føjet til tilbagelevering");
                messagedialog.CancelCommandIndex = 1;
                await messagedialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("Ingen vare valgt - husk at klikke på varen");
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
            }
        }
        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
