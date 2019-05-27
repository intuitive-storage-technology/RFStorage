using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using RFStorage.ViewModel;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace RFStorage.Model
{
    class Kvittering
    {

        /// <summary>
        /// Denne metode initialisere selve pdfdokumentet og memorystreamen og kalder til sidst Save-hjælpe metoden.
        /// Dette pdfdokumentet bruges i forbindelse med tilbagelevering
        ///  </summary>
        /// <remarks> Exceptions : Vil smide en null-reference exception hvis TilbageleveringsOC peger på null og dette ikke er checket før klassen bliver kaldt </remarks>
        /// <remarks> Pre-Conditions : UdleveringsOC skal eksistere, dette gøres i forbindelse med udlevering af varene </remarks>
        /// <remarks> Post-Conditions : Efter metoden er kørt igennem, vil opsætningen af pdf-dokumentet være lavet og Save metoden kaldes. </remarks>
        /// <remarks>          Side-Effects : Der er ingen sideeffects ved denne metode </remarks>
        
        public static void KvitteringTilbage()
        {
            using (PdfDocument pdfdoc = new PdfDocument())

            {
                // Genererer sammen med using-sætningen selve pdfen.

                #region Page/graphics generation

                PdfPage page = pdfdoc.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                #endregion

                // Definerer font og udseende af bodyen
                // Indeholder en bevægelighed for at kunne gøre den betinget af variabler.

                #region Body 
                

                var count = 0;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                foreach (var e in OrganisationVM.TilbageLeveringsOC)
                {

                    graphics.DrawString($"{e.VareNavn}", font, PdfBrushes.Black, 200, 400 + count);
                    graphics.DrawString($"{e.VareAntal}", font, PdfBrushes.Black, 300, 400 + count);
                    count = count + 50;
                }

                #endregion

                // Laver en adskillese imellem Header og Body - PdfPen bruges til dette. Det er markant mere effektivt end at skrive strings af linjer.

                #region Body/Header Adskillese

                PdfPen pen = new PdfPen(PdfBrushes.Black);
                PdfFont BodyHeaderFont = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
                graphics.DrawLine(pen, 0, 130, 595, 130);
                graphics.DrawLine(pen, 0, 140, 595, 140);
                graphics.DrawString("info                info                 info                  info",
                    BodyHeaderFont, PdfBrushes.Black, 150, 130);

                #endregion

                // Definerer header udseende - denne er delt op i forskellige dele for at gøre selve designfasen nemmere og mere flexibel.

                #region Header

                //Definerer left header - indeholder bare font og drawstring.

                #region Left Header

                string LeftHeaderText = "Roskilde Festival";
                string LeftHeaderText2 = "Vor Frue Hovedgade 8";
                string LeftHeaderText3 = "Kontaktperson - Filip Dan Hansen";
                string LeftHeaderText4 = "Telefon - 99 99 99 99";
                PdfFont LeftHeaderFont = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
                graphics.DrawString(LeftHeaderText, LeftHeaderFont, PdfBrushes.Black, 0, 0);
                graphics.DrawString(LeftHeaderText2, LeftHeaderFont, PdfBrushes.Black, 0, 15);
                graphics.DrawString(LeftHeaderText3, LeftHeaderFont, PdfBrushes.Black, 0, 30);
                graphics.DrawString(LeftHeaderText4, LeftHeaderFont, PdfBrushes.Black, 0, 45);

                #endregion

                // Denne del af headeren indeholder et billede. Her bruges GetManiFestResourceStream for at hente et billede. Billedet SKAL! være embedded resource
                // da vi ellers ikke kan få adgang til det i UWP. 

                #region Right Header

                Stream imageStream = typeof(Kvittering).GetTypeInfo().Assembly
                    .GetManifestResourceStream("RFStorage.Assets.roskilde-festival-logo.png");
                PdfBitmap bmp = new PdfBitmap(imageStream);
                graphics.DrawImage(bmp, 420, 0, 60, 60);

                #endregion

                // Mid header - indeholder fonts og drawstrings.

                #region Mid Header

                string MidHeaderText = "Tilbagelevering - Dummy";
                string MidHeaderText2 = "Tilbageleveringstidspunkt: 19-03-2019 22:22:14";
                PdfFont MiddleHeaderFont2 = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                PdfFont MiddleHeaderFont3 = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                graphics.DrawString(MidHeaderText, MiddleHeaderFont2, PdfBrushes.Black, 150, 60);
                graphics.DrawString(MidHeaderText2, MiddleHeaderFont3, PdfBrushes.Black, 100, 90);

                #endregion

                #endregion

                // Definerer footer delen af PDF'en - Her bruges Font, Drawstring og Pen - Ingen yderligere forklaring nødvendig

                #region Footer

                PdfFont FooterFont1 = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
                PdfFont FooterFont2 = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

                #region Right Footer

                string RightFooterText = "Lejer";
                string RightFooterText2 = "___________________";
                string RightFooterText3 = "Underskrift";
                graphics.DrawString(RightFooterText, FooterFont1, PdfBrushes.Black, 30, 700);
                graphics.DrawString(RightFooterText2, FooterFont1, PdfBrushes.Black, 30, 740);
                graphics.DrawString(RightFooterText3, FooterFont2, PdfBrushes.Black, 30, 750);

                #endregion

                #region Left Footer

                string LeftFooterText = "Udlejer - Team Materiel";
                string LeftFooterText2 = "___________________";
                string LeftFooterText3 = "Underskrift";
                graphics.DrawString(LeftFooterText, FooterFont1, PdfBrushes.Black, 380, 700);
                graphics.DrawString(LeftFooterText2, FooterFont1, PdfBrushes.Black, 380, 740);
                graphics.DrawString(LeftFooterText3, FooterFont2, PdfBrushes.Black, 380, 750);

                #endregion

                #region MidFooter

                PdfPen FooterPen = new PdfPen(PdfBrushes.Black);
                graphics.DrawLine(FooterPen, 0, 670, 595, 670);

                #endregion


                #endregion

                // I denne Region laves startes hele processen - En memory stream bliver initialiseret og pdfdoc bliver gemt deri, derudover kaldes 
                // hjælpe Save metoden

                #region Save/Process

                MemoryStream ms = new MemoryStream();
                pdfdoc.Save(ms);
                // Definerer den stream der bruges til save metoden - og det filnavn der skal bruges som Suggested File Name => Save(Stream navn, Suggested File Name)
                Save(ms, "Sample.pdf");

                #endregion

            }

        }
        /// <summary>
        /// Denne metode initialisere selve pdfdokumentet og memorystreamen og kalder til sidst Save-hjælpe metoden.
        /// Dette pdfdokument er til brug ved Udlevering.
        ///  </summary>
        /// <remarks> Exceptions : Vil smide en null-reference exception hvis UdleveringsOC peger på null og dette ikke bliver tjekket ordentligt før metoden bliver kaldt</remarks>
        /// <remarks> Pre-Conditions : UdleveringsOC skal eksistere, dette gøres i forbindelse med udlevering af varene </remarks>
        /// <remarks> Post-Conditions : Efter metoden er kørt igennem, vil opsætningen af pdf-dokumentet være lavet og Save metoden kaldes. </remarks>
        /// <remarks> Side-effects : Der er ingen sideeffects ved denne metode</remarks>
        public static void KvitteringUd()
        {
            using (PdfDocument pdfdoc = new PdfDocument())
            {
                // Genererer sammen med using-sætningen selve pdfen.

                #region Page/graphics generation

                PdfPage page = pdfdoc.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                #endregion

                // Definerer font og udseende af bodyen
                // Indeholder en bevægelighed for at kunne gøre den betinget af variabler.

                #region Body 

                //TODO - Variable defineret body

                var count = 0;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                foreach (var e in OrganisationVM.UdleveringsOC)
                {

                    graphics.DrawString($"{e.VareNavn}", font, PdfBrushes.Black, 200, 400 + count);
                    graphics.DrawString($"{e.VareAntal}", font, PdfBrushes.Black, 300, 400 + count);
                    count = count + 50;
                }

                #endregion

                // Laver en adskillese imellem Header og Body - PdfPen bruges til dette. Det er markant mere effektivt end at skrive strings af linjer.

                #region Body/Header Adskillese

                PdfPen pen = new PdfPen(PdfBrushes.Black);
                PdfFont BodyHeaderFont = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
                graphics.DrawLine(pen, 0, 130, 595, 130);
                graphics.DrawLine(pen, 0, 140, 595, 140);
                graphics.DrawString("info                info                 info                  info",
                    BodyHeaderFont, PdfBrushes.Black, 150, 130);

                #endregion

                // Definerer header udseende - denne er delt op i forskellige dele for at gøre selve designfasen nemmere og mere flexibel.

                #region Header

                //Definerer left header - indeholder bare font og drawstring.

                #region Left Header

                string LeftHeaderText = "Roskilde Festival";
                string LeftHeaderText2 = "Vor Frue Hovedgade 8";
                string LeftHeaderText3 = "Kontaktperson - Filip Dan Hansen";
                string LeftHeaderText4 = "Telefon - 99 99 99 99";
                PdfFont LeftHeaderFont = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
                graphics.DrawString(LeftHeaderText, LeftHeaderFont, PdfBrushes.Black, 0, 0);
                graphics.DrawString(LeftHeaderText2, LeftHeaderFont, PdfBrushes.Black, 0, 15);
                graphics.DrawString(LeftHeaderText3, LeftHeaderFont, PdfBrushes.Black, 0, 30);
                graphics.DrawString(LeftHeaderText4, LeftHeaderFont, PdfBrushes.Black, 0, 45);

                #endregion

                // Denne del af headeren indeholder et billede. Her bruges GetManiFestResourceStream for at hente et billede. Billedet SKAL! være embedded resource
                // da vi ellers ikke kan få adgang til det i UWP. 

                #region Right Header

                Stream imageStream = typeof(Kvittering).GetTypeInfo().Assembly
                    .GetManifestResourceStream("RFStorage.Assets.roskilde-festival-logo.png");
                PdfBitmap bmp = new PdfBitmap(imageStream);
                graphics.DrawImage(bmp, 420, 0, 60, 60);

                #endregion

                // Mid header - indeholder fonts og drawstrings.

                #region Mid Header

                string MidHeaderText = "Udlevering - Dummy";
                string MidHeaderText2 = "Udleveringstidspunkt: 19-03-2019 22:22:14";
                PdfFont MiddleHeaderFont2 = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                PdfFont MiddleHeaderFont3 = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                graphics.DrawString(MidHeaderText, MiddleHeaderFont2, PdfBrushes.Black, 150, 60);
                graphics.DrawString(MidHeaderText2, MiddleHeaderFont3, PdfBrushes.Black, 100, 90);

                #endregion

                #endregion

                // Definerer footer delen af PDF'en - Her bruges Font, Drawstring og Pen - Ingen yderligere forklaring nødvendig

                #region Footer

                PdfFont FooterFont1 = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
                PdfFont FooterFont2 = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

                #region Right Footer

                string RightFooterText = "Lejer";
                string RightFooterText2 = "___________________";
                string RightFooterText3 = "Underskrift";
                graphics.DrawString(RightFooterText, FooterFont1, PdfBrushes.Black, 30, 700);
                graphics.DrawString(RightFooterText2, FooterFont1, PdfBrushes.Black, 30, 740);
                graphics.DrawString(RightFooterText3, FooterFont2, PdfBrushes.Black, 30, 750);

                #endregion

                #region Left Footer

                string LeftFooterText = "Udlejer - Team Materiel";
                string LeftFooterText2 = "___________________";
                string LeftFooterText3 = "Underskrift";
                graphics.DrawString(LeftFooterText, FooterFont1, PdfBrushes.Black, 380, 700);
                graphics.DrawString(LeftFooterText2, FooterFont1, PdfBrushes.Black, 380, 740);
                graphics.DrawString(LeftFooterText3, FooterFont2, PdfBrushes.Black, 380, 750);

                #endregion

                #region MidFooter

                PdfPen FooterPen = new PdfPen(PdfBrushes.Black);
                graphics.DrawLine(FooterPen, 0, 670, 595, 670);

                #endregion


                #endregion

                // I denne Region laves startes hele processen - En memory stream bliver initialiseret og pdfdoc bliver gemt deri, derudover kaldes 
                // hjælpe Save metoden

                #region Save/Process

                MemoryStream ms = new MemoryStream();
                pdfdoc.Save(ms);
                // Definerer den stream der bruges til save metoden - og det filnavn der skal bruges som Suggested File Name => Save(Stream navn, Suggested File Name)
                Save(ms, "Sample.pdf");

                #endregion

            }
        }


        /// <summary>
        ///  Denne metode hjælper med at gemme pdf-filen.
        /// </summary>
        /// <remarks> Preconditions : Kvitterings filen skal være initialieret og det samme
        /// skal memorystreamen</remarks>
        /// <remarks> PostCondition : Der vil herefter være en fil gemt på pcen der kører programmet</remarks>
        /// <remarks> Side-Effects : Der er ingen side effects ved brugen af denne metode</remarks>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        public static async void Save(Stream stream, string filename)
        {

           stream.Position = 0;
           StorageFile stFile;

           // If-else-expressionen bestemmer om filen gemmes på en computer eller på et andet stykke hardware som en tablet. Den fortsætter i If hvis det ikke er en telefon/Tablet
           // ellers går den til else hvor den gemmer som var den en telefon.
           // På computer vil den give en default extension på filen, et suggested filename og vælge en filtype
           // FileTypeChoices tager en dictionary som tager en string og en List<string>. Denne Dictionary indeholder de valide filtyper der kan gemmes som

           if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input")))
           {
              FileSavePicker savepicker = new FileSavePicker();
              savepicker.DefaultFileExtension = ".pdf";
              savepicker.SuggestedFileName = filename;
              savepicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() {".pdf"});
              stFile = await savepicker.PickSaveFileAsync();
           }
           else
           {
              StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
              stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
           }

              // Hvis filen bliver gemt i stFile giver denne en dialogboks til at gemme og til at åbne dokumentet hvorefter, hvis brugen trykker yes for at vise
              // filen vil denne metode åbne den.
           if (stFile != null)
           {
              //Windows.Storage.Streams.IRandomAccessStream fileStream =
              //await stFile.OpenAsync(FileAccessMode.ReadWrite);
              //Stream st = fileStream.AsStreamForWrite();
              //st.Write((stream as MemoryStream).ToArray(), 0, (int) stream.Length);
              //st.Flush();
              //st.Dispose();
              //fileStream.Dispose();
              MessageDialog msgDialog =
              new MessageDialog("Do you want to view the Document", "File created.");
              UICommand yesCmd = new UICommand("Yes");
              msgDialog.Commands.Add(yesCmd);
              UICommand noCmd = new UICommand("No");
              msgDialog.Commands.Add(noCmd);
              IUICommand cmd = await msgDialog.ShowAsync();
              if (cmd == yesCmd)
              {
                   bool success = await Windows.System.Launcher.LaunchFileAsync(stFile);
              }
           }

        }
           
    }
}


