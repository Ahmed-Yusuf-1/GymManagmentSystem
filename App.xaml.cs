using GymManagmentSystem.Services;

namespace GymManagmentSystem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Initialize DB here
            Task.Run(async () => await DatabaseService.InitializeAsync()).Wait();

            MainPage = new AppShell();
        }
    }
}
