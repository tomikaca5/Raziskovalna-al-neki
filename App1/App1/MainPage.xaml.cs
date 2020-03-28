using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace App1
{
    public partial class MainPage : ContentPage
    {
        bool pressed = false;
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Orientacija po Velenju";
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            location();
        }

        async void location()
        {
            while (pressed == false)
            {
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {
                        label1.Text = $"Latitude: { location.Latitude}, Longitude: { location.Longitude}";
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    Content = new StackLayout
                    {
                        Children = {
                        new Label { Text = $"{fnsEx}" },
                        }
                    };
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    Content = new StackLayout
                    {
                        Children = {
                        new Label { Text = $"{fneEx}" },
                        }
                    };
                }
                catch (PermissionException pEx)
                {
                    Content = new StackLayout
                    {
                        Children = {
                        new Label { Text = $"{pEx}" },
                        }
                    };
                }
                catch (Exception ex)
                {
                    Content = new StackLayout
                    {
                        Children = {
                        new Label { Text = $"{ex}" },
                        }
                    };
                }
            }
        }
        async private void chooselokacija(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());

            while (pressed == false)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Location lok = new Location(App.latitude, App.longitude);

                    if (App.latitude != 0 && App.longitude != 0)
                    {
                        double distance = Location.CalculateDistance(location, lok, DistanceUnits.Kilometers);
                        label2.Text = $"Med tabo in izbrano točko je: {distance}";
                    }
                }
            }
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            pressed = true;
            await Navigation.PushAsync(new Page2());
        }
    }
}

