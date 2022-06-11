using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Java.Util.Jar.Attributes;

namespace Tabb_Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        Image project, pattern, img;
        TableView tableView;
        public string pattern_pic, project_pic;
        public static RepositoryDB database;
        StackLayout btn, st;
        EntryCell name, notes, pattern_url, rows;
        Button add_btn, getProject, getPattern;
        public List<Project> projects;
        public Add()
        {
            InitializeComponent();
            database = App.Database;
            add_btn = new Button 
            { 
                Text = "Save to projects",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                CornerRadius = 20
            }; 
            add_btn.Clicked += Add_btn_Clicked;
            getProject = new Button 
            { 
                Text = "Add project's picture",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                CornerRadius = 20
            }; 
            getProject.Clicked += GetProject_Clicked;
            getPattern = new Button 
            { 
                Text = "Add pattern's picture",
                TextColor = Color.Black,
                BackgroundColor = Color.Cyan,
                CornerRadius = 20
            }; 
            getPattern.Clicked += GetPattern_Clicked;
            btn = new StackLayout
            {
                Children = { getProject, getPattern },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            name = new EntryCell
            {
                Label = "Project name:",
                Placeholder = "Entry your peoject name"
            };
            notes = new EntryCell
            {
                Label = "Notes",
                Placeholder = "You can enter here pattern and tools"
            };
            pattern_url = new EntryCell
            {
                Label = "Pattern URL:",
                Placeholder = "Enter Pattern URL"
            };
            rows = new EntryCell
            {
                Label = "Rows:",
                Placeholder = "0"
            };
            st = new StackLayout
            {
                Children = { add_btn },
                Orientation = StackOrientation.Horizontal
            };
            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("New project creating")
                {
                    new TableSection("Main:") { name },
                    new TableSection("Project Data:")
                    {
                        notes,
                        pattern_url,
                        rows
                    },
                    new TableSection { new ViewCell() { View=btn} },
                    new TableSection { new ViewCell() {View= st } }
                }

            };
            Content = tableView;
        }


        async void GetPattern_Clicked(object sender, EventArgs e)
        {
            img = new Image();
            var photo = await MediaPicker.PickPhotoAsync();
            pattern.Source = ImageSource.FromFile(photo.FullPath);
            string p = photo.FullPath.ToString();
            pattern_pic = p;
        }

        async void GetProject_Clicked(object sender, EventArgs e)
        {
            project = new Image();
            var photo = await MediaPicker.PickPhotoAsync();
            project.Source = ImageSource.FromFile(photo.FullPath);
            string p2 = photo.FullPath.ToString();
            project_pic = p2;
        }

        private async void Add_btn_Clicked(object sender, EventArgs e)
        {
            database = App.Database;
            var project = (Project)BindingContext;
            foreach (Project item in projects.ToList())
            {
                if (item.Name != name.Text)
                {
                    projects.Add(new Project { Name = name.Text, Project_pic = project_pic.ToString(), Pattern_pic = "Add.jpg", Notes = notes.Text, Pattern_url = pattern_url.Text, Rows = Convert.ToInt32(rows.Text) });
                }
                else if (item.Name == name.Text)
                {
                    await DisplayAlert("Attention", "Please enter new name", "OK");
                }
            }
            App.Database.SaveItem(project);
        }
    }
}