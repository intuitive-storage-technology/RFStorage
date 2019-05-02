using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFStorage.Model
{
    class Ordre
    {
        #region Properties

        public int OrdreID { get; set; }
        public int OrganisationID { get; set; }
        public ObservableCollection<Vare> VareOC { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public string Udleverer { get; set; }


        #endregion

        #region OrdreConstructor

        public Ordre(int ordreId, int organisationId, ObservableCollection<Vare> vareOc, DateTime dateTime, string note, string udleverer)
        {
            OrdreID = ordreId;
            OrganisationID = organisationId;
            VareOC = vareOc;
            DateTime = dateTime;
            Note = note;
            Udleverer = udleverer;
        }
        #endregion

        #region MyRegion

        public override string ToString()
        {
            return $"{nameof(OrdreID)}: {OrdreID}, {nameof(OrganisationID)}: {OrganisationID}, {nameof(VareOC)}: {VareOC}, {nameof(DateTime)}: {DateTime}, {nameof(Note)}: {Note}, {nameof(Udleverer)}: {Udleverer}";
        }
        #endregion
    }
}
