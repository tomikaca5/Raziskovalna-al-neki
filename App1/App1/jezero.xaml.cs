using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class jezero : ContentPage
    {
        int pot_id = 2;

        int st = 1;

        List<koordinate> podatki = new List<koordinate>();

        List<tocke> t_list = new List<tocke>();

        Database db = new Database();

        bool na_tocki;

        bool played;
        public jezero()
        {
            InitializeComponent();
            mapjez.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(46.374162, 15.102618), Distance.FromKilometers(1)));

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

                Polyline poli = new Polyline
                {
                    StrokeColor = Color.DodgerBlue,
                    StrokeWidth = 12,
                    Geopath =
                    {
                        new Position(lant,longic),
                        new Position(lant2,longic2)
                    }
                };
                mapjez.MapElements.Add(poli);
            }
        }
        async void pot2()
        {
            int i = 0;
            while (st < 16)
            {
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);



                    Location manj = new Location(46.373945, 15.102487);
                    Location vec = new Location(46.374095, 15.102691);
                    var player1 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

                    if (st == 1)
                    {
                        Pin pin = new Pin
                        {
                            Label = "Začetna točka",
                            Address = "Lahko grete pred potjo še na stranišče",
                            Type = PinType.Place,
                            Position = new Position(46.374014, 15.102601)
                        };
                        mapjez.Pins.Add(pin);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Prvi.mp3");
                            player1.Play();
                            st++;
                        }
                        else
                        {
                            if (i == 0)
                            {
                                player1.Load("not.mp3");
                                player1.Play();
                                i++;
                            }
                        }
                    }
                    if (st == 2)
                    {
                        manj = new Location(46.374253, 15.102552);
                        vec = new Location(46.374345, 15.102656);
                        Pin pin2 = new Pin
                        {
                            Label = "Druga točka",
                            Address = "Pojdite proti jezeru",
                            Type = PinType.Place,
                            Position = new Position(46.374300, 15.102609)
                        };
                        mapjez.Pins.Add(pin2);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Druga.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 3)
                    {
                        manj = new Location(46.376998, 15.100760);
                        vec = new Location(46.377283, 15.101011);
                        Pin pin3 = new Pin
                        {
                            Label = "Tretja točka",
                            Address = "Ribiška točka",
                            Type = PinType.Place,
                            Position = new Position(46.377074, 15.100854)
                        };
                        mapjez.Pins.Add(pin3);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Tretji.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 4)
                    {
                        manj = new Location(46.377861, 15.101005);
                        vec = new Location(46.377993, 15.101349);
                        Pin pin4 = new Pin
                        {
                            Label = "Četrta točka",
                            Address = "Zavijte desno",
                            Type = PinType.Place,
                            Position = new Position(46.377921, 15.101215)
                        };
                        mapjez.Pins.Add(pin4);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Cetrti.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 5)
                    {
                        manj = new Location(46.377744, 15.101462);
                        vec = new Location(46.377853, 15.102741);
                        Pin pin5 = new Pin
                        {
                            Label = "Peta točka",
                            Address = "Telovadba v gozdu",
                            Type = PinType.Place,
                            Position = new Position(46.377704, 15.102708)
                        };
                        mapjez.Pins.Add(pin5);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Peta.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 6)
                    {
                        manj = new Location(46.377075, 15.104322);
                        vec = new Location(46.377223, 15.104665);
                        Pin pin6 = new Pin
                        {
                            Label = "Šesta točka",
                            Address = "Prišli ste iz gozda",
                            Type = PinType.Place,
                            Position = new Position(46.377118, 15.104518)
                        };
                        mapjez.Pins.Add(pin6);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Sesta.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 7)
                    {
                        manj = new Location(46.376415, 15.105596);
                        vec = new Location(46.376506, 15.105762);
                        Pin pin7 = new Pin
                        {
                            Label = "Sedma točka",
                            Address = "Ribiški dom",
                            Type = PinType.Place,
                            Position = new Position(46.376436, 15.105666)
                        };
                        mapjez.Pins.Add(pin7);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Sedma.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 8)
                    {
                        manj = new Location(46.375919, 15.106700);
                        vec = new Location(46.376030, 15.106850);
                        Pin pin8 = new Pin
                        {
                            Label = "Osma točka",
                            Address = "Križišče",
                            Type = PinType.Place,
                            Position = new Position(46.375943, 15.106763)
                        };
                        mapjez.Pins.Add(pin8);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Osma.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 9)
                    {
                        manj = new Location(46.376257, 15.108543);
                        vec = new Location(46.376474, 15.108737);
                        Pin pin9 = new Pin
                        {
                            Label = "Deveta točka",
                            Address = "Konji",
                            Type = PinType.Place,
                            Position = new Position(46.376339, 15.108629)
                        };
                        mapjez.Pins.Add(pin9);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Deveta.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 10)
                    {
                        manj = new Location(46.376465, 15.109660);
                        vec = new Location(46.376598, 15.109915);
                        Pin pin10 = new Pin
                        {
                            Label = "Deseta točka",
                            Address = "Most ter igrišče",
                            Type = PinType.Place,
                            Position = new Position(46.376499, 15.109767)
                        };
                        mapjez.Pins.Add(pin10);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Deseta.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 11)
                    {
                        manj = new Location(46.375188, 15.109512);
                        vec = new Location(46.375869, 15.110025);
                        Pin pin11 = new Pin
                        {
                            Label = "Enajsta točka",
                            Address = "Ribiči",
                            Type = PinType.Place,
                            Position = new Position(46.375267, 15.109635)
                        };
                        mapjez.Pins.Add(pin11);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Enajsta.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 12)
                    {
                        manj = new Location(46.374148, 15.109622);
                        vec = new Location(46.374537, 15.109970);
                        Pin pin12 = new Pin
                        {
                            Label = "Dvanajsta točka",
                            Address = "Nadaljujte ob jezeru",
                            Type = PinType.Place,
                            Position = new Position(46.374277, 15.109782)
                        };
                        mapjez.Pins.Add(pin12);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Dvanajsta.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 13)
                    {
                        manj = new Location(46.373672, 15.106691);
                        vec = new Location(46.373847, 15.107282);
                        Pin pin13 = new Pin
                        {
                            Label = "Trinajsta točka",
                            Address = "Letni kino",
                            Type = PinType.Place,
                            Position = new Position(46.373760, 15.106906)
                        };
                        mapjez.Pins.Add(pin13);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Trinajsti.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 14)
                    {
                        manj = new Location(46.373742, 15.105047);
                        vec = new Location(46.373946, 15.105345);
                        Pin pin14 = new Pin
                        {
                            Label = "Štirinajsta točka",
                            Address = "Štadion",
                            Type = PinType.Place,
                            Position = new Position(46.373825, 15.105152)
                        };
                        mapjez.Pins.Add(pin14);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("Stirnajst.mp3");
                            player1.Play();
                            st++;
                        }

                    }
                    if (st == 15)
                    {
                        manj = new Location(46.372966, 15.105490);
                        vec = new Location(46.373231, 15.105767);
                        Pin pin15 = new Pin
                        {
                            Label = "Končna točka",
                            Address = "46.373038, 15.105611",
                            Type = PinType.Place,
                            Position = new Position(46.373038, 15.105611)
                        };
                        mapjez.Pins.Add(pin15);
                        if (location.Latitude > manj.Latitude && location.Longitude > manj.Longitude && location.Latitude < vec.Latitude && location.Longitude < vec.Longitude)
                        {
                            player1.Load("ZADNJI.mp3");
                            player1.Play();
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
            mapjez.Pins.Clear();
            pot2();
        }
    }

}