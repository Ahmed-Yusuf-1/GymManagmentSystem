using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        public abstract string GetDetails();
    }

    public class GymMember : Person
    {
        public string MembershipPlan { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }

        public override string GetDetails()
        {
            return $"Member: {Name}, Plan: {MembershipPlan}, Join Date: {JoinDate.ToShortDateString()}";
        }

        public void Register()
        {
            // Register the member
        }

        public void UpdateInfo()
        {
            // Update the member info
        }
    }

    public class Trainer : Person
    {
        public string Specialization { get; set; } = string.Empty;
        public bool Availability { get; set; }

        public override string GetDetails()
        {
            return $"Trainer: {Name}, Specialization: {Specialization}, Availability: {Availability}";
        }

        public void AssignMember()
        {
            // Assign a member to the trainer
        }
        public void ScheduleTraining()
        {
            // Schedule a training session
        }
    }

    public class MembershipPlan
    {
        public string PlanName { get; set; } = string.Empty;
        public int Duration { get; set; } // in months
        public decimal Price { get; set; }
    }

    public class GymEquipment
    {
        public string EquipmentName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public void BookEquipment(int memberId) { /* Code to book */ }
    }

    public class Booking
    {
        public int BookingID { get; set; }
        public string MemberName { get; set; }
        public string TrainerName { get; set; }
        public DateTime Date { get; set; }

        public string BookingDetails => $"{Date.ToShortDateString()} with {TrainerName}";
        public void CreateBooking() { /* Code to create */ }
        public void CancelBooking() { /* Code to cancel */ }
    }
    internal class Classes
    {
    }
}
