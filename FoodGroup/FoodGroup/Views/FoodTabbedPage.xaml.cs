using FoodGroup.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodGroup.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodTabbedPage : TabbedPage {

        List<Resturent> ResturentList;

        public FoodTabbedPage() {

            InitializeComponent();

            GetJSON();

            
        }

        public async void GetJSON() {

            var client = new System.Net.Http.HttpClient();

            // REPLACE THIS CODE WITH YOUR API CALL
            var response = await client.GetAsync("https://api.myjson.com/bins/1ctifb");

            string contactsJson = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode) {

               
                var list = JsonConvert.DeserializeObject<ResturentObject>(contactsJson);

                ResturentList = new List<Resturent>(list.Resturent);


                List<string> allCategories = ResturentList.Select(x => x.Category).ToList();

                allCategories = allCategories.Distinct().ToList();

                foreach (var category in allCategories) {
                    Children.Add(new FoodTabPage(category, ResturentList.Where(x => x.Category == category).ToList()));
                }
            } else {
                var textReader = new JsonTextReader(new StringReader(contactsJson));
                dynamic responseJson = new JsonSerializer().Deserialize(textReader);
                contactsJson = "Deserialized JSON error message: " + responseJson.Message;
                await DisplayAlert("fail", "no Network Is Available.", "Ok");
            }
        }
    }
}