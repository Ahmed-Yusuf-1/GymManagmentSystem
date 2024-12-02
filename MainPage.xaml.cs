namespace GymManagmentSystem
{

    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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
