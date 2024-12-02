using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class AddTrainerPage : ContentPage
{
    private List<Trainer> trainers;

    public AddTrainerPage(List<Trainer> trainerList)
    {
        InitializeComponent();
        trainers = trainerList;
    }

    private async void OnAddTrainerClicked(object sender, EventArgs e)
    {
        // Create a new Trainer object
        var newTrainer = new Trainer
        {
            Name = NameEntry.Text,
            Specialization = SpecializationEntry.Text,
            Availability = true // Default availability
        };

        // Add to the list
        trainers.Add(newTrainer);

        // Navigate back to TrainerPage
        await Navigation.PopAsync();
    }
    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}