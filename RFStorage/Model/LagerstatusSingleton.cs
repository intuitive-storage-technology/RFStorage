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
    class LagerstatusSingleton : INotifyPropertyChanged
    {
        #region PropertyChanged
        /// <summary>
        /// Den sørger for at sende opdateringer til VM/View når en property bliver opdateret med en værdi.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        #region Instance Field
        
        private static LagerstatusSingleton _instance = null;

        public ObservableCollection<Vare> VareOC { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        private LagerstatusSingleton()
        {
            VareOC = new ObservableCollection<Vare>();
        }
        #endregion




        #region Properties
        /// <summary>
        /// VareOC er en observableCollection af vare, som bliver hentet/sættet for LagerstatusSingleton.
        /// Instance sørger for at der kun kan være et aktuelt objekt af LagerstatusSingleton.
        /// </summary>


        public static LagerstatusSingleton Instance
        {
            get
            {
                if (_instance == null) _instance = new LagerstatusSingleton();
                return _instance;
            }
        }
        #endregion


        #region TestMethod
        /// <summary>
        /// Creates Vare objekter og ligger dem i VareOC
        /// </summary>
        public void test()
        {
            Vare vare1 = new Vare("navnTest1", 1, "Type1", 5, "vareTilstand");
            Vare vare2 = new Vare("navnTest1", 1, "Type1", 5, "vareTilstand");
            Vare vare3 = new Vare("navnTest1", 1, "Type1", 5, "vareTilstand");
            Vare vare4 = new Vare("navnTest1", 1, "Type1", 5, "vareTilstand");
            Vare vare5 = new Vare("navnTest1", 1, "Type1", 5, "vareTilstand");
            VareOC.Add(vare1);
            VareOC.Add(vare2);
            VareOC.Add(vare3);
            VareOC.Add(vare4);
            VareOC.Add(vare5);
        }
        #endregion

        //Remove and save to Persistancy
        public void Remove(Vare vareToBeRomoved)
        {
            VareOC.Remove(vareToBeRomoved);
            Persistency.PersistencyServices.SaveVaresAsJsonAsync(VareOC);
        }
    }
}
