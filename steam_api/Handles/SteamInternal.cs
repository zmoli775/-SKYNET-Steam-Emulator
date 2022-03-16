﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET;
using SKYNET.Interface;
using SKYNET.Types;

public class SteamInternal : BaseCalls
{
    [DllExport(CallingConvention = CallingConvention.Cdecl)]
    public static IntPtr SteamInternal_FindOrCreateUserInterface(IntPtr hSteamUser, IntPtr pszVersion)
    {
        Write($"SteamInternal_FindOrCreateUserInterface {pszVersion}");
        string version = Marshal.PtrToStringBSTR(pszVersion);
        return SteamEmulator.SteamClient.GetISteamGenericInterface(SteamEmulator.HSteamUser, SteamEmulator.HSteamPipe, version);
    }

    [DllExport(CallingConvention = CallingConvention.Cdecl)]
    public static IntPtr SteamInternal_FindOrCreateGameServerInterface(IntPtr hSteamUser, IntPtr pszVersion)
    {
        Write($"SteamInternal_FindOrCreateGameServerInterface {pszVersion}");
        return InterfaceManager.FindOrCreateGameServerInterface(hSteamUser, pszVersion);
    }

    [DllExport(CallingConvention = CallingConvention.Cdecl)]
    public static IntPtr SteamInternal_ContextInit(IntPtr pContextInitData)
    {
        ContextInitData contextInitData = Marshal.PtrToStructure<ContextInitData>(pContextInitData);

        Write($"SteamInternal_ContextInit Counter: {contextInitData.counter}, Context pointer: {contextInitData.Context}");

        var LUser = SteamEmulator.HSteamUser;
        if (contextInitData.counter != LUser.m_HSteamUser)
        {
            contextInitData.counter = (uint)LUser.m_HSteamUser;

            var ptr_size = Marshal.SizeOf(typeof(IntPtr));
            // Allocate enough space for the new pointers in local memory
            var vtable = Marshal.AllocHGlobal(ptr_size);
            // Write the pointer to the vtable at the address pointed to by new_context;
            Marshal.WriteIntPtr(contextInitData.Context, vtable);
        }
        return pContextInitData;
    }

    public struct ContextInitData
    {
        public IntPtr Context;
        public uint counter;
    }


    [DllExport(CallingConvention = CallingConvention.Cdecl)]
    public static IntPtr SteamInternal_CreateInterface(IntPtr version)
    {
        Write($"SteamInternal_CreateInterface {version}");
        return InterfaceManager.CreateInterface(version);
    }

    [DllExport(CallingConvention = CallingConvention.Cdecl)]
    public static bool SteamInternal_GameServer_Init(IntPtr unIP, IntPtr usPort, IntPtr usGamePort, IntPtr usQueryPort, IntPtr eServerMode, IntPtr pchVersionString)
    {
        Write($"SteamInternal_GameServer_Init");
        return true;
    }
}