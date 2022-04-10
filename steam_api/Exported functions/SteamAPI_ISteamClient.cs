using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using SKYNET;
using SKYNET.Managers;
using SKYNET.Steamworks.Types;
using Steamworks;

namespace SKYNET.Steamworks.Exported
{
    public class SteamAPI_ISteamClient : BaseCalls
    {
        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamClient_CreateSteamPipe()
        {
            Write("SteamAPI_ISteamClient_CreateSteamPipe");
            return (int)SteamEmulator.CreateSteamPipe();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamClient_BReleaseSteamPipe(int hSteamPipe)
        {
            Write("SteamAPI_ISteamClient_BReleaseSteamPipe");
            return SteamEmulator.SteamClient.BReleaseSteamPipe(hSteamPipe);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamClient_ConnectToGlobalUser(int hSteamPipe)
        {
            Write("SteamAPI_ISteamClient_ConnectToGlobalUser");
            return SteamEmulator.SteamClient.ConnectToGlobalUser(hSteamPipe);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamClient_CreateLocalUser(int phSteamPipe, int eAccountType)
        {
            Write("SteamAPI_ISteamClient_CreateLocalUser");
            return SteamEmulator.SteamClient.CreateLocalUser(phSteamPipe, eAccountType);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamAPI_ISteamClient_ReleaseUser(int hSteamPipe, int hUser)
        {
            Write("SteamAPI_ISteamClient_ReleaseUser");
            SteamEmulator.SteamClient.ReleaseUser(hSteamPipe, hUser);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamUser(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamUser");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamGameServer");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamAPI_ISteamClient_SetLocalIPBinding(uint unIP, ushort usPort)
        {
            Write("SteamAPI_ISteamClient_SetLocalIPBinding");
            SteamEmulator.SteamClient.SetLocalIPBinding(unIP, usPort);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamFriends");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr instancePtr, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamUtils");
            return InterfaceManager.FindOrCreateInterface(11, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamMatchmaking");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamMatchmakingServers");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamGenericInterface");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamUserStats");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamGameServerStats");
            return InterfaceManager.FindOrCreateInterface((int)1, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamApps");
            return InterfaceManager.FindOrCreateInterface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamNetworking");
            return SteamEmulator.SteamClient.GetISteamNetworking(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamRemoteStorage");
            return SteamEmulator.SteamClient.GetISteamRemoteStorage(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamScreenshots");
            return SteamEmulator.SteamScreenshots.MemoryAddress;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamClient_GetIPCCallCount()
        {
            Write("SteamAPI_ISteamClient_GetIPCCallCount");
            return SteamEmulator.SteamClient.GetIPCCallCount(SteamEmulator.SteamClient.MemoryAddress);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed()
        {
            Write("SteamAPI_ISteamClient_BShutdownIfAllPipesClosed");
            return SteamEmulator.SteamClient.BShutdownIfAllPipesClosed(SteamEmulator.SteamClient.MemoryAddress);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamHTTP");
            return SteamEmulator.SteamHTTP.MemoryAddress;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamController");
            return SteamEmulator.SteamClient.GetISteamController(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamUGC");
            return SteamEmulator.SteamClient.GetISteamUGC(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamAppList");
            return SteamEmulator.SteamClient.GetISteamAppList(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamMusic");
            return SteamEmulator.SteamClient.GetISteamMusic(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamMusicRemote");
            return SteamEmulator.SteamClient.GetISteamMusicRemote(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamHTMLSurface");
            return SteamEmulator.SteamClient.GetISteamHTMLSurface(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamInventory");
            return SteamEmulator.SteamClient.GetISteamInventory(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamVideo");
            return SteamEmulator.SteamClient.GetISteamVideo(hSteamUser, hSteamPipe, pchVersion);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr SteamAPI_ISteamClient_GetISteamParentalSettings(IntPtr instancePtr, int hSteamUser, int hSteamPipe, string pchVersion)
        {
            Write("SteamAPI_ISteamClient_GetISteamParentalSettings");
            return SteamEmulator.SteamClient.GetISteamParentalSettings(hSteamUser, hSteamPipe, pchVersion);
        }
    }
}

