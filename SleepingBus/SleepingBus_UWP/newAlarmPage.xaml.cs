using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SleepingBus_UWP
{
    public sealed partial class newAlarmPage : Page
    {
        NewAlarmController _newAlarmController = new NewAlarmController();
        public newAlarmPage()
        {
            this.InitializeComponent();
        }       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _newAlarmController.ShowMyLocationOnTheMap(stopMap);      
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void stopMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(args.Location);
            if (result.Status == MapLocationFinderStatus.Success && result.Locations.Count > 0)
            {
                Place_TextBlock.Text = result.Locations[0].Address.StreetNumber + " " + result.Locations[0].Address.Street;
                MapIcon mapIcon = new MapIcon()
                {
                    Image = RandomAccessStreamReference.CreateFromUri(
                        new Uri("ms-appx:///Assets/PinkPushPin.png")),
                    NormalizedAnchorPoint = new Point(0.25, 0.9),
                    Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = args.Location.Position.Latitude,
                        Longitude = args.Location.Position.Longitude
                    }),
                    Title = result.Locations[0].Address.Street + " " + result.Locations[0].Address.StreetNumber
                };
                stopMap.MapElements.Add(mapIcon);
            }
        }

        private void fullScreenMap_Click(object sender, RoutedEventArgs e) =>
            Grid.SetRowSpan(stopMap, Grid.GetRowSpan(stopMap) != 3 ? 3 : 1);

        private void adressInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key==Windows.System.VirtualKey.Enter)
                _newAlarmController.ShowAddresses(locationsList, adressInput.Text);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e) =>
            _newAlarmController.ShowAddresses(locationsList, adressInput.Text);
    }
}
