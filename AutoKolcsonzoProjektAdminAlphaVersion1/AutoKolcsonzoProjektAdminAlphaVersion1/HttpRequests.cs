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
        //Setting the request headers authorization to the token
        public HttpRequests()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer__"+Token.token);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //Encoding and decoding the password
        public string EncodePassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        public string DecodePassword(string encodedPassword)
        {
            byte[] passwordBytes = Convert.FromBase64String(encodedPassword);
            return Encoding.UTF8.GetString(passwordBytes);
        }
        //Creating a new car
        public async Task<bool> CreateCar(jsonCars Cars)
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
                //Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
        }
        //Asking the server for all the cars
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
        //Updating a cars information based on it's id
        public async Task<List<jsonCars>> UpdateCar(jsonCars Cars)
        {
            try
            {
                string serverUrl = this.serverUrl + "UpdateCar/"+Cars.id;
                string jsonString = JsonConvert.SerializeObject(Cars);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response= await client.PutAsync(serverUrl,sendThis);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                return await ListAllCars();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return await ListAllCars();
            }
        }
        //Deleting a car based on it's id
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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return await ListAllCars();
        }
        //Asking the server for all the rents
        public async Task<List<jsonRents>> ListAllRents()
        {
            List<jsonRents> rents = new List<jsonRents>();
            try
            {
                string serverUrl = this.serverUrl + "ListAllRents";
                string response = await client.GetStringAsync(serverUrl);
                rents = JsonConvert.DeserializeObject<List<jsonRents>>(response);
                return rents;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return rents;
            }
        }
        //Updating a rent based on it's id
        public async Task<List<jsonRents>> UpdateRent(jsonRents rents)
        {
            try
            {
                string serverUrl = this.serverUrl + "UpdateRent/" + rents.id;
                string startString = rents.start.ToString();
                string[] StartSplit = startString.Split(' ');
                string endString=rents.end.ToString();
                string[] EndSplit = endString.Split(' ');
                var jsonData = new
                {
                    start = StartSplit[0]+ StartSplit[1]+ StartSplit[2]+"02:02:02",
                    end = EndSplit[0] + EndSplit[1] + EndSplit[2] + "02:02:02",
                    other = rents.other,
                    carId=rents.carId
                };
                List<jsonRents> checkRents = await ListAllRents();
                foreach (jsonRents item in checkRents)
                {
                    if (item.carId == rents.carId && item.id != rents.id)
                    {
                        if ((item.start.DayOfYear <= rents.start.DayOfYear && item.end.DayOfYear >= rents.start.DayOfYear) || (item.start.DayOfYear <= rents.end.DayOfYear && item.end.DayOfYear >= rents.end.DayOfYear))
                        {
                            MessageBox.Show("Ez az autó már foglalt ebben az időpontban!");
                            return await ListAllRents();
                        }
                        if (item.start.DayOfYear >= rents.start.DayOfYear && item.end.DayOfYear <= rents.end.DayOfYear)
                        {
                            MessageBox.Show("Ez az autó már foglalt ebben az időpontban!");
                            return await ListAllRents();
                        }
                    }
                }
                string jsonString = JsonConvert.SerializeObject(jsonData);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PutAsync(serverUrl, sendThis);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                return await ListAllRents();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return await ListAllRents();
            }
        }
        //Deleting a rent based on it's id
        public async Task<List<jsonRents>> DeleteRent(int id)
        {
            try
            {
                string serverUrl = this.serverUrl + "DeleteRent/" + id;


                HttpResponseMessage response = await client.DeleteAsync(serverUrl);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                response.EnsureSuccessStatusCode();
                return await ListAllRents();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return await ListAllRents();
            }
        }
        //Creating a new worker
        public async Task<List<jsonPersonalInfo>> Registration(jsonPersonalInfo personalInfo)
        {
            string serverUrl = this.serverUrl + "AdminRegistration";
            try
            {
                personalInfo.password = EncodePassword(personalInfo.password);
                string jsonString = JsonConvert.SerializeObject(personalInfo);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync(serverUrl, sendThis);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return await ListAllWorkers();
        }
        //Asking the server for all the workers
        public async Task<List<jsonPersonalInfo>> ListAllWorkers()
        {
            List<jsonPersonalInfo> workers = new List<jsonPersonalInfo>();
            try
            {
                string serverUrl = this.serverUrl + "ListAllWorkers";
                HttpResponseMessage response = await client.GetAsync(serverUrl);
                string stringResult = await response.Content.ReadAsStringAsync();
                workers = JsonConvert.DeserializeObject<List<jsonPersonalInfo>>(stringResult);
                return workers;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return workers;
            }
            
        }
        //Deleting a worker based on it's id
        public async Task<List<jsonPersonalInfo>> DeleteWorker(int id)
        {
            try
            {
                string serverUrl = this.serverUrl + "DeleteWorker/" + id;
                HttpResponseMessage response = await client.DeleteAsync(serverUrl);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return await ListAllWorkers();
        }
        //Updating a worker based on it's id
        public async Task<List<jsonPersonalInfo>> UpdateWorker(jsonPersonalInfo personalInfo)
        {
            try
            {
                string serverUrl = this.serverUrl + "UpdateWorker/" + personalInfo.id;
                personalInfo.password = EncodePassword(personalInfo.password);
                string jsonString = JsonConvert.SerializeObject(personalInfo);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PutAsync(serverUrl, sendThis);
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return await ListAllWorkers();
        }
        //Sending a login request to the server
        public async Task<bool> Login(string username, string password)
        {
            string serverUrl = this.serverUrl + "AdminLogin";
            
            try
            {
                var jsonData = new
                {
                    loginNev = username,
                    loginPassword = EncodePassword(password)
                };
                string jsonString = JsonConvert.SerializeObject(jsonData);
                HttpContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync(serverUrl, sendThis);
                
                string stringResult = await response.Content.ReadAsStringAsync();
                string message = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).message;
                MessageBox.Show(message);

                Token.role= JsonConvert.DeserializeObject<jsonResponesData>(stringResult).role;
                

                Token.token = JsonConvert.DeserializeObject<jsonResponesData>(stringResult).token;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer__"+ Token.token);
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
