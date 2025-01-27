﻿
namespace SKYNET.Steamworks.Implementation
{
    public class SteamParentalSettings : ISteamInterface
    {
        public SteamParentalSettings()
        {
            InterfaceName = "SteamParentalSettings";
            InterfaceVersion = "STEAMPARENTALSETTINGS_INTERFACE_VERSION001";
        }

        public bool BIsParentalLockEnabled()
        {
            Write("boolBIsParentalLockEnabled");
            return false;
        }

        public bool BIsParentalLockLocked()
        {
            Write("boolBIsParentalLockLocked");
            return false;
        }

        public bool BIsAppBlocked(uint nAppID)
        {
            Write("boolBIsAppBlocked");
            return false;
        }

        public bool BIsAppInBlockList(uint nAppID)
        {
            Write("boolBIsAppInBlockList");
            return false;
        }

        public bool BIsFeatureBlocked(int eFeature)
        {
            Write("BIsFeatureBlocked");
            return false;
        }

        public bool BIsFeatureInBlockList(int eFeature)
        {
            Write("boolBIsFeatureInBlockList");
            return false;
        }
    }
}