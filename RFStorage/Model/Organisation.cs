using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Organisation
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
        #endregion


        #region Constructor
        /// <summary>
        /// /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        /// <param name="organisationId"></param>
        /// <param name="organisationNavn"></param>
         public Organisation(int organisationId, string organisationNavn, ObservableCollection<Vare> udleveretVareOc)
        {
            OrganisationID = organisationId;
            OrganisationNavn = organisationNavn;
            UdleveretVareOC = udleveretVareOc;
          
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
