using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class EquipmentPage : ContentPage
{
    private List<GymEquipment> equipmentList = new List<GymEquipment>();

    public EquipmentPage()
    {
        InitializeComponent();
    }

    private async void OnAddEquipmentClicked(object sender, EventArgs e)
    {
        // Navigate to AddEquipmentPage and pass the equipment list
        await Navigation.PushAsync(new AddEquipmentPage(equipmentList));
    }

    public void RefreshEquipmentList()
    {
        EquipmentListView.ItemsSource = null; // Clear the current source
        EquipmentListView.ItemsSource = equipmentList; // Reassign the updated list
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshEquipmentList();
    }
}