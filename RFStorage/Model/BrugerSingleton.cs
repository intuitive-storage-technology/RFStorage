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
    public class BrugerSingleton : INotifyPropertyChanged
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
            
        }
        #endregion

        #region Methods

        public void Add(Bruger bruger)
        {
            Persistency.PersistencyServices<Bruger>.PostObject("api/Brugers", bruger);
            BrugerOC.Add(bruger);
        }

        public void Remove(Bruger bruger)
        {
            Persistency.PersistencyServices<Bruger>.DeleteObject("api/Brugers/", bruger.BrugerID);
            BrugerOC.Remove(bruger);
        }

        public async void GetBrugere()
        {
           BrugerOC.Clear();
           LoadEventAsync();
        }

        public async void LoadEventAsync()
        {
            var brugere = await Persistency.PersistencyServices<Bruger>.GetObject("api/Brugers/");
            if (brugere != null)
            {
                foreach (var e in brugere)
                {
                        BrugerOC.Add(e);
                }
            }
            else
            {
                BrugerOC.Add(new Bruger("TestTest", "FilipTest", "Kartoffel", true));
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
