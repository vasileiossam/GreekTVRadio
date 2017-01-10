using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GreekTVRadio
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            foreach (var station in App.Stations)
            {
                var button = new Button()
                {
                    FontSize = 32,
                    Content = station.Name,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness() { Top = 10 }
                };
                button.Click += Button_Click;

                if (station.IsTV)
                {
                    TvPanel.Children.Add(button);
                }
                else
                {
                    RadioPanel.Children.Add(button);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var station = App.Stations.FirstOrDefault(x => x.Name == (button.Content as string));
            if (station == null) return;

            Frame.Navigate(typeof(Player), station);
        }
    }
}
