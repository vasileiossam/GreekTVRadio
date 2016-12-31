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
        /// <summary>
        /// http://www.livetvgreece.com/
        /// </summary>
        private List<Station> _stations = new List<Station>
        {
            new Station()
            {
                Name = "Star",
                Url = "http://www.star.gr/tv/el/Pages/LiveStream.aspx",
                IsTV = true
            },
            new Station()
            {
                Name = "Mega",
                Url = "https://www.youtube.com/embed/2Y8qsS_xH2Y?rel=0&autoplay=1",
                IsTV = true
            },
            new Station()
            {
                Name = "ERT 1",
                Url = "http://webtv.ert.gr/ert1/",
                IsTV = true
            },
            new Station()
            {
                Name = "ERT 2",
                Url = "http://webtv.ert.gr/ert2/",
                IsTV = true
            },
            new Station()
            {
                Name = "ERT 3",
                Url = "http://webtv.ert.gr/ert3/",
                IsTV = true
            },
            new Station()
            {
                Name = "ERT WORLD",
                Url = "http://webtv.ert.gr/ertworld/",
                IsTV = true
            },
            new Station()
            {
                Name = "Sky",
                Url = "https://www.youtube.com/embed/EjU_sHwWaAo?rel=0&autoplay=1",
                IsTV = true
            },
            new Station()
            {
                Name = "Epsilon",
                Url = "http://www.epsilontv.gr/livetv/",
                IsTV = true
            },
            //new TvStation()
            //{
            //    Name = "Alpha",
            //    Url = "http://www.alphatv.gr/webtv/live"
            //},
            new Station()
            {
                Name = "Kontra",
                Url = "http://live24.gr/webtv/kontrachannel/",
                IsTV = true
            },
            new Station()
            {
                Name = "RealFM 97.8",
                Url = "http://live24.gr/radio/realfm.jsp",
                IsTV = false
            },
            new Station()
            {
                Name = "ΠΡΩΤΟ ΠΡΟΓΡΑΜΜΑ",
                Url = "http://webradio.ert.gr/proto/",
                IsTV = false
            },
            new Station()
            {
                Name = "ΔΕΥΤΕΡΟ ΠΡΟΓΡΑΜΜΑ",
                Url = "http://webradio.ert.gr/deftero/",
                IsTV = false
            },
            new Station()
            {
                Name = "TΡΙΤΟ ΠΡΟΓΡΑΜΜΑ",
                Url = "http://webradio.ert.gr/trito/",
                IsTV = false
            },
            new Station()
            {
                Name = "Η ΦΩΝΗ ΤΗΣ ΕΛΛΑΔΑΣ",
                Url = "http://webradio.ert.gr/trito/",
                IsTV = false
            },
        };

        public MainPage()
        {
            this.InitializeComponent();

            foreach (var station in _stations)
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

            var station = _stations.FirstOrDefault(x => x.Name == (button.Content as string));
            if (station == null) return;

            Frame.Navigate(typeof(Player), station);
        }
    }
}
