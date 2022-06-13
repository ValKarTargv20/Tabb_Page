using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabb_Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Current : ContentPage
    {

        public Current()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            listProject.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Project selectedProject = (Project)e.SelectedItem;
            DBProjectPage projectPage = new DBProjectPage();
            projectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(projectPage);
        }
    }
}