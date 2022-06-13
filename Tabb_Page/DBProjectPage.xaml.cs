using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Linq;

namespace Tabb_Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBProjectPage : ContentPage
    {
        //public static RepositoryDB database;
        //public List<Project> projects;
        Image project_img, pattern_img;
        int plus, minus;

        public DBProjectPage()
        {
            InitializeComponent();
        }
        private void Delete_btn_Clicked(object sender, EventArgs e)
        {
            var project = (Project)BindingContext;
            App.Database.DeleteItem(project.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        private void Plus_btn_Clicked(object sender, EventArgs e)
        {
            var project = (Project)BindingContext;
            App.Database.GetItem(project.Rows);
            plus = project.Rows + 1;
            project.Rows = plus;
            App.Database.SaveItem(project);
        }
        private void Minus_btn_Clicked(object sender, EventArgs e)
        {
            var project = (Project)BindingContext;
            App.Database.GetItem(project.Rows);
            minus=project.Rows-1;
            project.Rows=minus;
            App.Database.SaveItem(project);
        }

        private void Save_rows_Clicked(object sender, EventArgs e)
        {
            var project = (Project)BindingContext;
            if (!String.IsNullOrEmpty(project.Name))
            {
                App.Database.SaveItem(project);
            }
            this.Navigation.PopAsync();
        }

    }
}