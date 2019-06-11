
using SQLite;

namespace TaskApp.Models
{
    public class TodoItem 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Task { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

    }
}