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
    class EventHandler
    {
        //public LagerstatusVM LagerstatusVM { get; set; }

        //public EventHandler(LagerstatusVM lagerstatusVM)
        //{
        //    LagerstatusVM = lagerstatusVM;
        //}

        //public void CreateVare()
        //{
        //    //var newEvent = new Event(EventViewModel.Id, EventViewModel.Name, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time), EventViewModel.Description);
        //    //EventViewModel.EventCatalogSingleton.Add(newEvent);
        //   //LagerstatusVM.LagerstatusSingleton.VareOC.Add(LagerstatusVM.VareID, LagerstatusVM.Antal, LagerstatusVM.VareNavn, LagerstatusVM.VareType, LagerstatusVM.VareTilstand);
           
        //    LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test1",1,"type",1,"Supergod"));
        //    LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test2", 1, "type", 1, "Supergod"));
        //    LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test3", 1, "type", 1, "Supergod"));
        //    LagerstatusVM.LagerstatusSingleton.VareOC.Add(new Vare("Test4", 1, "type", 1, "Supergod"));

        //    // EventViewModel.EventCatalogSingleton.Add(EventViewModel.Id, EventViewModel.Name, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time), EventViewModel.Description);
        //}

        //public void SetSelectedVare(Vare vare)
        //{
            
        //    LagerstatusVM.SelectedEvent = vare;
        //}

        //public void DeleteVare()
        //{
        //    if (LagerstatusVM.SelectedEvent != null)
        //    {
        //        LagerstatusVM.LagerstatusSingleton.VareOC.Remove(LagerstatusVM.SelectedEvent);
        //    }
            
        //    ////new UICommandInvokedHandler(this.CommandInvokedHandler);

        //    //// Create the message dialog and set its content
        //    //var messageDialog = new MessageDialog("Are you sure you want to Delete the Event: " + LagerstatusVM.SelectedEvent.VareNavn + " ?");

        //    //// Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
        //    //messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
        //    //messageDialog.Commands.Add(new UICommand("No", null));

        //    //// Set the command that will be invoked by default
        //    //messageDialog.DefaultCommandIndex = 0;

        //    //// Set the command to be invoked when escape is pressed
        //    //messageDialog.CancelCommandIndex = 1;

        //    //// Show the message dialog
        //    //await messageDialog.ShowAsync();




        //}

        //private void CommandInvokedHandler(IUICommand command)
        //{
        //    LagerstatusVM.LagerstatusSingleton.VareOC.Remove(LagerstatusVM.SelectedEvent);
        //}
    }
}
