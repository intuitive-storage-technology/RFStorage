using System;
using System.Collections.Generic;
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
    class LagerstatusVM : INotifyPropertyChanged
    {

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Instance field

        private ICommand _createVareCommand;
        private ICommand _selectedVareCommand;
        private ICommand _deleteVareCommand;

        #endregion

        #region Prop
        public string VareNavn { get; set; }
        public int VareID { get; set; }
        public string VareType { get; set; }
        public int VareAntal { get; set; }
        //public string VareTilstand { get; set; }

        public LagerstatusSingleton LagerstatusSingleton { get; set; }
        public Handler.VareHandler VareHandler { get; set; }
        public static Vare SelectedVare { get; set; }

        #endregion

        #region Constructor


        public LagerstatusVM()
        {
            VareHandler = new Handler.VareHandler(this);
            LagerstatusSingleton = LagerstatusSingleton.Instance;

        }

        #endregion

        #region Test

        public void Test()
        {
            LagerstatusSingleton.test();
        }

        public void Test2()
        {
            LagerstatusSingleton.test();
        }

        #endregion

        #region Icommand

        public ICommand CreateVareCommand
        {
            get
            {
                if (_createVareCommand == null)
                    _createVareCommand = new RelayCommands.RelayCommands(VareHandler.CreateVare);
                return _createVareCommand;
            }
            set { _createVareCommand = value; }
        }

        public ICommand SelectedVareCommand
        {
            get
            {
                return _selectedVareCommand ?? (_selectedVareCommand =
                           new RelayArgsCommands<Vare>(Vare => VareHandler.SetSelectedVare(Vare)));
            }
            set { _selectedVareCommand = value; }
        }

        public ICommand DeleteVareCommand
        {
            get { return _deleteVareCommand ?? (_deleteVareCommand = new RelayCommands.RelayCommands(VareHandler.DeleteVare)); }
            set { _deleteVareCommand = value; }
        }

        #endregion


    }
}
