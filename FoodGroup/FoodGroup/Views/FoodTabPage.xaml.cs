using FoodGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodGroup.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodTabPage : ContentPage {

        private List<Resturent> _foodList;

        public FoodTabPage(string categoryName, List<Resturent> foodList) {
            InitializeComponent();

            Title = categoryName;
            mealsListView.ItemsSource = foodList;

            _foodList = foodList;
        }

        private void Search(object sender, EventArgs e) {

            stackLayoutShowHide.IsVisible = !stackLayoutShowHide.IsVisible;
        }

        private void searchChanged(object sender, TextChangedEventArgs e) {

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                mealsListView.ItemsSource = _foodList;
            else
                mealsListView.ItemsSource = _foodList.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));

        }
    }
}