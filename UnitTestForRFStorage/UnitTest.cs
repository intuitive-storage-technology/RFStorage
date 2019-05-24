using RFStorage.ViewModel;
using RFStorage.Model;
using System;
using Windows.UI.Popups;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForRFStorage
{
    [TestClass]
    public class UnitTest1
    {

        #region Bruger Test
        /// <summary>
        /// Undersøger om Add og Remove metoderne fungere.
        /// </summary>


        //Tester om Bruger add virker 
        [TestMethod]
        public void TestAddToBrugerOC()
        {
            Bruger bruger = new Bruger("UTID", "UTNavn", "UTPass", true);
            CreateRemoveBrugerVM creacCreateRemoveBrugerVm = new CreateRemoveBrugerVM();
            BrugerSingleton.Instance.BrugerOC.Add(bruger);
        }

        //Tester om Bruger kan blive fjernet
        [TestMethod]
        public void TestRemoveToBrugerOC()
        {
            Bruger bruger = new Bruger("UTID", "UTNavn", "UTPass", true);
            CreateRemoveBrugerVM creacCreateRemoveBrugerVm = new CreateRemoveBrugerVM();
            BrugerSingleton.Instance.BrugerOC.Remove(bruger);
        }

        #endregion


        #region Vare
        //Test om Vare add virker
        /// <summary>
        /// Undersøger om Add og Remove metoderne fungere.
        /// </summary>
        [TestMethod]
        public void TestVareAdd()
        {
            Vare vare = new Vare("UTNavn",1,"VareType",1);
            LagerstatusVM lagerstatusVm = new LagerstatusVM();
            LagerstatusSingleton.Instance.VareOC.Add(vare);
        }

        //test om Vare kan blive fjernet
        public void TestVareRemove()
        {
            Vare vare = new Vare("UTNavn",1,"UTTtpe",1);
            LagerstatusSingleton.Instance.VareOC.Add(vare);
            LagerstatusSingleton.Instance.VareOC.Remove(vare);
            try
            {
                LagerstatusSingleton.Instance.VareOC.Count.CompareTo(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion

        #region Kvittering test
        /// <summary>
        /// Da der ikke er mange muligheder, for at bruge denne klasse. Har man valgt at vise Kvitteringens sikring mod en null modtagelse.
        /// </summary>

        //Test Kvittering exeception
        [TestMethod]
        public void TestKviterring()
        {
            try
            {
                RFStorage.Model.Kvittering.KvitteringUd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion  

    }
}
