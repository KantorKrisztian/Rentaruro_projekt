using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class HttpRequests
    {
        HttpClient client = new HttpClient();
        string serverUrl = "http://127.1.1.1:3000/";
        public async void CreateCar(jsonCars Cars)
        {
            try
            {
                string serverUrl = this.serverUrl + "AddCar";
                string jsonString = JsonConvert.SerializeObject(Cars);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(serverUrl, sendThis);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        public async Task<List<jsonCars>> ListAllCars()
        {
            List<jsonCars> cars = new List<jsonCars>();
            try
            {
                string serverUrl = this.serverUrl + "ListCars";
                string response = await client.GetStringAsync(serverUrl);
                cars = JsonConvert.DeserializeObject<List<jsonCars>>(response);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return cars;
        }

    }
}
