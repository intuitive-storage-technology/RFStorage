using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;
using RFStorage.Model;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RFStorage.Persistency
{
    class PersistencyServices<T>
    {
        const string ServerUrl = "http://localhost:55555";
        //HttpClientHandler handler;

        //#region Constructor
        //public PersistencyServices()
        //{
        //    handler = new HttpClientHandler();
        //    handler.UseDefaultCredentials = true;
        //}
        //#endregion

        #region Methods


        
        //Get
        public static async Task<List<T>> GetObject(string api)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync(api).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var brugerlist = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                        return brugerlist.ToList();
                    }
                }

                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }

                return null;
            }
        }

        //Delete w/ objID as a string
        public static async void DeleteObject(string api, string objID)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.DeleteAsync(api + objID).Result;
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }


        //Delete w/ objID as an int
        public static async void DeleteObjectInt(string api, int objID)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.DeleteAsync(api + objID).Result;
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }


        //Post
        public static async void PostObject(string api, T obj)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response =  await client.PostAsJsonAsync(api, obj);
                
                    if (!(response.IsSuccessStatusCode))
                    {
                        throw new HttpRequestException();
                    }
                    //taget fra Henriks kode:
                    //string postBody = JsonConvert.SerializeObject(bruger);
                    //var response = client.PostAsync(api,
                    //    new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        #endregion





        //private static string JsonFileName = "Vares.json";

        //public static async void SaveVaresAsJsonAsync(ObservableCollection<Vare> Vares)
        //{
        //    string VaresJsonString = JsonConvert.SerializeObject(Vares);
        //    SerializeVaresFileAsync(VaresJsonString, JsonFileName);
        //}


        //private static async void SerializeVaresFileAsync(string VaresJsonString, string fileName)
        //{
        //    StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        //    await FileIO.WriteTextAsync(localFile, VaresJsonString);
        //}

        //public static async Task<List<Vare>> LoadVaresFromJsonAsync()
        //{
        //    string VaresJsonString = await DeserializeVaresFileAsync(JsonFileName);
        //    if (VaresJsonString != null)
        //        return (List<Vare>)JsonConvert.DeserializeObject(VaresJsonString, typeof(List<Vare>));
        //    return null;
        //}

        //private static async Task<string> DeserializeVaresFileAsync(string fileName)
        //{
        //    try
        //    {
        //        StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        //        return await FileIO.ReadTextAsync(localFile);
        //    }
        //    catch (FileNotFoundException ex)
        //    {
        //        MessageDialogHelper.Show("Loading for the first time? - Try Add and Save some Notes before trying to Save for the first time", "File not Found");
        //        return null;
        //    }
        //}


        //private class MessageDialogHelper
        //{
        //    public static async void Show(string content, string title)
        //    {
        //        MessageDialog messageDialog = new MessageDialog(content, title);
        //        await messageDialog.ShowAsync();
        //    }
        //}



    }
}
