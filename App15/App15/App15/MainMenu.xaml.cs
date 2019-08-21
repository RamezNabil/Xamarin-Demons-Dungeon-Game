using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App15
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenu : ContentPage
	{
		public MainMenu ()
		{
			InitializeComponent ();
		}

        private void Tutorial_Clicked(object sender, EventArgs e)
        {
            helpgrid.IsVisible = true;
            Menu.IsVisible = false;
        }

        private async void PlayBTN_Clicked(object sender, EventArgs e)
        {
            PlayBTN.InputTransparent = true;
            Tutorial.InputTransparent = true;
            loading.IsVisible = true;
            l1.IsVisible = true;
            await Task.Delay(500);
            l2.IsVisible = true;
            await Task.Delay(500);
            l3.IsVisible = true;
            await Task.Delay(500);
            await Navigation.PushAsync(new MainPage());
            loading.IsVisible = false;
            l1.IsVisible = false;
            l2.IsVisible = false;
            l3.IsVisible = false;
            PlayBTN.InputTransparent = false;
            Tutorial.InputTransparent = false;
        }

        private void BackBTN_Clicked(object sender, EventArgs e)
        {
            helpgrid.IsVisible = false;
            Menu.IsVisible = true;
        }
    }
}