﻿using Hoscy.Services.Api;
using Hoscy.Services.Speech;
using Hoscy.Services.Speech.Utilities;
using Hoscy.Ui.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Hoscy.Ui.Pages
{
    /// <summary>
    /// Interaction logic for PageDebug.xaml
    /// </summary>
    internal partial class PageConfig : Page
    {
        public PageConfig()
        {
            InitializeComponent();
            versionText.Content = Utils.GetVersion();
        }

        #region Buttons
        private void Button_OpenLogFilter(object sender, RoutedEventArgs e)
        {
            var window = new ModifyFiltersWindow("Edit Logging Filter", Config.Debug.LogFilters);
            window.SetDarkMode(true);
            window.ShowDialog();
        }

        private void Button_ReloadDevices(object sender, RoutedEventArgs e)
        {
            if (Recognition.IsRecognizerRunning)
                Recognition.StopRecognizer();

            Devices.ForceReload();
        }
        private void Button_OpenDocs(object sender, RoutedEventArgs e)
            => UiHelper.StartProcess(Utils.Github);
        private void Button_OpenConfig(object sender, RoutedEventArgs e)
            => UiHelper.StartProcess(Utils.PathConfigFolder);
        private void Button_CheckUpdate(object sender, RoutedEventArgs e)
            => Updater.PerformUpdate();
        private void Button_SaveConfig(object sender, RoutedEventArgs e)
            => Config.SaveConfig();
        private void Button_ReloadMedia(object sender, RoutedEventArgs e)
            => Media.StartMediaDetection();
        #endregion
    }
}
