using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    }
}
