using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;
using RFStorage.Model;

namespace RFStorage.Persistency
{
    class PersistencyServices
    {
        private static string JsonFileName = "Vares.json";

        public static async void SaveVaresAsJsonAsync(ObservableCollection<Vare> Vares)
        {
            string VaresJsonString = JsonConvert.SerializeObject(Vares);
            SerializeVaresFileAsync(VaresJsonString, JsonFileName);
        }

        public static async Task<List<Vare>> LoadVaresFromJsonAsync()
        {
            string VaresJsonString = await DeserializeVaresFileAsync(JsonFileName);
            if (VaresJsonString != null)
                return (List<Vare>)JsonConvert.DeserializeObject(VaresJsonString, typeof(List<Vare>));
            return null;
        }



        private static async void SerializeVaresFileAsync(string VaresJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, VaresJsonString);
        }


        private static async Task<string> DeserializeVaresFileAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageDialogHelper.Show("Loading for the first time? - Try Add and Save some Notes before trying to Save for the first time", "File not Found");
                return null;
            }
        }


        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }



    }
}
