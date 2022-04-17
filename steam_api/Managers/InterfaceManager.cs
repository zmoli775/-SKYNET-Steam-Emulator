﻿using SKYNET;
using SKYNET.Helpers;
using SKYNET.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace SKYNET.Managers
{
    public class InterfaceManager
    {
        private static ConcurrentDictionary<string, Type> interfaceTypes;
        private static Dictionary<string, IntPtr> StoredInterfaces;
        private static Dictionary<string, IntPtr> StoredInterfaces_Gameserver;

        static InterfaceManager()
        {
            interfaceTypes = new ConcurrentDictionary<string, Type>();
            StoredInterfaces = new Dictionary<string, IntPtr>();
            StoredInterfaces_Gameserver = new Dictionary<string, IntPtr>();
        }

        public static void Initialize()
        {
            try
            {
                Console.WriteLine("Loading Assembly");
                Assembly currentAssembly = Assembly.GetAssembly(typeof(InterfaceAttribute));
                Console.WriteLine(currentAssembly.GetTypes() == null);
                if (currentAssembly == null)
                {
                    Console.WriteLine("Error loading Interface list.");
                    return;
                }
                foreach (var type in currentAssembly.GetTypes())
                {
                    Console.WriteLine($"{type.Name}");
                    if (type.IsDefined(typeof(InterfaceAttribute)))
                    {
                        var interfaceAttribute = type.GetCustomAttributes<InterfaceAttribute>().ToList()[0];
                        interfaceTypes.TryAdd(interfaceAttribute.Name, type);
                    }
                }
            }
            catch 
            {
                
            }
        }

        public static T CreateInterface<T>(out IntPtr BaseAddress) where T : ISteamInterface
        {
            var (iface, context) = MemoryManager.CreateInterface<T>();
            BaseAddress = context;
            T baseClass = (T)iface;
            //baseClass.MemoryAddress = context;
            return (T)baseClass;
        }

        public static IntPtr FindOrCreateInterface(string pchVersion)
        {
            return FindOrCreateInterface(1, 1, pchVersion);
        }

        public static IntPtr FindOrCreateInterface(int hSteamUser, int hSteamPipe, string pszVersion, bool GameServer = false)
        {
            if (pszVersion.StartsWith("SteamGameServer0"))
            {
                Write($"Skipping {pszVersion}");
                return default;
            }
            if (pszVersion.StartsWith("SteamClient"))
            {
                //Write($"Skipping {pszVersion}");
                //return default;
            }

            ///////////////////////////////////////////////////////////////////////

            if (GameServer && StoredInterfaces_Gameserver.ContainsKey(pszVersion))
            {
                return StoredInterfaces_Gameserver[pszVersion];
            }
            else if (StoredInterfaces.ContainsKey(pszVersion))
            {
                return StoredInterfaces[pszVersion];
            }

            if (!interfaceTypes.ContainsKey(pszVersion))
            {
                Write($"Not found Interface for {pszVersion}");
                return default;
            }

            Type interfaceType = interfaceTypes[pszVersion];

            IntPtr address = MemoryManager.CreateInterface(interfaceType);

            if (address == IntPtr.Zero)
            {
                Write($"Error creating Interface for {pszVersion}");
                return address;
            }

            if (GameServer)
            {
                StoredInterfaces_Gameserver.Add(pszVersion, address);
            }
            else
            {
                StoredInterfaces.Add(pszVersion, address);
            }
            
            SetInterfaceName(pszVersion, interfaceType);

            return address;
        }

        private static void SetInterfaceName(string pszVersion, Type type)
        {
            if (pszVersion.StartsWith("SteamUtils"))
            {
                SteamEmulator.SteamUtils.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamUser"))
            {
                SteamEmulator.SteamUser.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamClient"))
            {
                SteamEmulator.SteamClient.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamFriends"))
            {
                SteamEmulator.SteamFriends.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamMatchMaking"))
            {
                SteamEmulator.SteamMatchmaking.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamMatchGameSearch"))
            {
                SteamEmulator.SteamGameSearch.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamMatchMakingServers"))
            {
                SteamEmulator.SteamMatchMakingServers.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMUSERSTATS_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamUserStats.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMAPPS_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamApps.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamNetworking"))
            {
                SteamEmulator.SteamNetworking.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMREMOTESTORAGE_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamRemoteStorage.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMSCREENSHOTS_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamScreenshots.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMHTTP_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamHTTP.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamController"))
            {
                SteamEmulator.SteamController.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMUGC_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamUGC.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMAPPLIST_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamAppList.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMMUSIC_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamMusic.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMMUSICREMOTE_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamMusicRemote.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMHTMLSURFACE_INTERFACE_VERSION_"))
            {
                SteamEmulator.SteamHTMLSurface.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMINVENTORY_INTERFACE_V"))
            {
                SteamEmulator.SteamInventory.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMVIDEO_INTERFACE_V"))
            {
                SteamEmulator.SteamVideo.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("STEAMPARENTALSETTINGS_INTERFACE_VERSION"))
            {
                SteamEmulator.SteamParentalSettings.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamGameServer0"))
            {
                SteamEmulator.SteamGameServer.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamGameCoordinator"))
            {
                SteamEmulator.SteamGameCoordinator.InterfaceVersion = type.Name;
            }
            if (pszVersion.StartsWith("SteamNetworkingSocketsSerialized"))
            {
                SteamEmulator.SteamNetworkingSocketsSerialized.InterfaceVersion = type.Name;
            }
        }

        private static void Write(string v)
        {
            SteamEmulator.Write("Interface Manager", v);
        }
    }
}