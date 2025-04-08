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
        
        public HttpRequests()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public async Task<List<jsonCars>> CreateCar(jsonCars Cars)
        {
            try
            {
                string serverUrl = this.serverUrl + "AddCar";
                
                string jsonString = JsonConvert.SerializeObject(Cars);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(serverUrl, sendThis);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                response.EnsureSuccessStatusCode();
                return await ListAllCars();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
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
                return cars;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }

        public async Task<List<jsonCars>> DeleteCar(int id)
        {
            try
            {
                string serverUrl = this.serverUrl + "DeleteCar/"+id;
                
                HttpResponseMessage response = await client.DeleteAsync(serverUrl);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                response.EnsureSuccessStatusCode();
                return await ListAllCars();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public async void Registration(string username, string password)
        {
            string serverUrl = this.serverUrl + "AdminRegistration";
            try
            {
                var jsonData = new
                {
                    registerNev = username,
                    registerPassword = password
                };
                string jsonString = JsonConvert.SerializeObject(jsonData);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync(serverUrl, sendThis);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                response.EnsureSuccessStatusCode();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public async Task<bool> Login(string username, string password)
        {
            string serverUrl = this.serverUrl + "AdminLogin";
            
            try
            {
                var jsonData = new
                {
                    loginNev = username,
                    loginPassword = password
                };
                string jsonString = JsonConvert.SerializeObject(jsonData);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync(serverUrl, sendThis);
                
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                
                Token.token = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).token;

                response.EnsureSuccessStatusCode();
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
