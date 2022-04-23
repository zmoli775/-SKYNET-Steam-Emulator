﻿using SKYNET.Steamworks;
using System.Runtime.InteropServices;

namespace Steamworks
{
    [System.Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SteamIPAddress_t
    {
        private long m_ip0;
        private long m_ip1;

        private SteamIPType m_eType;

        public SteamIPAddress_t(System.Net.IPAddress iPAddress)
        {
            byte[] bytes = iPAddress.GetAddressBytes();
            switch (iPAddress.AddressFamily)
            {
                case System.Net.Sockets.AddressFamily.InterNetwork:
                    {
                        if (bytes.Length != 4)
                        {
                            throw new System.TypeInitializationException("SteamIPAddress_t: Unexpected byte length for Ipv4." + bytes.Length, null);
                        }

                        m_ip0 = (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3];
                        m_ip1 = 0;
                        m_eType = SteamIPType.Type4;
                        break;
                    }
                case System.Net.Sockets.AddressFamily.InterNetworkV6:
                    {
                        if (bytes.Length != 16)
                        {
                            throw new System.TypeInitializationException("SteamIPAddress_t: Unexpected byte length for Ipv6: " + bytes.Length, null);
                        }

                        m_ip0 = (bytes[1] << 56) | (bytes[0] << 48) | (bytes[3] << 40) | (bytes[2] << 32) | (bytes[5] << 24) | (bytes[4] << 16) | (bytes[7] << 8) | bytes[6];
                        m_ip1 = (bytes[9] << 56) | (bytes[8] << 48) | (bytes[11] << 40) | (bytes[10] << 32) | (bytes[13] << 24) | (bytes[12] << 16) | (bytes[15] << 8) | bytes[14];
                        m_eType = SteamIPType.Type6;
                        break;
                    }
                default:
                    {
                        throw new System.TypeInitializationException("SteamIPAddress_t: Unexpected address family " + iPAddress.AddressFamily, null);
                    }
            }
        }

        public System.Net.IPAddress ToIPAddress()
        {
            if (m_eType == SteamIPType.Type4)
            {
                byte[] bytes = System.BitConverter.GetBytes(m_ip0);
                return new System.Net.IPAddress(new byte[] { bytes[3], bytes[2], bytes[1], bytes[0] });
            }
            else
            {
                byte[] bytes = new byte[16];
                System.BitConverter.GetBytes(m_ip0).CopyTo(bytes, 0);
                System.BitConverter.GetBytes(m_ip1).CopyTo(bytes, 8);
                return new System.Net.IPAddress(bytes);
            }
        }

        public override string ToString()
        {
            return ToIPAddress().ToString();
        }

        public SteamIPType GetIPType()
        {
            return m_eType;
        }

        public bool IsSet()
        {
            return m_ip0 != 0 || m_ip1 != 0;
        }
    }
}

