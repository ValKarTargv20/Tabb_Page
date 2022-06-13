using SQLite;
using System.Collections.Generic;

namespace Tabb_Page
{
    public class IdeaRepository
    {
        SQLiteConnection idatabase;
        public List<Idea> ideas;
        public IdeaRepository(string databasePath)
        {
            idatabase = new SQLiteConnection(databasePath);
            idatabase.CreateTable<Idea>();
        }
        public IEnumerable<Idea> GetItems()
        {
            return idatabase.Table<Idea>().ToList();
        }
        public Idea GetItem(int id)
        {
            return idatabase.Get<Idea>(id);
        }
        public int DeleteItem (int id)
        {
            return idatabase.Delete<Idea>(id);
        }
        public int SaveItem(Idea item)
        {
            if(item.Id != 0)
            {
                idatabase.Update(item);
                return item.Id;
            }
            else
            {
                return idatabase.Insert(item);
            }
        }
    }
}
