using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            this.Title = "Zemljevidi";
            NavigationPage.SetHasBackButton(this, false);
        }

      async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new demo());
        }

       async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new jezero());
        }

       async private void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}