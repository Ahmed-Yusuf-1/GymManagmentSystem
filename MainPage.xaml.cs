namespace GymManagmentSystem
{

    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnTrainerTapped(object sender, EventArgs e)
        {
            var button = sender as Button;

            // Animate the button (scale effect)
            await button.ScaleTo(0.9, 100);
            await button.ScaleTo(1, 100);

            // Navigate to the appropriate page
            await Navigation.PushAsync(new TrainerPage());
        }

        private async void OnBookingTapped(object sender, EventArgs e)
        {
            var button = sender as Button;

            // Animate the button (scale effect)
            await button.ScaleTo(0.9, 100);
            await button.ScaleTo(1, 100);

            // Navigate to the appropriate page
            await Navigation.PushAsync(new BookingPage());
        }

        private async void OnEquipmentTapped(object sender, EventArgs e)
        {
            var button = sender as Button;

            // Animate the button (scale effect)
            await button.ScaleTo(0.9, 100);
            await button.ScaleTo(1, 100);

            // Navigate to the appropriate page
            await Navigation.PushAsync(new EquipmentPage());
        }
        private async void OnMembersTapped(object sender, EventArgs e)
        {
            var button = sender as Button;

            // Animate the button (scale effect)
            await button.ScaleTo(0.9, 100);
            await button.ScaleTo(1, 100);

            // Navigate to the appropriate page
            await Navigation.PushAsync(new MemberPage());
        }


    }
}
