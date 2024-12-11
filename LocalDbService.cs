using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GymManagmentSystem.Models;

namespace GymManagmentSystem.Data
{
    public class LocalDbService
    {
        private readonly SQLiteAsyncConnection _database;

        public LocalDbService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "gym_management.db");
            _database = new SQLiteAsyncConnection(dbPath);

            // Ensure the tables are created
            InitializeDatabase().Wait();
        }

        private async Task InitializeDatabase()
        {
            await _database.CreateTableAsync<GymMember>();
            await _database.CreateTableAsync<Trainer>();
            await _database.CreateTableAsync<Booking>();
            await _database.CreateTableAsync<GymEquipment>();
        }

        // Method to fetch all members
        public Task<List<GymMember>> GetAllMembersAsync()
        {
            return _database.Table<GymMember>().ToListAsync();
        }

        // Method to add a new member
        public Task<int> AddMemberAsync(GymMember member)
        {
            return _database.InsertAsync(member);
        }
    }
}
