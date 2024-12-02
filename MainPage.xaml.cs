namespace GymManagmentSystem
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        public abstract class Person
        {
            public int ID { get; set; }
            public string Name { get; set; } = string.Empty;
            public string ContactInfo { get; set; } = string.Empty;

            public abstract string GetDetails();
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
            public int MemberID { get; set; }
            public int TrainerID { get; set; }
            public DateTime Date { get; set; }

            public void CreateBooking() { /* Code to create */ }
            public void CancelBooking() { /* Code to cancel */ }
        }


        private async void OnMembersClicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("///MemberPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation failed: {ex.Message}");
            }
        }
        private async void OnTrainersClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///TrainerPage");
        }

        private async void OnBookingsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///BookingPage");
        }

        private async void OnEquipmentClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///EquipmentPage");
        }

        
    }
}
