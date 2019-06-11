using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TaskApp.Models;
using Xamarin.Forms;

namespace TaskApp.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetAllTaskAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<int> SaveTaskAsync(TodoItem item)
        {

            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<TodoItem> GetItemAsync(int id)
        {
            return database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
