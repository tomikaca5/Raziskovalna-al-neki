using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public static double latitude = 0;
        public static double longitude = 0;

        public static string DatabaseFilename = "potibazamain.db";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
