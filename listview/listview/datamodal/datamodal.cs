using listview.modal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace listview.datamodal
{

    class datamodal
    {
        public ObservableCollection<product> name { get; set; }
        public  datamodal()
            {
            name = new ObservableCollection<product>();
           
            HttpClient client = new HttpClient();

            var response = client.GetAsync("https://fakestoreapi.com/products").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            List<JObject> jObjects = JsonConvert.DeserializeObject<List<JObject>>(result);
            foreach (var jObject in jObjects)
            {
                name.Add(new product() { id = jObject["id"].ToString(), title = jObject["title"].ToString(), category = jObject["category"].ToString(), price ="$"+jObject["price"].ToString(),image= jObject["image"].ToString() });
            }
        }
        private async Task postAsync()
        {
            
        }
    }
}
