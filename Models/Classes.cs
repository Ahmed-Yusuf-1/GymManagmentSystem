using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GymManagmentSystem.Models
{
    public abstract class Person
    {
        public int ID { get; set; }   // Unique identifier
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        public abstract string GetDetails();
    }

    public class GymMember : Person
    {
        [PrimaryKey, AutoIncrement]
        public new int ID { get; set; } 

        public string MembershipPlan { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }

        public override string GetDetails()
        {
            return $"Member: {Name}, Plan: {MembershipPlan}, Join Date: {JoinDate.ToShortDateString()}";
        }
    }

    public class Trainer : Person
    {
        [PrimaryKey, AutoIncrement]
        public new int ID { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public bool Availability { get; set; }

        public override string GetDetails()
        {
            return $"Trainer: {Name}, Specialization: {Specialization}, Availability: {Availability}";
        }
    }

    //public class MembershipPlan
  //  {
    //    [PrimaryKey, AutoIncrement]
    ////    public new int ID { get; set; }
    // //   public static string Text { get; internal set; }
    //    public string PlanName { get; set; } = string.Empty;
    //    public int Duration { get; set; } // in months
    //    public decimal Price { get; set; }
  //  }

    public class GymEquipment
    {
        [PrimaryKey, AutoIncrement]
        public new int ID { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public void BookEquipment(int memberId) 
        {
            
            if (Quantity > 0)
                Quantity -= 1;
        }
    }

    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public new int ID { get; set; }
        public int BookingID { get; set; }
        public string MemberName { get; set; }
        public string TrainerName { get; set; }
        public DateTime Date { get; set; }

        public string BookingDetails => $"{Date.ToShortDateString()} with {TrainerName}";
    }
    internal class Classes
    {
    }
}
