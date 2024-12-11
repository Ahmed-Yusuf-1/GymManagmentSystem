using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class EditEquipmentPage : ContentPage
{
    private GymEquipment _equipmentToEdit;

    public EditEquipmentPage(GymEquipment equipment)
    {
        InitializeComponent();
        _equipmentToEdit = equipment;

        EquipmentNameEntry.Text = _equipmentToEdit.EquipmentName;
        QuantityEntry.Text = _equipmentToEdit.Quantity.ToString();
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(EquipmentNameEntry.Text) ||
            string.IsNullOrWhiteSpace(QuantityEntry.Text) ||
            !int.TryParse(QuantityEntry.Text, out int newQuantity) ||
            newQuantity < 0)
        {
            await DisplayAlert("Error", "Please enter valid equipment details.", "OK");
            return;
        }

        _equipmentToEdit.EquipmentName = EquipmentNameEntry.Text;
        _equipmentToEdit.Quantity = newQuantity;

        await DatabaseService.UpdateEquipmentAsync(_equipmentToEdit);

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
