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
        //
        public LagerstatusVM LagerstatusVM { get; set; }

        //Construktor
        public VareHandler(LagerstatusVM lagerstatusVm)
        {
            LagerstatusVM = lagerstatusVm;
        }

        //methods

        //Create
        public void CreateVare()
        {
            LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test1", 1, "type", 1, "Supergod"));
            LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test2", 1, "type", 1, "Supergod"));
            LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test3", 1, "type", 1, "Supergod"));
            LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test4", 1, "type", 1, "Supergod"));
            
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
