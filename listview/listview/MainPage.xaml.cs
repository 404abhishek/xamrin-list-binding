using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace listview
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        class ProductData
        {
            public string Title { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string Image { get; set; }
            public RatingData Rating { get; set; }
        }

        class RatingData
        {
            public double Rate { get; set; }
            public int Count { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();
         
           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
           
            string id = ((Button)sender).BindingContext as string;
            var response = client.GetAsync("https://fakestoreapi.com/products/" + id).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            JObject json = JObject.Parse(result);
           string val=  JsonConvert.SerializeObject(json);
           
            //ProductData product = JsonSerializer.Deserialize<ProductData>(json.ToObject());
            var resultq = await this.DisplayAlert("Alert!", "Do you really want to buy" + "This product"+" ?", "Yes", "No");

            if (resultq)
            {
                //user wants to exit
                //Terminate application
            }
            else
            {
                //Dont do anything
            }
        }
    }
}
