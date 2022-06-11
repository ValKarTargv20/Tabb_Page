using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabb_Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Current : ContentPage
    {
        public static RepositoryDB database;
        public List<Project> projects;
        Label list_lbl, note_lbl, url_lbl, row_lbl, prow_lbl, pname_lbl;
        Image img;
        Button cont_btn, back_btn, save_rows, row_mi_btn, row_pl_btn;
        ListView list;
        StackLayout st;
        int row;
        public int ind, ind2,ind3;
        string pName;
        public Current()
        {
            InitializeComponent();
            CurrentPageShow();
        }
        //protected override void OnAppearing()
        //{
        //    list.ItemsSource = App.Database.GetItems();
        //    base.OnAppearing();
        //}

        private void CurrentPageShow()
        {
            database = App.Database;

            list_lbl = new Label
            {
                Text = "Current Projects in work",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = App.Database.Projects,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding rowsBinding = new Binding { Path = "Rows", StringFormat = "Rows: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, rowsBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Project_pic");
                    return imageCell;
                })
            };
            list.ItemTapped += List_ItemTapped; ;
            this.Content = new StackLayout { Children = { list_lbl, list } };
        }

        public void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Project selectedProject = e.Item as Project;
            if (selectedProject != null)
            {
                list_lbl.Text = selectedProject.Name;
                
                int ind = selectedProject.Rows;
                cont_btn = new Button
                { 
                    Text = "Continue project",
                    TextColor = Color.Black,
                    BackgroundColor = Color.Cyan,
                    HeightRequest = 50,
                }; cont_btn.Clicked += Cont_btn_Clicked;
                Button back_btn = new Button 
                {
                    Text = "Back",
                    TextColor = Color.Black,
                    BackgroundColor = Color.Cyan,
                    WidthRequest = 50,
                    HeightRequest = 50,

                };
                back_btn.Clicked += Back_btn_Clicked;
                img = new Image();
                img.Source = selectedProject.Project_pic;
                note_lbl = new Label();
                note_lbl.Text = "Notes: " + selectedProject.Notes;
                url_lbl = new Label();
                url_lbl.Text = "Project link: " + selectedProject.Pattern_url;
                row_lbl = new Label();
                row_lbl.Text = "Rows: " + selectedProject.Rows;
                ind2 = selectedProject.Rows;
                ind3 = selectedProject.Rows;
                pName = selectedProject.Name;
                this.Content = new StackLayout { Children = { list_lbl, img, note_lbl, url_lbl, row_lbl, cont_btn, back_btn } };
            }
        }

        private void Back_btn_Clicked(object sender, EventArgs e)
        {
            CurrentPageShow();
        }

        private void Cont_btn_Clicked(object sender, EventArgs e)
        {
            
            save_rows = new Button
            {
                Text = "Save rows",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                WidthRequest = 50,
                HeightRequest = 50,
            };
            save_rows.Clicked += Save_rows_Clicked;
            back_btn = new Button 
            { 
                Text = "Back", 
                TextColor= Color.Black, 
                BackgroundColor=Color.Cyan,
                WidthRequest = 50,
                HeightRequest = 50
            };
            pname_lbl = new Label()
            {
                Text = pName,
                FontSize=20,
                BackgroundColor = Color.Cyan,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HeightRequest = 50
            };
            prow_lbl = new Label()
            {
                Text = ind2.ToString(),
                BackgroundColor = Color.Cyan,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HeightRequest = 50
            };
            
            row_pl_btn = new Button
            {
                Text = "+",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                WidthRequest = 50,
                HeightRequest = 50
            };
            row_pl_btn.Clicked += Row_btn_Clicked;
            row_mi_btn = new Button
            {
                Text = "-",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                WidthRequest = 50,
                HeightRequest = 50
            };
            row_mi_btn.Clicked += Row_btn_Clicked;
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { pname_lbl, prow_lbl, row_pl_btn, row_mi_btn, save_rows, back_btn }
            };
            Content = st;

            back_btn.Clicked += Back_btn_Clicked;
        }

        private void Row_btn_Clicked(object sender, EventArgs e)
        {
            if(sender== row_pl_btn)
            {
                int dd = new int();
                dd = ind3 + 1;
                ind3 = dd;
                ind2 = dd;
                prow_lbl.Text = dd.ToString();
            }
            else if (sender == row_mi_btn)
            {
                int ff = new int();
                ff = ind3 - 1;
                ind3 = ff;
                ind2 = ff;
                prow_lbl.Text = ff.ToString();
            }
            
        }

        private void Save_rows_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}