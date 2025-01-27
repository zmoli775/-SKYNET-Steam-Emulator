﻿using SKYNET.Callback;
using SKYNET.Helper;
using SKYNET.Steamworks;
using System;
using System.Runtime.InteropServices;

using SteamAPICall_t = System.UInt64;

namespace SKYNET.Callback
{
    public class SteamCallback
    {
        public const byte k_ECallbackFlagsRegistered = 1;
        public const byte k_ECallbackFlagsGameServer = 2;

        public CallbackType CallbackType { get; set; }
        public CallbackType BaseType { get { return ((int)CallbackType).GetCallbackType(); } }
        public bool Completed { get; set; }
        public IntPtr Pointer { get; }
        public CCallbackBase CallbackBase { get; }
        //public SteamAPICall_t SteamAPICall { get; set; }
        public ulong SteamAPICall { get; set; }
        public bool HasGameserver => (CallbackBase.m_nCallbackFlags & CCallbackBase.k_ECallbackFlagsGameServer) != 0;
        public bool HasResult { get; set; }
        public DateTime Created { get; set; }

        private CCallResult CallResult { get; set; }

        public SteamCallback(IntPtr _pointer, bool hasResult = false)
        {
            Pointer = _pointer;
            CallbackBase = _pointer.ToType<CCallbackBase>();
            Created = DateTime.Now;
            HasResult = hasResult;
            CallbackType = (CallbackType)CallbackBase.m_iCallback;

            CallResult = CallbackBase.m_vfptr.ToType<CCallResult>();
        }

        public SteamCallback(IntPtr _pointer, int iCallback, bool hasResult = false)
        {
            Pointer = _pointer;
            CallbackBase = _pointer.ToType<CCallbackBase>();
            CallbackBase.m_iCallback = iCallback;
            CallbackType = (CallbackType)iCallback;
            Created = DateTime.Now;
            HasResult = hasResult;

            CallResult = CallbackBase.m_vfptr.ToType<CCallResult>();
        }

        public void Run(ICallbackData data)
        {
            IntPtr pvParam = Marshal.AllocHGlobal(data.DataSize);
            Marshal.StructureToPtr(data, pvParam, false);

            Run(pvParam);
        }

        public void Run(ICallbackData data, bool bIOFailure, ulong hSteamAPICall)
        {
            IntPtr pvParam = Marshal.AllocHGlobal(data.DataSize);
            Marshal.StructureToPtr(data, pvParam, false);

            if (HasResult)
            {
                Run(pvParam, bIOFailure, hSteamAPICall);
            }
            else
            {
                Run(pvParam);
            }


            //SKYNET.Callback.SteamAPICallCompleted_t completedData = new SKYNET.Callback.SteamAPICallCompleted_t()
            //{
            //    m_hAsyncCall = hSteamAPICall,
            //    m_iCallback = (int)data.CallbackType,
            //    m_cubParam = (uint)data.DataSize
            //};

            //IntPtr pvParam2 = Marshal.AllocHGlobal(completedData.DataSize);
            //Marshal.StructureToPtr(completedData, pvParam2, false);
            //Run(pvParam2, bIOFailure, hSteamAPICall);
            //Run(pvParam2);
        }

        public void Run(IntPtr pvParam)
        {
            CallResult.m_RunCallback(IntPtr.Zero, pvParam);
        }

        public void Run(IntPtr pvParam, bool bIOFailure, ulong hSteamAPICall)
        {
            CallResult.m_RunCallResult(IntPtr.Zero, pvParam, bIOFailure, (ulong)hSteamAPICall);
        }

        public void Update()
        {
            Marshal.StructureToPtr(CallbackBase, Pointer, false);
        }

        public void Register()
        {
            CallbackBase.m_nCallbackFlags |= k_ECallbackFlagsRegistered;
            CallbackBase.m_iCallback = (int)CallbackType;
            Update();
        }
        public void Unregister()
        {
            CallbackBase.m_nCallbackFlags &= k_ECallbackFlagsRegistered;
            Update();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CCallResult
        {
            public CCallbackBaseVTable.RunCRDel m_RunCallResult;
            public CCallbackBaseVTable.RunCBDel m_RunCallback;
            public IntPtr m_GetCallbackSizeBytes;
        }
    }

}
