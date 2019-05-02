using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Kvittering
    {
        #region Properties
        /// <summary>
        /// Properties til Kvitteringer, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>
        //public int Kvittering { get; set; }
        public int OrganisationID { get; set; }
        public ObservableCollection<Vare> Varelist;
        public bool Tilstand { get; set; }

        #endregion

        #region Constructor

        public Kvittering()
        {

        }
        #endregion
    }
}
