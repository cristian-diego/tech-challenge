using SQLite;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data
{
    public class DatabaseConnection
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseConnection(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeDatabase().Wait();
        }

        private async Task InitializeDatabase()
        {
            await _database.CreateTableAsync<Contact>();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return _database;
        }
    }
}