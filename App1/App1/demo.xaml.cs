using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using SQLite;
using System.IO;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class demo : ContentPage
    {
        int pot_id = 1;


        List<koordinate> podatki = new List<koordinate>();

        List<tocke> t_list = new List<tocke>();

        Database db = new Database();

        bool na_tocki;

        bool played;

        public demo()
        {
            InitializeComponent();

            mapdemo.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(46.358826, 15.118164), Distance.FromKilometers(1)));

            Narisi_pot();
        }
        private async void Narisi_pot()
        {
            podatki = await db.GetkoordinatepotAsync(pot_id);

            for (int i = 0; i < (podatki.Count - 1); i++)
            {
                koordinate a = podatki[i];
                double longic = a.longtitude;
                double lant = a.latitude;

                int o = i + 1;
                koordinate b = podatki[o];
                double longic2 = b.longtitude;
                double lant2 = b.latitude;

                Polyline polyline = new Polyline
                {
                    StrokeColor = Color.DodgerBlue,
                    StrokeWidth = 12,
                    Geopath =
                    {
                        new Position(lant,longic),
                        new Position(lant2,longic2)
                    }
                };
                mapdemo.MapElements.Add(polyline);
            }
        }

        async void pot()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            Location manj = new Location();
            Location vec = new Location();

            t_list = await db.GettockepotAsync(pot_id);

            foreach (tocke tock in t_list)
            {
                na_tocki = false;

                manj = new Location(tock.majn_latitude, tock.majn_longtitude);
                vec = new Location(tock.vec_latitude, tock.vec_longtitude);
                Pin pin = new Pin
                {
                    Label = tock.ime,
                    Address = tock.opis,
                    Type = PinType.Place,
                    Position = new Position(tock.latitude, tock.longtitude)
                };
                mapdemo.Pins.Add(pin);

                while (na_tocki == false)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                    {
                        player.Load(tock.audio);
                        player.Play();

                        na_tocki = true;
                    }
                    else
                    {
                        if (played == false)
                        {
                            player.Load("not.mp3");
                            player.Play();

                            played = true;
                        }
                    }
                }
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            played = false;
            mapdemo.Pins.Clear();
            pot();
        }
    }
}