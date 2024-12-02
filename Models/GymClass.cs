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
    internal class GymClass
    {
    }
}
