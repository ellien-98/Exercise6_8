namespace Exercise6_8_NET8;
using Exercise6_8_NET8.ViewModels;
using Microsoft.Maui.Controls;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e){
		var userChoice=e.CurrentSelection.FirstOrDefault() as Option;
		
		if(userChoice != null){
			var viewModel=BindingContext as OptionsViewModel;
			if(viewModel!=null){
				viewModel.SelectMenuOption.Execute(userChoice);
			}
			else{
				Console.WriteLine("viewModel is empty");
			}
			

			((CollectionView)sender).SelectedItem=null;
		}
		else{
			Console.WriteLine("ViewModel is not initialized.");
		}
	}
	
}

