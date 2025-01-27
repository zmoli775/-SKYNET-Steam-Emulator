﻿
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SKYNET.Callback
{
    [StructLayout(LayoutKind.Sequential)]
    public class CCallbackBase
    {
        public const byte k_ECallbackFlagsRegistered = 1;

        public const byte k_ECallbackFlagsGameServer = 2;

        public IntPtr m_vfptr;

        public byte m_nCallbackFlags;

        public int m_iCallback;
    }
}
