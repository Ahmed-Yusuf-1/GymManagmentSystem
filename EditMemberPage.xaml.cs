using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class EditMemberPage : ContentPage
{
    private GymMember _memberToEdit;

    public EditMemberPage(GymMember member)
    {
        InitializeComponent();
        _memberToEdit = member;

        // Pre-fill the entries with existing member data
        NameEntry.Text = _memberToEdit.Name;
        PlanEntry.Text = _memberToEdit.MembershipPlan;
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        // Update the member's properties with the new values from the user
        _memberToEdit.Name = NameEntry.Text;
        _memberToEdit.MembershipPlan = PlanEntry.Text;


        // Call the update method in the database service
        await DatabaseService.UpdateMemberAsync(_memberToEdit);

        // Go back to MemberPage
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
