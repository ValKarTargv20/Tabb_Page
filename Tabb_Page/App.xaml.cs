using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabb_Page
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "project.db";
        public const string IDATABASE_NAME = "idea.db";
        public static RepositoryDB database;
        public static IdeaRepository idatabase;
        public static RepositoryDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new RepositoryDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public static IdeaRepository IDatabase
        {
            get
            {
                if(idatabase== null)
                {
                    idatabase = new IdeaRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return idatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
