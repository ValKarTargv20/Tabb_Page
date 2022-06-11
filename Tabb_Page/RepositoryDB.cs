using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tabb_Page
{
    public class RepositoryDB
    {
        SQLiteConnection database;
        private List<Project> projects;
        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }
        public RepositoryDB(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Project>();
            Projects = new List<Project>();

            Projects.Add(new Project { Name = "Cuccinelli Rombs", Project_pic = "CuccinelliRombProj.jpg", Pattern_pic = "CuccinelliRomb.jpg", Notes = "No", Pattern_url = "https://youtu.be/izhaSKEmUss", Rows = 5 });
            Projects.Add(new Project { Name = "Brown bag", Project_pic = "BrownBag.JPG", Pattern_pic = "No", Notes = "No", Pattern_url = "https://youtu.be/tSoC3Q4RlZ8", Rows = 8 });
            foreach(Project p in Projects)
            {
                database.Insert(p);
            }

        }
        public IEnumerable<Project> GetItems()
        {
            return database.Table<Project>().ToList();
        }
        public Project GetItem(int id)
        {
            return database.Get<Project>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Project>(id);
        }
        public int SaveItem(Project item)
        {
            return database.Insert(item);
        }
        /*if (item.Id != 0)
        {
            database.Update(item);
            return item.Id;
        }
        else
        {
            return database.Insert(item);
        }*/
    
    }
}
