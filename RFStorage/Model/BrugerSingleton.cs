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


        #region Instance Field
        private static BrugerSingleton _instance = null;
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

        #region Constuctor

        private BrugerSingleton()
        {
            BrugerOC = new ObservableCollection<Bruger>();
            BrugerOC.Add(new Bruger("Emil7213", "Emil Mosbaek", "passwordemil", true));
            BrugerOC.Add(new Bruger("Jonx2905", "Jon Lam", "passwordjon", true));
            BrugerOC.Add(new Bruger("Fili3801", "Filip Hansen", "passwordfilip", true));
            BrugerOC.Add(new Bruger("celi4162", "Celine Stenberg", "passwordceline", true));
            BrugerOC.Add(new Bruger("Test7213", "Random Pleb", "passwordtest", false));
        }
        #endregion

        #region Methods

        public void BrugereTest()
        {
            BrugerOC.Add(new Bruger("celi4162", "Celine Stenberg", "passwordceline", true));
            BrugerOC.Add(new Bruger("Emil7213", "Emil Mosbaek", "passwordemil", true));
            BrugerOC.Add(new Bruger("Fili3801", "Filip Hansen", "passwordfilip", true));
            BrugerOC.Add(new Bruger("Jonx2905", "Jon Lam", "passwordjon", false));
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
