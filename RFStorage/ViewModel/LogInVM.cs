using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RFStorage.Annotations;
using RFStorage.Model;

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

        #region Properties

        public BrugerSingleton BrugerSingleton { get; set; }
        public static Bruger SelectedBruger { get; set; }

        public string BrugerID { get; set; }
        public string Brugernavn { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }

        #endregion

        public static int CheckLogin()
        {

        }

    }
}
