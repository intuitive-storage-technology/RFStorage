﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using RFStorage.Model;
using RFStorage.ViewModel;

namespace RFStorage.Handler
{
    public class BrugerHandler
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
        /// <summary>
        /// Sætter SelectedBruger fra CreateRemoveBrugerVM til at være lig en bestemt instans af et objekt af typen Bruger.
        /// </summary>
        /// <param name="bruger"></param>
        public void SetSelectedBruger(Bruger bruger)
        {
            CreateRemoveBrugerVM.SelectedBruger = bruger;
        }

        /// <summary>
        /// Laver et objekt af typen Bruger vha. metoden Add i BrugerSingleton.
        /// </summary>
        public async void CreateBruger()
        {
            CreateRemoveBrugerVM.BrugerSingleton.Add(new Bruger(CreateRemoveBrugerVM.BrugerID, CreateRemoveBrugerVM.Brugernavn,
                CreateRemoveBrugerVM.BrugerPassword, CreateRemoveBrugerVM.BrugerType));
            
        }

        /// <summary>
        /// Spørger om man vil slette en specifik bruger. Hvis ja, så sletter den brugeren vha metoden CommandInvokedHandler.
        /// </summary>
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

        /// <summary>
        /// Sletter et objekt af typen Bruger.
        /// </summary>
        /// <param name="command"></param>
        private void CommandInvokedHandler(IUICommand command)
        {
            //CreateRemoveBrugerVM.BrugerSingleton.BrugerOC.Remove(CreateRemoveBrugerVM.SelectedBruger);
            CreateRemoveBrugerVM.BrugerSingleton.Remove(CreateRemoveBrugerVM.SelectedBruger);
        }

        #endregion

    }
}
