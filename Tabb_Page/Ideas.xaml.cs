using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabb_Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ideas : ContentPage
    {

        public Ideas()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ideasList.ItemsSource = App.IDatabase.GetItems();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Idea selectedIdea = (Idea)e.SelectedItem;
            DBIdeaPage ideaPage = new DBIdeaPage();
            ideaPage.BindingContext = selectedIdea;
            await Navigation.PushAsync(ideaPage);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Idea ideas = new Idea();
            DBIdeaPage ideaPage = new DBIdeaPage();
            ideaPage.BindingContext = ideas;
            await Navigation.PushAsync(ideaPage);
        }
    }
}