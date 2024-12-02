using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class TrainerPage : ContentPage
{
    private List<Trainer> trainers = new List<Trainer>();
    public TrainerPage()
	{
		InitializeComponent();
	}
    private async void OnAddTrainerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTrainerPage(trainers));
    }

    public void RefreshTrainerList()
    {
        TrainerListView.ItemsSource = null; // Clear the current source
        TrainerListView.ItemsSource = trainers; // Reassign the updated list
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshTrainerList();
    }
}