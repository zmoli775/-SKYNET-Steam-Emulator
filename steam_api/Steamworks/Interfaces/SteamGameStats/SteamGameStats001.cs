﻿using SKYNET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Interface
{
    [Interface("SteamGameStats001")]
    public class SteamGameStats001 : ISteamInterface
    {
        public SteamAPICall_t RequestUserStats(IntPtr _, SteamID steamIDUser)
        {
            return SteamEmulator.SteamGameServerStats.RequestUserStats(steamIDUser);
        }

        public bool GetUserStat(IntPtr _, SteamID steamIDUser, string pchName, uint pData)
        {
            return SteamEmulator.SteamGameServerStats.GetUserStat(steamIDUser, pchName, pData);
        }

        public bool GetUserStat(IntPtr _, SteamID steamIDUser, string pchName, float pData)
        {
            return SteamEmulator.SteamGameServerStats.GetUserStat(steamIDUser, pchName, pData);
        }

        public bool GetUserAchievement(IntPtr _, SteamID steamIDUser, string pchName, bool pbAchieved)
        {
            return SteamEmulator.SteamGameServerStats.GetUserAchievement(steamIDUser, pchName, pbAchieved);
        }

        public bool SetUserStat(IntPtr _, SteamID steamIDUser, string pchName, uint nData)
        {
            return SteamEmulator.SteamGameServerStats.SetUserStat(steamIDUser, pchName, nData);
        }

        public bool SetUserStat(IntPtr _, SteamID steamIDUser, string pchName, float fData)
        {
            return SteamEmulator.SteamGameServerStats.SetUserStat(steamIDUser, pchName, fData);
        }

        public bool UpdateUserAvgRateStat(IntPtr _, SteamID steamIDUser, string pchName, float flCountThisSession, double dSessionLength)
        {
            return SteamEmulator.SteamGameServerStats.UpdateUserAvgRateStat(steamIDUser, pchName, flCountThisSession, dSessionLength);
        }

        public bool SetUserAchievement(IntPtr _, SteamID steamIDUser, string pchName)
        {
            return SteamEmulator.SteamGameServerStats.SetUserAchievement(steamIDUser, pchName);
        }

        public bool ClearUserAchievement(IntPtr _, SteamID steamIDUser, string pchName)
        {
            return SteamEmulator.SteamGameServerStats.ClearUserAchievement(steamIDUser, pchName);
        }

        public SteamAPICall_t StoreUserStats(IntPtr _, SteamID steamIDUser)
        {
            return SteamEmulator.SteamGameServerStats.StoreUserStats(steamIDUser);
        }
    }
}
