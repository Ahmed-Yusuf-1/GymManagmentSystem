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
            await _database.CreateTableAsync<Trainer>();
            await _database.CreateTableAsync<GymEquipment>();
            await _database.CreateTableAsync<Booking>();

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

        public static async Task<List<Trainer>> GetTrainersAsync()
        {
            return await _database.Table<Trainer>().ToListAsync();
        }

        public static async Task<int> AddTrainerAsync(Trainer trainer)
        {
            return await _database.InsertAsync(trainer);
        }

        public static async Task<int> RemoveTrainerAsync(Trainer trainer)
        {
            return await _database.DeleteAsync(trainer);
        }

        // Equipment Methods
        public static async Task<List<GymEquipment>> GetEquipmentAsync()
        {
            return await _database.Table<GymEquipment>().ToListAsync();
        }

        public static async Task<int> AddEquipmentAsync(GymEquipment equipment)
        {
            return await _database.InsertAsync(equipment);
        }

        public static async Task<int> UpdateEquipmentAsync(GymEquipment equipment)
        {
            return await _database.UpdateAsync(equipment);
        }

        // Booking Methods
        public static async Task<List<Booking>> GetBookingsAsync()
        {
            return await _database.Table<Booking>().ToListAsync();
        }

        public static async Task<int> AddBookingAsync(Booking booking)
        {
            return await _database.InsertAsync(booking);
        }
        public static async Task<int> UpdateBookingAsync(Booking booking)
        {
            return await _database.UpdateAsync(booking);
        }

        public static async Task<int> RemoveBookingAsync(Booking booking)
        {
            return await _database.DeleteAsync(booking);
        }
    }
}
