using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RFStorage.Annotations;

namespace RFStorage.Model
{
    public class Bruger
    {
        private bool _brugerType = false;
        private string _brugerTypeMessage;

        #region Properties

        /// <summary>
        /// Properties til Bruger, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>

        public string BrugerID { get; set; }

        public string Brugernavn { get; set; }

        public string BrugerPassword { get; set; }

        public bool BrugerType { get; set; }

        public string BrugerTypeMessage
        {

            get {
                if (BrugerType == true)
                {
                    return "Admin";
                }
                else
                {
                    return "32-timersbruger";
                }
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        /// <param name="brugerID"></param>
        /// <param name="brugernavn"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        public Bruger(string brugerID, string brugernavn, string brugerPassword, bool brugerType)
        {
            BrugerID = brugerID;
            Brugernavn = brugernavn;
            BrugerPassword = brugerPassword;
            BrugerType = brugerType;
        }

        public override string ToString()
        {
            return $"{nameof(BrugerID)}: {BrugerID}, {nameof(Brugernavn)}: {Brugernavn}, {nameof(BrugerPassword)}: {BrugerPassword}, {nameof(BrugerType)}: {BrugerType}, {nameof(BrugerTypeMessage)}: {BrugerTypeMessage}";
        }

        #endregion

    }
}
