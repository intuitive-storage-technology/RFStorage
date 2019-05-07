using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RFStorage.Annotations;

namespace RFStorage.Model
{
    class BrugerSingleton : INotifyPropertyChanged
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
        private static BrugerSingleton _instance = null;
        #endregion

        #region Constuctor
        
        private BrugerSingleton()
        {
            BrugerOC = new ObservableCollection<Bruger>();
        }
        #endregion

        #region Properties

        public static BrugerSingleton Instance
        {
            get
            {
                if (_instance == null) _instance = new BrugerSingleton();
                return _instance;
            }
        }

        public ObservableCollection<Bruger> BrugerOC { get; set; }

        #endregion

    }
}
