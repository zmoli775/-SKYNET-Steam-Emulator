﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SKYNET;
using SKYNET.Helper;
using SKYNET.Managers;
using SteamAPICall_t = System.UInt64;

namespace SKYNET.Steamworks.Implementation
{
    public class SteamUtils : ISteamInterface
    {
        SteamAPICall_t k_uAPICallInvalid = 0x0;
        public DateTime ActiveTime;

        public SteamUtils()
        {
            InterfaceName = "SteamUtils";
            InterfaceVersion = "SteamUtils009";
            ActiveTime = DateTime.Now;
        }

        public uint GetSecondsSinceAppActive()
        {
            Write("GetSecondsSinceAppActive");
            return (uint)(DateTime.Now - ActiveTime).Seconds;
        }

        public uint GetSecondsSinceComputerActive()
        {
            Write("GetSecondsSinceComputerActive");
            return (uint)modCommon.GetInactiveTimeSpan().Value.Seconds;
        }

        public int GetConnectedUniverse()
        {
            Write("GetConnectedUniverse");
            return (int)EUniverse.k_EUniversePublic;
        }

        public uint GetServerRealTime()
        {
            uint ServerTime = (uint)(new DateTimeOffset(DateTime.Now)).ToUnixTimeSeconds(); 
            Write($"GetServerRealTime");
            return ServerTime;
        }

        public string GetIPCountry()
        {
            Write("GetIPCountry");
            return "US";
        }

        public bool GetImageSize(int iImage, ref uint pnWidth, ref uint pnHeight)
        {
            Write($"GetImageSize");
            var Result = false;
            int Width = 0;
            int Height = 0;
            MutexHelper.Wait("GetImageSize", delegate
            {
                try
                {
                    var (width, height) = SteamEmulator.SteamFriends.GetImageSize(iImage);

                    if (width != 0 | height != 0)
                    {
                        Width  = width;
                        Height = height;
                        Result = true;
                    }
                }
                catch
                {

                }
            });

            pnWidth = (uint)Width;
            pnHeight = (uint)Height;
            return Result;
        }

        public bool GetImageRGBA(int iImage, IntPtr pubDest, int nDestBufferSize)
        {
            Write($"GetImageRGBA, {nDestBufferSize} bytes");
            var Result = false;

            MutexHelper.Wait("GetImageRGBA", delegate
            {
                try
                {
                    var avatar = SteamEmulator.SteamFriends.GetImageAvatar(iImage);
                    if (avatar != null)
                    {
                        byte[] bytes = avatar.GetImage(iImage);
                        if (nDestBufferSize > bytes.Length)
                        {
                            nDestBufferSize = bytes.Length;
                        }
                        Marshal.Copy(bytes, 0, pubDest, nDestBufferSize);
                        Result = true;
                    }
                }
                catch (Exception ex)
                {
                    Write("" + ex);
                }
            });

            return Result;
        }

        public bool GetCSERIPPort(uint unIP, uint usPort)
        {
            Write("GetCSERIPPort");
            return false;
        }

        public int GetCurrentBatteryPower()
        {
            Write("GetCurrentBatteryPower");
            return 100;
        }

        public uint GetAppID()
        {
            uint appId = SteamEmulator.AppId == 0 ? 570 : SteamEmulator.AppId;
            Write($"GetAppID {appId}");
            return appId;
        }

        public void SetOverlayNotificationPosition(int eNotificationPosition)
        {
            Write("SetOverlayNotificationPosition");
        }

        public bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, ref bool pbFailed)
        {
            bool Result = false;
            if (CallbackManager.IsCompleted(hSteamAPICall))
            {
                Result = true;
                pbFailed = false;
            }
            Write($"IsAPICallCompleted (SteamAPICall = {hSteamAPICall}) = {Result}");
            return Result;
        }

        public int GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
        {
            Write("GetAPICallFailureReason");
            return (int)ESteamAPICallFailure.k_ESteamAPICallFailureNone;
        }

        public bool GetAPICallResult(SteamAPICall_t handle, IntPtr callback, int callback_size, int callback_expected, ref bool failed)
        {
            try
            {
                Write($"GetAPICallResult {handle}");

                if (CallbackManager.CallbackResults.TryGetValue(handle, out var cMessage))
                {
                    callback_size = cMessage.Data.DataSize;
                    Marshal.StructureToPtr(cMessage.Data, callback, false);
                    failed = false;
                }
                failed = true;
                return false;
            }
            catch (Exception ex)
            {
                Write($"GetAPICallResult {ex}");
            }
            return false;
        }

        public void RunFrame()
        {
            Write("RunFrame");
        }

        public uint GetIPCCallCount()
        {
            Write("GetIPCCallCount");
            return (uint)new Random().Next(100, 200);
        }

        public void SetWarningMessageHook(IntPtr pFunction)
        {
            Write("SetWarningMessageHook");
        }

        public bool IsOverlayEnabled()
        {
            Write("IsOverlayEnabled");
            return true;
        }

        public bool BOverlayNeedsPresent()
        {
            Write("BOverlayNeedsPresent");
            return false;
        }

        public SteamAPICall_t CheckFileSignature(string szFileName)
        {
            Write("CheckFileSignature");
            // CheckFileSignature_t
            return k_uAPICallInvalid;
        }

        public bool ShowGamepadTextInput(int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
        {
            Write("ShowGamepadTextInput");
            return false;
        }

        public uint GetEnteredGamepadTextLength()
        {
            Write("GetEnteredGamepadTextLength");
            return 0;
        }

        public bool GetEnteredGamepadTextInput(string pchText, uint cchText)
        {
            Write("GetEnteredGamepadTextInput");
            return false;
        }

        public string GetSteamUILanguage()
        {
            Write("GetSteamUILanguage");
            return SteamEmulator.Language;
        }

        public bool IsSteamRunningInVR()
        {
            Write("IsSteamRunningInVR");
            return false;
        }

        public void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset)
        {
            Write("SetOverlayNotificationInset");
        }

        public bool IsSteamInBigPictureMode()
        {
            Write("IsSteamInBigPictureMode");
            return false;
        }

        public void StartVRDashboard()
        {
            Write("StartVRDashboard");
        }

        public bool IsVRHeadsetStreamingEnabled()
        {
            Write("IsVRHeadsetStreamingEnabled");
            return false;
        }

        public void SetVRHeadsetStreamingEnabled(bool bEnabled)
        {
            Write("SetVRHeadsetStreamingEnabled");
        }

        public bool IsSteamChinaLauncher()
        {
            Write("IsSteamChinaLauncher");
            return false;
        }

        public bool InitFilterText()
        {
            Write("InitFilterText");
            return false;
        }

        public int FilterText(string pchOutFilteredText, uint nByteSizeOutFilteredText, string pchInputMessage, bool bLegalOnly)
        {
            Write($"FilterText");
            return 0;
        }

        public int FilterText(int eContext, ulong sourceSteamID, string pchInputMessage, string pchOutFilteredText, uint nByteSizeOutFilteredText)
        {
            Write($"FilterText");
            return 0;
        }

        public int GetIPv6ConnectivityState(int eProtocol)
        {
            Write("GetIPv6ConnectivityState");
            return (int)ESteamIPv6ConnectivityState.k_ESteamIPv6ConnectivityState_Unknown;
        }
    }
}