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
        /// <summary>
        /// Properties til Kvitteringer, Get/Set sørger for at hente eller sætte værdierne på instancefields med unikke for objekter.
        /// </summary>
        public int OrdreID { get; set; }
        public int OrganisationID { get; set; }
        public ObservableCollection<Vare> VareOC { get; set; }
        public DateTime OrdreDateTime { get; set; }
        public string Note { get; set; }
        public string Udleverer { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
        /// </summary>
        /// <param name="ordreId"></param>
        /// <param name="organisationId"></param>
        /// <param name="vareOc"></param>
        /// <param name="ordreDateTime"></param>
        /// <param name="note"></param>
        /// <param name="udleverer"></param>
        public Ordre(int ordreId, int organisationId, ObservableCollection<Vare> vareOc, DateTime ordreDateTime, string note, string udleverer)
        {
            OrdreID = ordreId;
            OrganisationID = organisationId;
            VareOC = vareOc;
            OrdreDateTime = ordreDateTime;
            Note = note;
            Udleverer = udleverer;
        }
        #endregion

        #region ToStringMethod
        /// <summary>
        /// Convertere Properties i klassen to String så de kan læses i View
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{nameof(OrdreID)}: {OrdreID}, {nameof(OrganisationID)}: {OrganisationID}, {nameof(VareOC)}: {VareOC}, {nameof(OrdreDateTime)}: {OrdreDateTime}, {nameof(Note)}: {Note}, {nameof(Udleverer)}: {Udleverer}";
        }
        #endregion
    }
}
