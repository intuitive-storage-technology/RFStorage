using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    public class Organisation
    {
        #region Properties

      

        /// <summary>
        /// Properties til Organisation, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>
        public int OrganisationID { get; set; }
        public string OrganisationNavn { get; set; }
        public ObservableCollection<Vare> UdleveretVareOC { get; set; }
        public ObservableCollection<Kvittering> OrganisationKvitterings { get; set; }
        public ObservableCollection<Vare> OrgansationOC { get; set; }
        public ObservableCollection<Vare> TilbageLeveringsVare { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Constructor - initialisere de forskellige parametre
        /// </summary>
        /// <param name="organisationId"></param>
        /// <param name="organisationNavn"></param>
        /// <param name="udleveretVareOc"></param>
        /// <param name="organisationKvitterings"></param>
        /// <param name="tilbageLeveringsVare"></param>
         public Organisation(int organisationId, string organisationNavn, ObservableCollection<Vare> udleveretVareOc, ObservableCollection<Vare> tilbageLeveringsVare)
        {
            OrganisationID = organisationId;
            OrganisationNavn = organisationNavn;
            UdleveretVareOC = udleveretVareOc;
            TilbageLeveringsVare = tilbageLeveringsVare;
        }
        
        #endregion
        #region ToString

        public override string ToString()
        {
            return $" {OrganisationID} : {OrganisationNavn} : {UdleveretVareOC} : {OrganisationKvitterings}";
        }

        #endregion
    }
}
