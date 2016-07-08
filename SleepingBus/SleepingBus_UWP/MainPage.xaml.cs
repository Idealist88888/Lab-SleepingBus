using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SleepingBus_UWP
{
    /*
                 <Grid.RowDefinitions>
                <RowDefinition Height="13*"/>
                <RowDefinition Height="12*"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="61*"/>
                <ColumnDefinition Width="11*"/>
            </Grid.ColumnDefinitions>
            <ToggleSwitch x:Name="On_Off_Togle" Margin="0" Grid.Column="1" Height="40" Width="165" HorizontalAlignment="Left" Grid.RowSpan="2" UseSystemFocusVisuals="True" IsTextScaleFactorEnabled="False" UseLayoutRounding="True" VerticalAlignment="Center"/>
            <TextBlock x:Name="Alarm_Name" Margin="0" TextWrapping="Wrap" Text="Название будильника" FontSize="36"/>
            <TextBlock x:Name="Distance_Block" HorizontalAlignment="Left" Margin="10,13.333,0,0" Grid.Row="1" TextWrapping="Wrap" Text="Расстояние" VerticalAlignment="Top"/>
            <TextBlock x:Name="Stop_Name" HorizontalAlignment="Left" Margin="93,13.333,0,0" Grid.Row="1" TextWrapping="Wrap" Text="Остановка" VerticalAlignment="Top"/>
        </Grid>
         */
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();       
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleSwitch _On_Off = new ToggleSwitch()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                OnContent = "",
                OffContent = "",
                UseSystemFocusVisuals = true,
                Foreground=new SolidColorBrush(Colors.White)
            };
            Grid.SetColumn(_On_Off, 2);
            Grid.SetRowSpan(_On_Off, 2);
            TextBlock _Alarm_Name = new TextBlock()
            {
                TextWrapping = TextWrapping.Wrap,
                Text = "Name",
                FontSize = 36,
                Foreground= new SolidColorBrush(Colors.White)
            };
            TextBlock _Distance_Block = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Text = "Distance",
                Foreground = new SolidColorBrush(Colors.LightGray)
            };
            Grid.SetRow(_Distance_Block, 1);
            TextBlock _Stop_Name = new TextBlock()
            {
                TextWrapping = TextWrapping.Wrap,
                Text = "Stop",
                Foreground = new SolidColorBrush(Colors.LightGray)
            };
            Grid.SetRow(_Stop_Name, 1);
            Grid.SetColumn(_Stop_Name, 1);
            Grid _Grid_For_Alarm = new Grid()
            {
                Background = new SolidColorBrush(Colors.Black),
                Margin = new Thickness(0, 5, 0, 5),
            };

            _Grid_For_Alarm.RightTapped += (sender2, args) =>
            {
                var menuFlyout = new MenuFlyout();
                //menuFlyout.Items.Add(new MenuFlyoutItem() { Command = new RoutedCommand()})
            };

            _Grid_For_Alarm.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(13, GridUnitType.Star) });
            _Grid_For_Alarm.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(12, GridUnitType.Star) });
            _Grid_For_Alarm.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(90, GridUnitType.Star) });
            _Grid_For_Alarm.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(220, GridUnitType.Star) });
            _Grid_For_Alarm.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Star) });

            _Grid_For_Alarm.Children.Add(_On_Off);
            _Grid_For_Alarm.Children.Add(_Alarm_Name);
            _Grid_For_Alarm.Children.Add(_Distance_Block);
            _Grid_For_Alarm.Children.Add(_Stop_Name);

            Alarms_List.Children.Add(_Grid_For_Alarm);
        }
    }
}
