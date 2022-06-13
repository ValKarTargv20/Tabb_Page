using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tabb_Page
{
    [Table("Idea")]
    public class Idea
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Photo { get; set; }
        public string IName { get; set; }
        public string INote { get; set; }
    }
}
