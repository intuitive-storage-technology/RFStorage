using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RFStorage.Annotations;
using RFStorage.Model;

namespace RFStorage.ViewModel
{
    class CreateRemoveBrugerVM : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

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
        public string Password { get; set; }
        public bool BrugerType { get; set; }
        //Brugernavn?

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

        /*public ICommand CreateVareCommand
        {
            get
            {
                if (_createVareCommand == null)
                    _createVareCommand = new RelayCommands.RelayCommands(EventHandler.CreateVare);
                return _createVareCommand;
            }
            set { _createVareCommand = value; }
        }

        public ICommand SelectedVareCommand
        {
            get
            {
                return _selectedVareCommand ?? (_selectedVareCommand =
                           new RelayArgsCommands<Vare>(vare => EventHandler.SetSelectedVare(vare)));
            }
            set { _selectedVareCommand = value; }
        }

        public ICommand DeleteVareCommand
        {
            get { return _deleteVareCommand ?? (_deleteVareCommand = new RelayCommands.RelayCommands(EventHandler.DeleteVare)); }
            set { _deleteVareCommand = value; }*/
        }

        #endregion
        #endregion

    }

