using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class AddTrainerPage : ContentPage
{
    public AddTrainerPage()
    {
        InitializeComponent();
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

        // Add to the database
        await DatabaseService.AddTrainerAsync(newTrainer);

        // Navigate back to TrainerPage
        await Navigation.PopAsync();
    }
}
