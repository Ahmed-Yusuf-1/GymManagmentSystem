using GymManagmentSystem.Models;   

namespace GymManagmentSystem;

public partial class AddEquipmentPage : ContentPage
{
    private List<GymEquipment> equipmentList;

    public AddEquipmentPage(List<GymEquipment> equipment)
    {
        InitializeComponent();
        equipmentList = equipment;
    }

    private async void OnAddEquipmentClicked(object sender, EventArgs e)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(EquipmentNameEntry.Text) || string.IsNullOrWhiteSpace(EquipmentQuantityEntry.Text))
        {
            await DisplayAlert("Error", "Please fill out all fields.", "OK");
            return;
        }

        if (!int.TryParse(EquipmentQuantityEntry.Text, out int quantity) || quantity <= 0)
        {
            await DisplayAlert("Error", "Please enter a valid quantity.", "OK");
            return;
        }

        // Add the new equipment
        var newEquipment = new GymEquipment
        {
            EquipmentName = EquipmentNameEntry.Text,
            Quantity = quantity
        };

        equipmentList.Add(newEquipment);

        // Navigate back to EquipmentPage
        await Navigation.PopAsync();
    }
    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}