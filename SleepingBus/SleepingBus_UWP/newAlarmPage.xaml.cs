using System;
using System.Collections.Generic;
using System.Device.Location;
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

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace SleepingBus_UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class newAlarmPage : Page
    {
        public newAlarmPage()
        {
            this.InitializeComponent();
            ShowMyLocationOnTheMap();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private async void ShowMyLocationOnTheMap()
        {
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            /*
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;

            BasicGeoposition BG = new BasicGeoposition();

            BG.Latitude = myGeocoordinate.Latitude;
            BG.Longitude = myGeocoordinate.Longitude;

            Geopoint meOnMap = new Geopoint(BG);
            */
            stopMap.Center = myGeoposition.Coordinate.Point;
            stopMap.ZoomLevel = 13;

            MapIcon mapIcon = new MapIcon();
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(
              new Uri("ms-appx:///Assets/PinkPushPin.png"));
            mapIcon.NormalizedAnchorPoint = new Point(0.25, 0.9);
            mapIcon.Location = myGeoposition.Coordinate.Point;
            mapIcon.Title = "You are here";
            stopMap.MapElements.Add(mapIcon);
        }
        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {

            BasicGeoposition BG = new BasicGeoposition();

            BG.Latitude = e.Position.Location.Latitude;
            BG.Longitude = e.Position.Location.Longitude;

            Geopoint meOnMap = new Geopoint(BG);
            stopMap.Center = meOnMap;
        }

        private async void stopMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(args.Location);
            if (result.Status == MapLocationFinderStatus.Success)
                if (result.Locations.Count > 0)
                {
                    Place_TextBlock.Text = result.Locations[0].Address.StreetNumber + " " + result.Locations[0].Address.Street;
                    BasicGeoposition BG = new BasicGeoposition();

                    BG.Latitude = args.Location.Position.Latitude;
                    BG.Longitude = args.Location.Position.Longitude;

                    Geopoint Tap_Pos = new Geopoint(BG);
                    MapIcon mapIcon = new MapIcon();
                    mapIcon.Image = RandomAccessStreamReference.CreateFromUri(
                      new Uri("ms-appx:///Assets/PinkPushPin.png"));
                    mapIcon.NormalizedAnchorPoint = new Point(0.25, 0.9);
                    mapIcon.Location =Tap_Pos;
                    mapIcon.Title = result.Locations[0].Address.Street + " " + result.Locations[0].Address.StreetNumber;
                    stopMap.MapElements.Add(mapIcon);
                }
        }

        private void fullScreenMap_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.GetRowSpan(stopMap) != 3)
                Grid.SetRowSpan(stopMap, 3);
            else
                Grid.SetRowSpan(stopMap, 1);
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator();
            Geoposition currentPosition =
              await geolocator.GetGeopositionAsync();

            MapLocationFinderResult result =
              await MapLocationFinder.FindLocationsAsync(
              adressInput.Text, currentPosition.Coordinate.Point, 5);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                List<TextBlock> locations = new List<TextBlock>();
                foreach (MapLocation mapLocation in result.Locations)
                {

                    // Создаем отображаемую строку местоположения на карте
                    string display = mapLocation.Address.StreetNumber + " " +
                      mapLocation.Address.Street + Environment.NewLine +
                      mapLocation.Address.Town + ", " +
                      mapLocation.Address.RegionCode + "  " +
                      mapLocation.Address.PostCode + Environment.NewLine +
                      mapLocation.Address.CountryCode;
                    TextBlock loc = new TextBlock()
                    {
                        Text = display,
                    };

                    // Добавляем эту строку в список местоположений
                    locations.Add(loc);
                }

                // Связываем этот список с элементом управления ListView
                locationsList.ItemsSource=locations;

            }
            else
            {
                // Предлагаем пользователю попытаться еще раз
            }
        }

        private async void adressInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key==Windows.System.VirtualKey.Enter)
            {
                Geolocator geolocator = new Geolocator();
                Geoposition currentPosition =
                  await geolocator.GetGeopositionAsync();

                MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAsync(
                  adressInput.Text, currentPosition.Coordinate.Point, 5);
                if (result.Status == MapLocationFinderStatus.Success)
                {
                    List<TextBlock> locations = new List<TextBlock>();
                    foreach (MapLocation mapLocation in result.Locations)
                    {

                        // Создаем отображаемую строку местоположения на карте
                        string display = mapLocation.Address.StreetNumber + " " +
                          mapLocation.Address.Street + Environment.NewLine +
                          mapLocation.Address.Town + ", " +
                          mapLocation.Address.RegionCode + "  " +
                          mapLocation.Address.PostCode + Environment.NewLine +
                          mapLocation.Address.CountryCode;
                        TextBlock loc = new TextBlock()
                        {
                            Text = display,
                        };

                        // Добавляем эту строку в список местоположений
                        locations.Add(loc);
                    }

                    // Связываем этот список с элементом управления ListView
                    locationsList.ItemsSource = locations;

                }
                else
                {
                    // Предлагаем пользователю попытаться еще раз
                }
            }
        }
    }
}
