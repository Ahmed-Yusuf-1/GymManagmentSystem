using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class TrainerPage : ContentPage
{
    private Trainer? _selectedTrainer;
    public TrainerPage()
	{
		InitializeComponent();
	}
    private async void OnAddTrainerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTrainerPage());
    }

    private void OnTrainerTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Trainer tappedTrainer)
        {
            _selectedTrainer = tappedTrainer;
        }
    }

    private async void OnRemoveTrainerClicked(object sender, EventArgs e)
    {
        if (_selectedTrainer != null)
        {
            bool confirm = await DisplayAlert("Confirmation", "Are you sure you want to remove this trainer?", "Yes", "No");
            if (confirm)
            {
                await DatabaseService.RemoveTrainerAsync(_selectedTrainer);
                RefreshTrainerList();
            }
        }
        else
        {
            await DisplayAlert("Error", "Please select a trainer to remove.", "OK");
        }
    }

    public async void RefreshTrainerList()
    {
        var trainersFromDb = await DatabaseService.GetTrainersAsync();
        TrainerListView.ItemsSource = null;
        TrainerListView.ItemsSource = trainersFromDb;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshTrainerList();
    }
    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}