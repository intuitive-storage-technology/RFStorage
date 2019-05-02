using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Vare
    {
        #region VareProp

        //VareNavn
        public string VareNavn { get; set; }



        //VareID
        public int VareID { get; set; }

        //Vare Type
        public string VareType { get; set; }

        //Antal
        public int Antal { get; set; }

        //VareTilstand
        public string VareTilstand { get; set; }

        #endregion

        #region VareConst




        //Vare Constructor
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
