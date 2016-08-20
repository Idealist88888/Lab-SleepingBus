using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

namespace SleepingBus_UWP
{
    public class NewAlarmController
    {
        public async void ShowMyLocationOnTheMap(MapControl stopMap)
        {
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
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

        public async void ShowAddresses(ListView locationList, string adressInput)
        {
            MapLocationFinderResult result =
              await MapLocationFinder.FindLocationsAsync(
                    adressInput, (await new Geolocator().GetGeopositionAsync()).Coordinate.Point, 5);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                List<TextBlock> locations = new List<TextBlock>();
                foreach (MapLocation mapLocation in result.Locations)
                    locations.Add(new TextBlock()
                                    {
                                        Text = $"{mapLocation.Address.StreetNumber}  {mapLocation.Address.Street}\n{mapLocation.Address.Town}, {mapLocation.Address.RegionCode}  {mapLocation.Address.PostCode}\n{mapLocation.Address.CountryCode}"
                                    });
                locationList.ItemsSource = locations;
            }
        }

    }
}
