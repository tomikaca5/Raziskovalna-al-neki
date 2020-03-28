using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage

    {
        public Page1()
        {
            InitializeComponent();
        }

        async private void Maap_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
                maap.Pins.Clear();
                maap.MapElements.Clear();
                Pin pin = new Pin
                {
                    Label = "Izbrana lokacija",
                    Address = "void",
                    Type = PinType.SearchResult,
                    Position = new Position(e.Position.Latitude, e.Position.Longitude)
                };
                maap.Pins.Add(pin);

                App.latitude = e.Position.Latitude;
                App.longitude = e.Position.Longitude;

                Polyline polyline = new Polyline
                {
                    StrokeColor = Color.Blue,
                    StrokeWidth = 12,
                    Geopath =
                    {
                        new Position(location.Latitude, location.Longitude),
                        new Position(App.latitude, App.longitude)
                        
                    }
                };

                // add the polyline to the map's MapElements collection
                maap.MapElements.Add(polyline);
                
        }


    }
}