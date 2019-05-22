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
    class OrganisationsSingleton : INotifyPropertyChanged
    {
        #region Instance Field

        private static OrganisationsSingleton _instance = null;
        #endregion
        #region Properties

        public static OrganisationsSingleton Instance
        {
            get
            {
                if (_instance == null){_instance = new OrganisationsSingleton();}
                return _instance;
            }
           
        }

        public ObservableCollection<Organisation> OrganisationOC { get; set; }
        

        #endregion
        #region Constructor

        public OrganisationsSingleton()
        {
            OrganisationOC = new ObservableCollection<Organisation>();
          
        }

        #endregion
        #region Methods

        public void TestOrgan()
        {
            OrganisationOC.Clear();
            ObservableCollection<Vare> Org1OC = new ObservableCollection<Vare>();
            ObservableCollection<Vare> Org2OC = new ObservableCollection<Vare>();
            ObservableCollection<Vare> Org3OC = new ObservableCollection<Vare>();
            ObservableCollection<Vare> Org4OC = new ObservableCollection<Vare>();
            ObservableCollection<Vare> Org5OC = new ObservableCollection<Vare>();

            ObservableCollection<Vare> OrgTilbageOC1 = new ObservableCollection<Vare>();
            ObservableCollection<Vare> OrgTilbageOC2 = new ObservableCollection<Vare>();
            ObservableCollection<Vare> OrgTilbageOC3 = new ObservableCollection<Vare>();
            ObservableCollection<Vare> OrgTilbageOC4 = new ObservableCollection<Vare>();
            ObservableCollection<Vare> OrgTilbageOC5 = new ObservableCollection<Vare>();

            Organisation Org1 = new Organisation(1, "Orange Scene", Org1OC, OrgTilbageOC1);
            Organisation Org2 = new Organisation(2, "Apollo", Org2OC, OrgTilbageOC2);
            Organisation Org3 = new Organisation(3, "Materiel", Org3OC, OrgTilbageOC3);
            Organisation Org4 = new Organisation(4, "East", Org4OC, OrgTilbageOC4);
            Organisation Org5 = new Organisation(5, "West", Org5OC, OrgTilbageOC5);
            Org1.UdleveretVareOC.Add(new Vare("Køleskab", 1, "Test1", 50));
            Org2.UdleveretVareOC.Add(new Vare("Køleskab", 1, "Test2", 50));
            Org3.UdleveretVareOC.Add(new Vare("Køleskab", 1, "Test3", 50));
            Org4.UdleveretVareOC.Add(new Vare("Køleskab", 1, "Test4", 50));
            Org5.UdleveretVareOC.Add(new Vare("Køleskab", 1, "Test5", 50));

           
            OrganisationOC.Add(Org1);
            OrganisationOC.Add(Org2);
            OrganisationOC.Add(Org3);
            OrganisationOC.Add(Org4);
            OrganisationOC.Add(Org5);



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
