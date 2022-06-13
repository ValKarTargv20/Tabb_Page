using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tabb_Page
{
    public class RepositoryDB
    {
        SQLiteConnection database;
        public List<Project> projects;
        public RepositoryDB(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Project>();
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
    
    }
}
