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
        int st = 1;
        List<avtobusna> podatki = new List<avtobusna>();

        public demo()
        {
            InitializeComponent();

            mapdemo.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(46.358826, 15.118164), Distance.FromKilometers(1)));

            GetData();

            for (int i = 0; i < 28; i++)
            {
                avtobusna a = podatki[i];
                double longic = a.longtitude;
                double langic = a.langtitude;

                int o = i + 1;
                avtobusna b = podatki[o];
                double longic2 = b.longtitude;
                double langic2 = b.langtitude;

                Polyline polyline = new Polyline
                {
                    StrokeColor = Color.Blue,
                    StrokeWidth = 12,
                    Geopath =
                    {
                        new Position(langic,longic),
                        new Position(langic2,longic2)
                    }
                };
                mapdemo.MapElements.Add(polyline);
            }

        }
        private void  GetData()
        {
            var sqliteFilename = App.DatabaseFilename;
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            var db = new SQLiteConnection(path);

            podatki = db.Table<avtobusna>().ToList();
        }
        
        async void pot()
        {
            int i = 0;
            while (st < 7)
            {
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);



                    Location manj = new Location(46.358360, 15.117666);
                    Location vec = new Location(46.359089, 15.118819);
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

                    if (st == 1)
                    {
                        Pin pin = new Pin
                        {
                            Label = "Avtobusna postaja Velenje",
                            Address = "Agencija za prodajo avtobusnih vozovnic",
                            Type = PinType.Place,
                            Position = new Position(46.358679, 15.118278)
                        };
                        mapdemo.Pins.Add(pin);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player.Load("audio 1.mp3");
                            player.Play();
                            st++;
                        }
                        else
                        {
                            if (i == 0)
                            {
                                player.Load("not.mp3");
                                player.Play();
                                i++;
                            }
                        }
                    }
                    if (st == 2)
                    {
                        manj = new Location(46.358616, 15.116973);
                        vec = new Location(46.358741, 15.117332);
                        Pin pin2 = new Pin
                        {
                            Label = "Podhod",
                            Address = "Prečkanje ceste",
                            Type = PinType.Place,
                            Position = new Position(46.358628, 15.117002)
                        };
                        mapdemo.Pins.Add(pin2);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player.Load("audio 2.mp3");
                            player.Play();
                            st++;
                        }

                    }
                    if (st == 3)
                    {
                        manj = new Location(46.359251, 15.116284);
                        vec = new Location(46.359523, 15.116338);
                        Pin pin3 = new Pin
                        {
                            Label = "Center",
                            Address = "Center mesta Velenje",
                            Type = PinType.Place,
                            Position = new Position(46.359410, 15.116313)
                        };
                        mapdemo.Pins.Add(pin3);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player.Load("audio 3.mp3");
                            player.Play();
                            st++;
                        }

                    }
                    if (st == 4)
                    {
                        manj = new Location(46.359841, 15.115924);
                        vec = new Location(46.360372, 15.115993);
                        Pin pin4 = new Pin
                        {
                            Label = "Most",
                            Address = "Most za prečkanje Pake",
                            Type = PinType.Place,
                            Position = new Position(46.360379, 15.115757)
                        };
                        mapdemo.Pins.Add(pin4);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player.Load("audio 4.mp3");
                            player.Play();
                            st++;
                        }

                    }
                    if (st == 5)
                    {
                        manj = new Location(46.360633, 15.115053);
                        vec = new Location(46.360770, 15.115297);
                        Pin pin5 = new Pin
                        {
                            Label = "Park",
                            Address = "Park ob Ginaziji",
                            Type = PinType.Place,
                            Position = new Position(46.360664, 15.115011)
                        };
                        mapdemo.Pins.Add(pin5);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player.Load("audio 5.mp3");
                            player.Play();
                            st++;
                        }

                    }
                    if (st == 6)
                    {
                        manj = new Location(46.360753, 15.114861);
                        vec = new Location(46.361647, 15.114913);
                        Pin pin6 = new Pin
                        {
                            Label = "Šolski center Velenje",
                            Address = "Prispeli ste na destinacijo",
                            Type = PinType.Place,
                            Position = new Position(46.361788, 15.113680)
                        };
                        mapdemo.Pins.Add(pin6);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player.Load("audio 6.mp3");
                            player.Play();
                            st++;
                        }
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
        private void Button_Clicked(object sender, EventArgs e)
        {
            mapdemo.Pins.Clear();
            pot();
        }
    }
}