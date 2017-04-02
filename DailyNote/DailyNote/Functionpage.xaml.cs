using DailyNote.DataBases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace DailyNote
{

    public sealed partial class Functionpage : Page
    {


     


        public Functionpage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }


        #region MainPage_Loaded (get currentlocation)
        Geolocator myGeo;
        Geoposition _pos;
        String CurrentLocation;
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            initialiseGeoLocation();
        }

        private async void initialiseGeoLocation()
        {
            var access = await Geolocator.RequestAccessAsync();
            switch (access)
            {
                case GeolocationAccessStatus.Allowed:
                    // set some stuff up now.
                    myGeo = new Geolocator();
                    //myGeo.PositionChanged not needed just now.
                    myGeo.DesiredAccuracy = PositionAccuracy.High;
                    //Save position to currentLocation
                    GetCurrentLocation();
                    break;
                case GeolocationAccessStatus.Denied:
                case GeolocationAccessStatus.Unspecified:
                    // ask the user for something here if things go wrong.
                    string msg = $"Can't access location services";
                    await new MessageDialog(msg).ShowAsync();
                    break;
                default:
                    break;
            }
        }
        private async void GetCurrentLocation()
        {
            try
            {
                _pos = await myGeo.GetGeopositionAsync();
            }
            catch (Exception ex)
            {
                string msg = $"Problem reading location" + ex.Message;
                await new MessageDialog(msg).ShowAsync();
                return;
            }
            BasicGeoposition myLocation = new BasicGeoposition
            {
                Longitude = _pos.Coordinate.Point.Position.Longitude,
                Latitude = _pos.Coordinate.Point.Position.Latitude
            };
            Geopoint pointToReverseGeocode = new Geopoint(myLocation);
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
            CurrentLocation = result.Locations[0].Address.Town.ToString()
                               + ", " + result.Locations[0].Address.Country.ToString();
        }

        #endregion


        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ResultPage));

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            String text = textBox.Text;
            DateTime time = DateTime.Now;
            String msg = $"your note has successful saved and your location is:" + CurrentLocation;

            await new MessageDialog(msg).ShowAsync();

            using (var conn = DatabaseConnection.GetDbConnection())
            {

                var addnote = new note() { Info = text, Location = CurrentLocation, Time = time };

                var count = conn.Insert(addnote);

               

            }

        }
    }
   
   
}
