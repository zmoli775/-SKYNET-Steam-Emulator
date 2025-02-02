﻿using System;
using System.Runtime.InteropServices;

using HSteamPipe = System.UInt32;
using HSteamUser = System.UInt32;
using SteamAPICall_t = System.UInt64;
using HAuthTicket = System.UInt32;
using AppId_t = System.UInt32;

namespace SKYNET.Steamworks.Exported
{
    public partial class SteamAPI_ISteamGameServer
    {
        public static bool SteamAPI_ISteamGameServer_InitGameServer(IntPtr _, uint unIP, int usGamePort, int usQueryPort, uint unFlags, AppId_t nGameAppId, string pchVersionString)
        {
            Write("SteamAPI_ISteamGameServer_InitGameServer");
            return SteamEmulator.SteamGameServer.InitGameServer(unIP, usGamePort, usQueryPort, unFlags, nGameAppId, pchVersionString);
        }

        public static void SteamAPI_ISteamGameServer_SetProduct(IntPtr _, string pszProduct)
        {
            Write("SteamAPI_ISteamGameServer_SetProduct");
            SteamEmulator.SteamGameServer.SetProduct(pszProduct);
        }

        public static void SteamAPI_ISteamGameServer_SetGameDescription(IntPtr _, string pszGameDescription)
        {
            Write("SteamAPI_ISteamGameServer_SetGameDescription");
            SteamEmulator.SteamGameServer.SetGameDescription(pszGameDescription);
        }

        public static void SteamAPI_ISteamGameServer_SetModDir(IntPtr _, string pszModDir)
        {
            Write("SteamAPI_ISteamGameServer_SetModDir");
            SteamEmulator.SteamGameServer.SetModDir(pszModDir);
        }

        public static void SteamAPI_ISteamGameServer_SetDedicatedServer(IntPtr _, bool bDedicated)
        {
            Write("SteamAPI_ISteamGameServer_SetDedicatedServer");
            SteamEmulator.SteamGameServer.SetDedicatedServer(bDedicated);
        }

        public static void SteamAPI_ISteamGameServer_LogOn(IntPtr _, string pszToken)
        {
            Write("SteamAPI_ISteamGameServer_LogOn");
            SteamEmulator.SteamGameServer.LogOn(pszToken);
        }

        public static void SteamAPI_ISteamGameServer_LogOnAnonymous(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_LogOnAnonymous");
            SteamEmulator.SteamGameServer.LogOnAnonymous();
        }

        public static void SteamAPI_ISteamGameServer_LogOff(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_LogOff");
            SteamEmulator.SteamGameServer.LogOff();
        }

        public static bool SteamAPI_ISteamGameServer_BLoggedOn(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_BLoggedOn");
            return SteamEmulator.SteamGameServer.BLoggedOn();
        }

        public static bool SteamAPI_ISteamGameServer_BSecure(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_BSecure");
            return SteamEmulator.SteamGameServer.BSecure();
        }

        public static ulong SteamAPI_ISteamGameServer_GetSteamID(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_GetSteamID");
            return SteamEmulator.SteamGameServer.GetSteamID().SteamID;
        }

        public static bool SteamAPI_ISteamGameServer_WasRestartRequested(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_WasRestartRequested");
            return SteamEmulator.SteamGameServer.WasRestartRequested();
        }

        public static void SteamAPI_ISteamGameServer_SetMaxPlayerCount(IntPtr _, int cPlayersMax)
        {
            Write("SteamAPI_ISteamGameServer_SetMaxPlayerCount");
            SteamEmulator.SteamGameServer.SetMaxPlayerCount(cPlayersMax);
        }

        public static void SteamAPI_ISteamGameServer_SetBotPlayerCount(IntPtr _, int cBotplayers)
        {
            Write("SteamAPI_ISteamGameServer_SetBotPlayerCount");
            SteamEmulator.SteamGameServer.SetBotPlayerCount(cBotplayers);
        }

        public static void SteamAPI_ISteamGameServer_SetServerName(IntPtr _, string pszServerName)
        {
            Write("SteamAPI_ISteamGameServer_SetServerName");
            SteamEmulator.SteamGameServer.SetServerName(pszServerName);
        }

        public static void SteamAPI_ISteamGameServer_SetMapName(IntPtr _, string pszMapName)
        {
            Write("SteamAPI_ISteamGameServer_SetMapName");
            SteamEmulator.SteamGameServer.SetMapName(pszMapName);
        }

        public static void SteamAPI_ISteamGameServer_SetPasswordProtected(IntPtr _, bool bPasswordProtected)
        {
            Write("SteamAPI_ISteamGameServer_SetPasswordProtected");
            SteamEmulator.SteamGameServer.SetPasswordProtected(bPasswordProtected);
        }

        public static void SteamAPI_ISteamGameServer_SetSpectatorPort(IntPtr _, int unSpectatorPort)
        {
            Write("SteamAPI_ISteamGameServer_SetSpectatorPort");
            SteamEmulator.SteamGameServer.SetSpectatorPort(unSpectatorPort);
        }

        public static void SteamAPI_ISteamGameServer_SetSpectatorServerName(IntPtr _, string pszSpectatorServerName)
        {
            Write("SteamAPI_ISteamGameServer_SetSpectatorServerName");
            SteamEmulator.SteamGameServer.SetSpectatorServerName(pszSpectatorServerName);
        }

        public static void SteamAPI_ISteamGameServer_ClearAllKeyValues(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_ClearAllKeyValues");
            SteamEmulator.SteamGameServer.ClearAllKeyValues();
        }

        public static void SteamAPI_ISteamGameServer_SetKeyValue(IntPtr _, string pKey, string pValue)
        {
            Write("SteamAPI_ISteamGameServer_SetKeyValue");
            SteamEmulator.SteamGameServer.SetKeyValue(pKey, pValue);
        }

        public static void SteamAPI_ISteamGameServer_SetGameTags(IntPtr _, string pchGameTags)
        {
            Write("SteamAPI_ISteamGameServer_SetGameTags");
            SteamEmulator.SteamGameServer.SetGameTags(pchGameTags);
        }

        public static void SteamAPI_ISteamGameServer_SetGameData(IntPtr _, string pchGameData)
        {
            Write("SteamAPI_ISteamGameServer_SetGameData");
            SteamEmulator.SteamGameServer.SetGameData(pchGameData);
        }

        public static void SteamAPI_ISteamGameServer_SetRegion(IntPtr _, string pszRegion)
        {
            Write("SteamAPI_ISteamGameServer_SetRegion");
            SteamEmulator.SteamGameServer.SetRegion(pszRegion);
        }

        public static bool SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate(IntPtr _, uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ulong pSteamIDUser)
        {
            Write("SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate");
            return SteamEmulator.SteamGameServer.SendUserConnectAndAuthenticate(unIPClient, pvAuthBlob, cubAuthBlobSize, pSteamIDUser);
        }

        public static ulong SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection");
            return SteamEmulator.SteamGameServer.CreateUnauthenticatedUserConnection().SteamID;
        }

        public static void SteamAPI_ISteamGameServer_SendUserDisconnect(IntPtr _, ulong steamIDUser)
        {
            Write("SteamAPI_ISteamGameServer_SendUserDisconnect");
            SteamEmulator.SteamGameServer.SendUserDisconnect(steamIDUser);
        }

        public static bool SteamAPI_ISteamGameServer_BUpdateUserData(IntPtr _, ulong steamIDUser, string pchPlayerName, uint uScore)
        {
            Write("SteamAPI_ISteamGameServer_BUpdateUserData");
            return SteamEmulator.SteamGameServer.BUpdateUserData(steamIDUser, pchPlayerName, uScore);
        }

        public static HAuthTicket SteamAPI_ISteamGameServer_GetAuthSessionTicket(IntPtr _, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket)
        {
            Write("SteamAPI_ISteamGameServer_GetAuthSessionTicket");
            return SteamEmulator.SteamGameServer.GetAuthSessionTicket(pTicket, cbMaxTicket, ref pcbTicket);
        }

        public static int SteamAPI_ISteamGameServer_BeginAuthSession(IntPtr _, IntPtr pAuthTicket, int cbAuthTicket, ulong steamID)
        {
            Write("SteamAPI_ISteamGameServer_BeginAuthSession");
            return SteamEmulator.SteamGameServer.BeginAuthSession(pAuthTicket, cbAuthTicket, steamID);
        }

        public static void SteamAPI_ISteamGameServer_EndAuthSession(IntPtr _, ulong steamID)
        {
            Write("SteamAPI_ISteamGameServer_EndAuthSession");
            SteamEmulator.SteamGameServer.EndAuthSession(steamID);
        }

        public static void SteamAPI_ISteamGameServer_CancelAuthTicket(IntPtr _, HAuthTicket hAuthTicket)
        {
            Write("SteamAPI_ISteamGameServer_CancelAuthTicket");
            SteamEmulator.SteamGameServer.CancelAuthTicket(hAuthTicket);
        }

        public static int SteamAPI_ISteamGameServer_UserHasLicenseForApp(IntPtr _, ulong steamID, AppId_t appID)
        {
            Write("SteamAPI_ISteamGameServer_UserHasLicenseForApp");
            return SteamEmulator.SteamGameServer.UserHasLicenseForApp(steamID, appID);
        }

        public static bool SteamAPI_ISteamGameServer_RequestUserGroupStatus(IntPtr _, ulong steamIDUser, ulong steamIDGroup)
        {
            Write("SteamAPI_ISteamGameServer_RequestUserGroupStatus");
            return SteamEmulator.SteamGameServer.RequestUserGroupStatus(steamIDUser, steamIDGroup);
        }

        public static void SteamAPI_ISteamGameServer_GetGameplayStats(IntPtr _)
        {
            Write("xxx");
            SteamEmulator.SteamGameServer.GetGameplayStats();
        }

        public static SteamAPICall_t SteamAPI_ISteamGameServer_GetServerReputation(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_GetServerReputation");
            return SteamEmulator.SteamGameServer.GetServerReputation();
        }

        public static uint SteamAPI_ISteamGameServer_GetPublicIP(IntPtr _, IntPtr instancePtr_possible)
        {
            Write("SteamAPI_ISteamGameServer_GetPublicIP");
            return (uint)SteamEmulator.SteamGameServer.GetPublicIP();
        }

        public static bool SteamAPI_ISteamGameServer_HandleIncomingPacket(IntPtr _, IntPtr pData, int cbData, uint srcIP, int srcPort)
        {
            Write("SteamAPI_ISteamGameServer_HandleIncomingPacket");
            return SteamEmulator.SteamGameServer.HandleIncomingPacket(pData, cbData, srcIP, (uint)srcPort);
        }

        public static int SteamAPI_ISteamGameServer_GetNextOutgoingPacket(IntPtr _, IntPtr pOut, int cbMaxOut, uint pNetAdr, uint pPort)
        {
            Write("SteamAPI_ISteamGameServer_GetNextOutgoingPacket");
            return SteamEmulator.SteamGameServer.GetNextOutgoingPacket(pOut, cbMaxOut, pNetAdr, pPort);
        }

        public static void SteamAPI_ISteamGameServer_EnableHeartbeats(IntPtr _, bool bActive)
        {
            Write("xxx");
            SteamEmulator.SteamGameServer.EnableHeartbeats(bActive);
        }

        public static void SteamAPI_ISteamGameServer_SetHeartbeatInterval(IntPtr _, int iHeartbeatInterval)
        {
            Write("SteamAPI_ISteamGameServer_SetHeartbeatInterval");
            SteamEmulator.SteamGameServer.SetHeartbeatInterval(iHeartbeatInterval);
        }

        public static void SteamAPI_ISteamGameServer_ForceHeartbeat(IntPtr _)
        {
            Write("SteamAPI_ISteamGameServer_ForceHeartbeat");
            SteamEmulator.SteamGameServer.ForceHeartbeat();
        }

        public static SteamAPICall_t SteamAPI_ISteamGameServer_AssociateWithClan(IntPtr _, ulong steamIDClan)
        {
            Write("SteamAPI_ISteamGameServer_AssociateWithClan");
            return SteamEmulator.SteamGameServer.AssociateWithClan(steamIDClan);
        }

        public static SteamAPICall_t SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility(IntPtr _, ulong steamIDNewPlayer)
        {
            Write("SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility");
            return SteamEmulator.SteamGameServer.ComputeNewPlayerCompatibility(steamIDNewPlayer);
        }






        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static HSteamUser SteamGameServer_GetHSteamUser()
        {
            Write("SteamGameServer_GetHSteamUser");
            return SteamEmulator.HSteamUser_GS;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static HSteamPipe SteamGameServer_GetHSteamPipe()
        {
            Write("SteamGameServer_GetHSteamPipe");
            return SteamEmulator.HSteamPipe_GS;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamGameServer_Init(uint unIP, int usGamePort, int usQueryPort, uint unFlags, uint nGameAppId, string pchVersionString)
        {
            Write("SteamGameServer_Init");
            return SteamEmulator.SteamGameServer.InitGameServer(unIP, usGamePort, usQueryPort, unFlags, nGameAppId, pchVersionString);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamGameServer_InitSafe(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString)
        {
            Write("SteamGameServer_InitSafe");
            return true;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamGameServer_Shutdown()
        {
            Write("SteamGameServer_Shutdown");
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamGameServer_RunCallbacks()
        {
            Write("SteamGameServer_RunCallbacks");
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamGameServer_BSecure()
        {
            Write("SteamGameServer_BSecure");
            return false;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static ulong SteamGameServer_GetSteamID()
        {
            Write("SteamGameServer_GetSteamID");
            return SteamEmulator.SteamId_GS.SteamID;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static ulong SteamGameServer_GetIPCCallCount()
        {
            Write("SteamGameServer_GetIPCCallCount");
            return SteamEmulator.SteamUtils.GetIPCCallCount();
        }

        private static void Write(string msg)
        {
            SteamEmulator.Write("", msg);
        }
    }
}