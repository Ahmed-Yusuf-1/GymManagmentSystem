namespace GymManagmentSystem;

public partial class MemberPage : ContentPage
{
	public MemberPage()
	{
		InitializeComponent();
	}
    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Add Member", "Member has been added successfully!", "OK");
    }

    private async void OnViewMembersClicked(object sender, EventArgs e)
    {
        await DisplayAlert("View", "Viewed Members", "OK");
    }
}