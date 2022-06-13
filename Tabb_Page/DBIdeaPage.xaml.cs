using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabb_Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBIdeaPage : ContentPage
    {
        //public static IdeaRepository idatabase;
        //public List<Idea> ideas;
        Image img;
        public DBIdeaPage()
        {
            InitializeComponent();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            var idea = (Idea)BindingContext;
            if (!String.IsNullOrEmpty(idea.IName))
            {
                App.IDatabase.SaveItem(idea);
            }
            this.Navigation.PopAsync();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var idea = (Idea)BindingContext;
            App.IDatabase.DeleteItem(idea.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        async void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", ex.Message, "Ok");
            }

        }
        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Idea selectedIdea = (Idea)e.SelectedItem;
            DBIdeaPage ideaPage = new DBIdeaPage();
            ideaPage.BindingContext = selectedIdea;
            await Navigation.PushAsync(ideaPage);
        }
    }
}