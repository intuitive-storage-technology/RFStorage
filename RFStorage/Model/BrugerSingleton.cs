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
        /// <summary>
        /// sætter BrugerSingleton som ikke-instansieret som dens startværdi.
        /// </summary>
        private static BrugerSingleton _instance = null;
        #endregion
        
        #region Properties
        /// <summary>
        /// En property der skal sørge for, at observable collectionen for brugere kun bliver instansieret én gang.
        /// </summary>
        public static BrugerSingleton Instance
        {
            get
            {
                if (_instance == null) _instance = new BrugerSingleton();
                return _instance;
            }
        }

        /// <summary>
        /// "getter" eller "setter" observable collectionen af brugere.
        /// </summary>
        public ObservableCollection<Bruger> BrugerOC { get; set; }

        #endregion

        #region Constuctor

        /// <summary>
        /// kreerer en observable collection kaldet "BrugerOC" af typen Bruger.
        /// </summary>
        private BrugerSingleton()
        {
            BrugerOC = new ObservableCollection<Bruger>();
            
        }
        #endregion

        #region Methods

        /// <summary>
        /// Add laver et nyt objekt af typen Bruger i Databasen (RFStorageDB) vha. metoden PostObject defineret i PersistencyServices.
        /// Derefter tilføjer den det nye objekt til observable collectionen BrugerOC.
        /// </summary>
        /// <param name="bruger"></param>
        public void Add(Bruger bruger)
        {
            Persistency.PersistencyServices<Bruger>.PostObject("api/Brugers", bruger);
            BrugerOC.Add(bruger);
        }

        /// <summary>
        /// Remove fjerner et nyt objekt af typen Bruger fra Databasen (RFStorageDB) vha. metoden PostObject defineret i PersistencyServices.
        /// Derefter fjerner den også objektet fra observable collectionen BrugerOC.
        /// </summary>
        /// <param name="bruger"></param>
        public void Remove(Bruger bruger)
        {
            Persistency.PersistencyServices<Bruger>.DeleteObject("api/Brugers/", bruger.BrugerID);
            BrugerOC.Remove(bruger);
        }

        /// <summary>
        /// "getter" en opdateret version af observable collectionen "BrugerOC" vha metoden "LoadEventAsync".
        /// </summary>
        public async void GetBrugere()
        {
           BrugerOC.Clear();
           LoadEventAsync();
        }

        /// <summary>
        /// Tilføjer databasen RFStorageDBs indhold til observable collectionen BrugerOC.
        /// Hvis ikke der er noget i databasen, bliver der tilføjet et objekt til BrugerOC som en test.
        /// </summary>
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
        /// <summary>
        /// PropertyChangedEventHandler sørger for at sende opdateringer til VM/View når en property bliver opdateret med en værdi.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
