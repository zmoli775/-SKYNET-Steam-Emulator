﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    public enum CallbackType
    {
        k_iSteamUserCallbacks = 100,
        k_iSteamGameServerCallbacks = 200,
        k_iSteamFriendsCallbacks = 300,
        k_iSteamBillingCallbacks = 400,
        k_iSteamMatchmakingCallbacks = 500,
        k_iSteamContentServerCallbacks = 600,
        k_iSteamUtilsCallbacks = 700,
        k_iClientFriendsCallbacks = 800,
        k_iClientUserCallbacks = 900,
        k_iSteamAppsCallbacks = 1000,
        k_iSteamUserStatsCallbacks = 1100,
        k_iSteamNetworkingCallbacks = 1200,
        k_iClientRemoteStorageCallbacks = 1300,
        k_iClientDepotBuilderCallbacks = 1400,
        k_iSteamGameServerItemsCallbacks = 1500,
        k_iClientUtilsCallbacks = 1600,
        k_iSteamGameCoordinatorCallbacks = 1700,
        k_iSteamGameServerStatsCallbacks = 1800,
        k_iSteam2AsyncCallbacks = 1900,
        k_iSteamGameStatsCallbacks = 2000,
        k_iClientHTTPCallbacks = 2100,
        k_iClientScreenshotsCallbacks = 2200,
        k_iSteamScreenshotsCallbacks = 2300,
        k_iClientAudioCallbacks = 2400,
        k_iClientUnifiedMessagesCallbacks = 2500,
        k_iSteamStreamLauncherCallbacks = 2600,
        k_iClientControllerCallbacks = 2700,
        k_iSteamControllerCallbacks = 2800,
        k_iClientParentalSettingsCallbacks = 2900,
        k_iClientDeviceAuthCallbacks = 3000,
        k_iClientNetworkDeviceManagerCallbacks = 3100,
        k_iClientMusicCallbacks = 3200,
        k_iClientRemoteClientManagerCallbacks = 3300,
        k_iClientUGCCallbacks = 3400,
        k_iSteamStreamClientCallbacks = 3500,
        k_IClientProductBuilderCallbacks = 3600,
        k_iClientShortcutsCallbacks = 3700,
        k_iClientRemoteControlManagerCallbacks = 3800,
        k_iSteamAppListCallbacks = 3900,
        k_iSteamMusicCallbacks = 4000,
        k_iSteamMusicRemoteCallbacks = 4100,
        k_iClientVRCallbacks = 4200,
        k_iClientReservedCallbacks = 4300,
        k_iClientGameNotificationCallbacks = 4300,
        k_iSteamGameNotificationCallbacks = 4400,
        k_iSteamReservedCallbacks = 4400,
        k_iSteamHTMLSurfaceCallbacks = 4500,
        k_iClientVideoCallbacks = 4600,
        k_iClientInventoryCallbacks = 4700,
        k_iClientBluetoothManagerCallbacks = 4800,
        k_iClientSharedConnectionCallbacks = 4900,
        k_ISteamParentalSettingsCallbacks = 5000,
        k_iClientShaderCallbacks = 5100,
        k_iSteamGameSearchCallbacks = 5200,
        k_iSteamPartiesCallbacks = 5300,
        k_iClientPartiesCallbacks = 5400,
        k_iSteamSTARCallbacks = 5500,
        k_iClientSTARCallbacks = 5600,
        k_iSteamRemotePlayCallbacks = 5700,
        k_iClientCompatCallbacks = 5800,
    }
}