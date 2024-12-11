using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using GymManagmentSystem.Models;

namespace GymManagmentSystem.Services
{
    public class DatabaseService
    {
        private static SQLiteAsyncConnection _database;

        // Lazy initialization of the DB connection
        public static async Task InitializeAsync()
        {
            if (_database != null)
                return;

            // Determine the path for the database file
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "GYM.db3");

            _database = new SQLiteAsyncConnection(dbPath);
            // Create tables if they don't already exist
            await _database.CreateTableAsync<GymMember>();

            // Check if the table is empty
            var existingMembers = await _database.Table<GymMember>().FirstOrDefaultAsync();
            if (existingMembers == null)
            {
                // Table empty, seed some data
                var defaultMembers = new List<GymMember>
        {
            new GymMember
            {
                Name = "John Doe",
                MembershipPlan = "Basic",
            },
            new GymMember
            {
                Name = "Jane Smith",
                MembershipPlan = "Premium",
            },
        };
                await _database.InsertAllAsync(defaultMembers);
            }
        }

        public static async Task<List<GymMember>> GetMembersAsync()
        {
            return await _database.Table<GymMember>().ToListAsync();
        }

        public static async Task<int> AddMemberAsync(GymMember member)
        {
            return await _database.InsertAsync(member);
        }
        public static async Task<int> UpdateMemberAsync(GymMember member)
        {
            return await _database.UpdateAsync(member);
        }


        public static async Task<int> ClearAllMembersAsync()
        {
            return await _database.DeleteAllAsync<GymMember>();
        }
    }
}
