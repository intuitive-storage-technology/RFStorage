using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Bruger
    {

        #region BrugerProp

        public int BrugerID { get; set; }
        public string BrugerNavn { get; set; }
        public string PassWord { get; set; }
        public bool Type { get; set; }

        #endregion

        #region BrugerConst

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
