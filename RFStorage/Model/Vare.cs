using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Vare
    {
        #region Properties
        /// <summary>
        /// Properties til Vare, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>
        public string VareNavn { get; set; }
        public int VareID { get; set; }        
        public string VareType { get; set; }
        public int Antal { get; set; }      
        public string VareTilstand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        /// <param name="vareNavn"></param>
        /// <param name="vareId"></param>
        /// <param name="vareType"></param>
        /// <param name="antal"></param>
        /// <param name="vareTilstand"></param>
        public Vare(string vareNavn, int vareId, string vareType, int antal, string vareTilstand)
        {
            VareNavn = vareNavn;
            VareID = vareId;
            VareType = vareType;
            Antal = antal;
            VareTilstand = vareTilstand;
        }

        #endregion
    }
}
