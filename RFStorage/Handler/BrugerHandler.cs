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
    class BrugerHandler
    {
        #region Properties
        public CreateRemoveBrugerVM CreateRemoveBrugerVM { get; set; }
        #endregion

        #region Constructor

        public BrugerHandler(CreateRemoveBrugerVM createRemoveBrugerVM)
        {
            CreateRemoveBrugerVM = createRemoveBrugerVM;
        }
        #endregion

        #region Method

        public void SetSelectedBruger(Bruger bruger)
        {
            CreateRemoveBrugerVM.SelectedBruger = bruger;
        }

        public void CreateBruger()
        {
            //CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Add(new Bruger("celi4162", "Celine Stenberg", "passwordceline", true));
            //CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Add(new Bruger("Emil7213", "Emil Mosbaek", "passwordemil", true));
            //CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Add(new Bruger("Fili3801", "Filip Hansen", "passwordfilip", true));
            //CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Add(new Bruger("Jonx2905", "Jon Lam", "passwordjon", false));

            CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Add(new Bruger(CreateRemoveBrugerVM.BrugerID, CreateRemoveBrugerVM.Brugernavn, CreateRemoveBrugerVM.Password, CreateRemoveBrugerVM.Type));
            
        }

        public async void DeleteBruger()
        {


            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("Er du sikker på at du vil fjerne brugeren: " + CreateRemoveBrugerVM.SelectedBruger.Brugernavn + " ?");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Ja", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("Nej", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Remove(CreateRemoveBrugerVM.SelectedBruger);
        }

        #endregion

    }
}
