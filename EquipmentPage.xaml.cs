using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class EquipmentPage : ContentPage
{
    private GymEquipment _selectedEquipment;

    public EquipmentPage()
    {
        InitializeComponent();
    }



    private async void OnAddEquipmentClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEquipmentPage());
    }

    public async void RefreshEquipmentList()
    {
        var equipmentFromDb = await DatabaseService.GetEquipmentAsync();
        EquipmentListView.ItemsSource = null;
        EquipmentListView.ItemsSource = equipmentFromDb;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshEquipmentList();
    }
    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
    // Handle selecting an equipment item
    private void OnEquipmentTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is GymEquipment tappedEquipment)
        {
            _selectedEquipment = tappedEquipment;
        }
    }

    // Rent Equipment button handler
    private async void OnRentEquipmentClicked(object sender, EventArgs e)
    {
        if (_selectedEquipment != null && _selectedEquipment.Quantity > 0)
        {
            // Reduce quantity and update DB
            _selectedEquipment.BookEquipment(0); // memberId 0 for demo
            await DatabaseService.UpdateEquipmentAsync(_selectedEquipment);
            RefreshEquipmentList();
        }
        else
        {
            await DisplayAlert("Error", "No equipment selected or quantity is zero.", "OK");
        }
    }
    private async void OnEditEquipmentClicked(object sender, EventArgs e)
    {
        if (_selectedEquipment != null)
        {
            // Navigate to an EditEquipmentPage, passing the selected equipment
            await Navigation.PushAsync(new EditEquipmentPage(_selectedEquipment));
        }
        else
        {
            await DisplayAlert("Error", "Please select equipment to return/edit.", "OK");
        }
    }
}