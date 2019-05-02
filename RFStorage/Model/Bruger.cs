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

        public int BrugerID { get; set; }
        public string BrugerNavn { get; set; }
        public string PassWord { get; set; }
        public bool Type { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        /// <param name="brugerId"></param>
        /// <param name="brugerNavn"></param>
        /// <param name="passWord"></param>
        /// <param name="type"></param>
        public Bruger(int brugerId, string brugerNavn, string passWord, bool type)
        {
            BrugerID = brugerId;
            BrugerNavn = brugerNavn;
            PassWord = passWord;
            Type = type;
        }
        #endregion

    }
}
