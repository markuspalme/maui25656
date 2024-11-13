using TestApp.Maui.ViewModels;

namespace TestApp.Maui;

public partial class TimeRegistrationPage : ContentPage
{
	private readonly TimeRegistrationViewModel viewModel;

	public TimeRegistrationPage(TimeRegistrationViewModel viewModel)
	{
		this.viewModel = viewModel;
		InitializeComponent();
		BindingContext = viewModel;
	}
}