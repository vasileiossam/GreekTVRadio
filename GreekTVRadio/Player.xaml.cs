using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GreekTVRadio
{
    public sealed partial class Player : Page
    {
        public Player()
        {
            this.InitializeComponent();

            // http://stackoverflow.com/questions/30597585/windows-10-uap-back-button
            // Register a handler for BackRequested events and set the
            // visibility of the Back button
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var station = e.Parameter as Station;

            StationName.Text = station.Name;
            StatusText.Text = "Loading...";
            Browser.Navigate(new Uri(station.Url));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void Browser_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            StatusText.Text = "";
        }

        private void GoBack()
        {
            Browser.Navigate(new Uri("about:blank"));
            Frame.Navigate(typeof(MainPage));
        }
    }
}
