using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RFStorage.Annotations;
using RFStorage.Handler;
using RFStorage.Model;
using RFStorage.RelayCommands;

namespace RFStorage.ViewModel
{
    public class CreateRemoveBrugerVM : INotifyPropertyChanged
    {
        #region Instance Field

        private ICommand _selectedBrugerCommand;
        private ICommand _createBrugerCommand;
        private ICommand _deleteBrugerCommand;

        #endregion

        #region Properties

        public BrugerSingleton BrugerSingleton { get; set; }
        public Handler.BrugerHandler BrugerHandler { get; set; }
        public static Bruger SelectedBruger { get; set; }

        public string BrugerID { get; set; }
        public string Brugernavn { get; set; }
        public string BrugerPassword { get; set; }
        public bool BrugerType { get; set; }

        #region ICommand

        public ICommand CreateBrugerCommand
        {
            get
            {
                if (_createBrugerCommand == null)
                    _createBrugerCommand = new RelayCommands.RelayCommands(BrugerHandler.CreateBruger);
                return _createBrugerCommand;
            }
            set { _createBrugerCommand = value; }
        }

        public ICommand DeleteBrugerCommand
        {
            get
            {
                return _deleteBrugerCommand ??
                       (_deleteBrugerCommand = new RelayCommands.RelayCommands(BrugerHandler.DeleteBruger));
            }
            set { _deleteBrugerCommand = value; }
        }

        public ICommand SelectedBrugerCommand
        {
            get
            {
                return _selectedBrugerCommand ?? (SelectedBrugerCommand =
                           new RelayArgsCommands<Bruger>(bruger => BrugerHandler.SetSelectedBruger(bruger)));
            }
            set { _selectedBrugerCommand = value; }
        }

        #endregion

        #endregion

        #region Constructor

        public CreateRemoveBrugerVM()
        {
            BrugerSingleton = BrugerSingleton.Instance;
            BrugerHandler = new Handler.BrugerHandler(this);
            BrugerSingleton.BrugereTest();
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

