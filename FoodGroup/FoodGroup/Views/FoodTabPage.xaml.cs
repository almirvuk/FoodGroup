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

        public FoodTabPage(string categoryName, List<Resturent> foodList) {
            InitializeComponent();

            Title = categoryName;
            mealsListView.ItemsSource = foodList;
        }


    }
}