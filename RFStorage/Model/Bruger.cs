using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Bruger
    {

        #region Properties
        /// <summary>
        /// Properties til Bruger, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>

        public string BrugerID { get; set; }
        public string Brugernavn { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        /// <param name="brugerID"></param>
        /// <param name="brugernavn"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        public Bruger(string brugerID, string brugernavn, string password, bool type)
        {
            BrugerID = brugerID;
            Brugernavn = brugernavn;
            Password = password;
            Type = type;
        }

        public override string ToString()
        {
            return $"{nameof(BrugerID)}: {BrugerID}, {nameof(Brugernavn)}: {Brugernavn}, {nameof(Password)}: {Password}, {nameof(Type)}: {Type}";
        }

        #endregion

    }
}
