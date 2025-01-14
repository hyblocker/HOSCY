﻿using NAudio.Wave;
using System.Collections.Generic;

namespace Hoscy.Services.Speech.Utilities
{
    internal static class Devices
    {
        internal static void ForceReload()
        {
            Logger.PInfo("Enforcing reload of Devices");
            Microphones = GetMicrophones();
            Speakers = GetSpeakers();
        }

        #region Mics
        internal static IReadOnlyList<WaveInCapabilities> Microphones { get; private set; } = GetMicrophones();
        private static IReadOnlyList<WaveInCapabilities> GetMicrophones()
        {
            Logger.Info("Getting list of Microphones");
            var list = new List<WaveInCapabilities>();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
                list.Add(WaveIn.GetCapabilities(i));

            return list;
        }
        internal static int GetMicrophoneIndex(string guid)
        {
            for (int i = 0; i < Microphones.Count; i++)
            {
                if (Microphones[i].ProductName == guid)
                    return i;
            }

            if (Microphones.Count == 0)
                return -1;
            else
                return 0;
        }
        #endregion

        #region Speakers
        internal static IReadOnlyList<WaveOutCapabilities> Speakers { get; private set; } = GetSpeakers();
        private static IReadOnlyList<WaveOutCapabilities> GetSpeakers()
        {
            Logger.Info("Getting list of Speakers");
            var speakers = new List<WaveOutCapabilities>();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
                speakers.Add(WaveOut.GetCapabilities(i));

            return speakers;
        }

        internal static int GetSpeakerIndex(string guid)
        {
            for (int i = 0; i < Speakers.Count; i++)
            {
                if (Speakers[i].ProductName == guid)
                    return i;
            }

            if (Speakers.Count == 0)
                return -1;
            else
                return 0;
        }
        #endregion
    }
}
