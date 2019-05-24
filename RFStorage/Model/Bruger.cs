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
        private bool _type = false;
        private string _brugerTypeMessage;

        #region Properties

        /// <summary>
        /// Properties til Bruger, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>

        public string BrugerID { get; set; }

        public string Brugernavn { get; set; }
        public string Password { get; set; }

        public bool Type
        {
            get => _type;
            set => _type = value;
        }

        public string BrugerTypeMessage
        {

            get {
                if (Type == true)
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
