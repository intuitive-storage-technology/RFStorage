using System;
using System.Reflection.Metadata.Ecma335;
using Windows.Devices.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFStorage;
using RFStorage.Model;
using RFStorage.ViewModel;
using System.ServiceModel.Channels;

namespace RFStorageUniteTest
{
    [TestClass]
    class UnitTest1
    {
        //Test the UnitTest1 class
        [TestMethod]
        public void TestTheTest()
        {
            Assert.AreEqual(true, true);
        }


        //Vi prøver at test, vores Vare objekt 

        //Test at vare constructor
        [TestMethod]
        public void TestVareConstructor()
        {
            RFStorage.Model.Vare vare = new Vare("TestNavn",1,"TestVareType",1);
            string expectedVareNavn = "TestNavn";
            int expectedVareID = 1;
            string expectedVareType = "TestVareType";
            int expectedVareAntal = 1;


            Assert.AreEqual(expectedVareAntal, vare.VareAntal);
            Assert.AreEqual(expectedVareID, vare.VareID);
            Assert.AreEqual(expectedVareNavn, vare.VareNavn);
            Assert.AreEqual(expectedVareType, vare.VareType);
        }

        //Test at Lagerstatus singleton objekted, er created rigtigt og listen viser correct antal objeckter på listen 
        [TestMethod]
        public void TestLagerStatusSingleton()
        {
            RFStorage.Model.LagerstatusSingleton.Instance.test();
            int expectedCount = 5;
            Assert.AreEqual(RFStorage.Model.LagerstatusSingleton.Instance.VareOC.Count, expectedCount);

        }

        //Test om exectionThrow ved fejlbrug af kvittering
        [TestMethod]
        public void TestKviterringExeption()
        {
            try
            {
                // Burde skabe exception:
                RFStorage.Model.Kvittering.KvitteringUd();

            }
            catch (Exception e)
            {

            }
        }

        //test Login password tjek
        [TestMethod]
        public void TestAfLoginTjek()
        {
            Bruger bruger = new Bruger("TestForUnitTest","TestNavnForUT","TestPasswaordForUT",true);
            
        }
        
    }
}
