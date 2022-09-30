﻿using Hoscy.Services.Speech;
using System;
using System.Windows;

namespace Hoscy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Indicator for threads to stop
        public static bool Running { get; private set; } = true;
        protected override void OnExit(ExitEventArgs e)
        {
            if (Recognition.IsRecognizerRunning)
                Recognition.StopRecognizer();

            Config.SaveConfig();
            Running = false;
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                Logger.Error(e.Exception, "A fatal error has occured, Hoscy will now shut down.");
            }
            catch { }
            Current.Shutdown(-1);
            Environment.Exit(-1);
        }
    }
}
