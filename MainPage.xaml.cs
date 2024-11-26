namespace GymManagmentSystem
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        public abstract class  Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string ContactInfo { get; set; }

            public abstract string GetDetails();
        }

        public class  GymMember : Person
        {
            public string MembershipPlan { get; set; }
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
            public string Specialization { get; set; }
            public bool Availability { get; set; }

            public override string GetDetails()
            {
                return $"Trainer: {Name}, Specialization: {Specialization}, Availability: {Availability}";
            }

            public void AssignMember()
            {
                /// Assign a member to the trainer
            }
            public void ScheduleTraining()
            {
                // Schedule a training session
            }
        }
        public class MembershipPlan
        {
            public string PlanName { get; set; }
            public int Duration { get; set; } // in months
            public decimal Price { get; set; }
        }

        public class GymEquipment
        {
            public string EquipmentName { get; set; }
            public int Quantity { get; set; }

            public void BookEquipment(int memberId) { /* Code to book */ }
        }

        public class Booking
        {
            public int BookingID { get; set; }
            public int MemberID { get; set; }
            public int TrainerID { get; set; }
            public DateTime Date { get; set; }

            public void CreateBooking() { /* Code to create */ }
            public void CancelBooking() { /* Code to cancel */ }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
