using System;
using System.Collections.Generic;
using System.Net.Http;
using E_Shop_Xamarin;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using E_Shop_Xamarin.Models;
using System.Net.Http.Headers;

namespace E_Shop_Xamarin.ClientManagers
{
    public class UserManger
    {
        HttpClient client;
      
        public UserManger()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.ServiceURL);
        }

        public async Task<int> AddUser(string username)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("", username.ToString())
            });   
            var resp =  client.PostAsync($"api/user?{Constants.AzureVersion}", content).Result;
            if (resp.IsSuccessStatusCode)
            {
                var contents = await resp.Content.ReadAsStringAsync();
                return int.Parse(contents);
            }
            return 0;
        }

        public bool submitorder(int userid, List<Cart> lstCart)
        {
            client.DefaultRequestHeaders.Clear();
            var jsonObj = JsonConvert.SerializeObject(lstCart);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resp = client.PostAsync($"api/user?id={userid}&{Constants.AzureVersion}", byteContent).Result;
            if (resp.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
