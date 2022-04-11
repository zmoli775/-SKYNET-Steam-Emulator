﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using SKYNET;
using SKYNET.Steamworks.Helpers;

namespace SKYNET.Steamworks.Implementation
{
    [StructLayout(LayoutKind.Sequential)]
    public class SteamAppList : ISteamInterface
    {
        public int GetAppBuildId(uint nAppID)
        {
            Write("GetAppBuildId");
            return 10;
        }

        public int GetAppInstallDir(uint nAppID, string pchDirectory, int cchNameMax)
        {
            Write("GetAppInstallDir");
            return -1;
        }

        public int GetAppName(uint nAppID, string pchName, int cchNameMax)
        {
            Write("GetAppName\n");
            return -1;
        }

        public uint GetInstalledApps(uint pvecAppID, uint unMaxAppIDs)
        {
            Write("GetInstalledApps\n");
            return 0;
        }

        public uint GetNumInstalledApps(IntPtr _)
        {
            Write("GetNumInstalledApps\n");
            return 0;
        }

        public IntPtr MemoryAddress { get; set; }
        public string InterfaceVersion { get; set; }

        public SteamAppList()
        {
            InterfaceVersion = "SteamAppList";
        }


        private void Write(string v)
        {
            SteamEmulator.Write(InterfaceVersion, v);
        }
    }
}
