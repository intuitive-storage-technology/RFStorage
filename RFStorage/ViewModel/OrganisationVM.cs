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
using RFStorage.Annotations;
using RFStorage.Handler;
using RFStorage.Model;
using RFStorage.RelayCommands;

namespace RFStorage.ViewModel
{
    class OrganisationVM : INotifyPropertyChanged
    {
        private ICommand _selectOrganisationCommand;
        public OrganisationsSingleton OrganisationsSingleton { get; set; }
        public static ObservableCollection<Vare> SortOC { get; set; }
        public static Organisation SelectedOrganisation { get; set; }
        public Handler.OrganHandler OrganHandler { get; set; }
        
      

        public OrganisationVM()
        {
            OrganisationsSingleton = OrganisationsSingleton.Instance;
            OrganisationsSingleton.TestOrgan();
            OrganHandler = new Handler.OrganHandler(this);
            SortOC = new ObservableCollection<Vare>();
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

        public static void ListeSortering()
        {
            SortOC.Clear();
            foreach (var e in SelectedOrganisation.UdleveretVareOC)
            {
                SortOC.Add(e);
            }
        }
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
