using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using RFStorage.Model;
using RFStorage.ViewModel;

namespace RFStorage.Handler
{
    class VareHandler
    {
        public string VareNavn { get; set; }
        public int VareID { get; set; }
        public string VareType { get; set; }
        public int VareAntal { get; set; }


        #region Properties
        public LagerstatusVM LagerstatusVM { get; set; }
        #endregion

        #region Construktor

        public VareHandler(LagerstatusVM lagerstatusVm)
        {
            LagerstatusVM = lagerstatusVm;
        }

        #endregion

        //methods

        //Create
        public void CreateVare()
        {

         Vare vare = new Vare(VareNavn, VareID, VareType, VareAntal);
         LagerstatusSingleton.Instance.VareOC.Add(vare);
        }

        public void SetSelectedVare(Vare vare)
        {
            LagerstatusVM.SelectedVare = vare;
        }

        public void DeleteVare()
        {
            if (LagerstatusVM.SelectedVare != null)
            {
                LagerstatusVM.LagerstatusSingleton.VareOC.Remove(LagerstatusVM.SelectedVare);
            }
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            LagerstatusVM.LagerstatusSingleton.Remove(LagerstatusVM.SelectedVare);
        }

    }
}
