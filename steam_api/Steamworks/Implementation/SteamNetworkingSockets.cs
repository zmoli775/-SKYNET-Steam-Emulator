﻿using SKYNET;
using SKYNET.Steamworks;
using SKYNET.Types;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


using HSteamNetConnection = System.UInt32;
using HSteamListenSocket = System.UInt32;

namespace SKYNET.Steamworks.Implementation
{
    
    public class SteamNetworkingSockets : ISteamInterface
    {
        private List<SocketConnection> Sockets;
        private int CurrentSocketID;

        public SteamNetworkingSockets()
        {
            InterfaceName = "SteamNetworkingSockets";
            InterfaceVersion = "SteamNetworkingSockets008";
            Sockets = new List<SocketConnection>();
            CurrentSocketID = 0;
        }

        public HSteamListenSocket CreateListenSocketIP(IntPtr localAddress, int nOptions, IntPtr pOptions)
        {
            Write("CreateListenSocketIP");
            SteamNetworkingIPAddr LocalAddress = Marshal.PtrToStructure<SteamNetworkingIPAddr>(localAddress);

            var socket = new SocketConnection()
            {
                SocketID = CurrentSocketID,
                Port = LocalAddress.m_port,
                VirtualPort = -1,
            };
            Sockets.Add(socket);
            CurrentSocketID++;
            return 0;
        }

        public HSteamNetConnection ConnectByIPAddress(IntPtr address, int nOptions, IntPtr pOptions)
        {
            Write("ConnectByIPAddress");
            return 0;
        }

        public HSteamListenSocket CreateListenSocketP2P(int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("CreateListenSocketP2P");
            return 0;
        }

        public HSteamNetConnection ConnectP2P(IntPtr identityRemote, int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("ConnectP2P");
            return 0;
        }

        public int AcceptConnection(HSteamNetConnection hConn)
        {
            Write("AcceptConnection");
            return default;
        }

        public bool CloseConnection(HSteamNetConnection hPeer, int nReason, char pszDebug, bool bEnableLinger)
        {
            Write("CloseConnection");
            return false;
        }

        public bool CloseListenSocket(HSteamListenSocket hSocket)
        {
            Write("CloseListenSocket");
            return false;
        }

        public bool SetConnectionUserData(HSteamNetConnection hPeer, ulong nUserData)
        {
            Write("SetConnectionUserData");
            return false;
        }

        public uint GetConnectionUserData(HSteamNetConnection hPeer)
        {
            Write("GetConnectionUserData");
            return 0;
        }

        public void SetConnectionName(HSteamNetConnection hPeer, char pszName)
        {
            Write("SetConnectionName");
        }

        public bool GetConnectionName(HSteamNetConnection hPeer, char pszName, int nMaxLen)
        {
            Write("GetConnectionName");
            return false;
        }

        public int SendMessageToConnection(HSteamNetConnection hConn, IntPtr pData, UInt32 cbData, int nSendFlags, Int64 pOutMessageNumber)
        {
            Write("SendMessageToConnection");
            return default;
        }

        public void SendMessages(int nMessages, IntPtr pMessages, Int64 pOutMessageNumberOrResult)
        {
            Write("SendMessages");
        }

        public int FlushMessagesOnConnection(HSteamNetConnection hConn)
        {
            Write("FlushMessagesOnConnection");
            return default;
        }

        public int ReceiveMessagesOnConnection(HSteamNetConnection hConn, IntPtr ppOutMessages, int nMaxMessages)
        {
            Write("ReceiveMessagesOnConnection");
            return 0;
        }

        public bool GetConnectionInfo(HSteamNetConnection hConn, IntPtr pInfo)
        {
            Write("GetConnectionInfo");
            return false;
        }

        public bool GetQuickConnectionStatus(HSteamNetConnection hConn, IntPtr pStats)
        {
            Write("GetQuickConnectionStatus");
            return false;
        }

        public int GetDetailedConnectionStatus(HSteamNetConnection hConn, char pszBuf, int cbBuf)
        {
            Write("GetDetailedConnectionStatus");
            return 0;
        }

        public bool GetListenSocketAddress(HSteamListenSocket hSocket, IntPtr address)
        {
            Write("GetListenSocketAddress");
            return false;
        }

        public bool CreateSocketPair(HSteamNetConnection pOutConnection1, uint pOutConnection2, bool bUseNetworkLoopback, IntPtr pIdentity1, IntPtr pIdentity2)
        {
            Write("CreateSocketPair");
            return false;
        }

        public bool GetIdentity(IntPtr pIdentity)
        {
            Write("GetIdentity");
            return false;
        }

        public int InitAuthentication()
        {
            Write("InitAuthentication");
            return (int)ESteamNetworkingAvailability.k_ESteamNetworkingAvailability_Current;
        }

        public int GetAuthenticationStatus(IntPtr pDetails)
        {
            Write("GetAuthenticationStatus");
            return (int)ESteamNetworkingAvailability.k_ESteamNetworkingAvailability_Current;
        }

        public uint CreatePollGroup()
        {
            Write("CreatePollGroup");
            return 0;
        }

        public bool DestroyPollGroup(uint hPollGroup)
        {
            Write("DestroyPollGroup");
            return false;
        }

        public bool SetConnectionPollGroup(HSteamNetConnection hConn, uint hPollGroup)
        {
            Write("SetConnectionPollGroup");
            return false;
        }

        public int ReceiveMessagesOnPollGroup(uint hPollGroup, IntPtr ppOutMessages, int nMaxMessages)
        {
            Write("ReceiveMessagesOnPollGroup");
            return 0;
        }

        public bool ReceivedRelayAuthTicket(IntPtr pvTicket, int cbTicket, IntPtr pOutParsedTicket)
        {
            Write("ReceivedRelayAuthTicket");
            return false;
        }

        public int FindRelayAuthTicketForServer(IntPtr identityGameServer, int nVirtualPort, IntPtr pOutParsedTicket)
        {
            Write("FindRelayAuthTicketForServer");
            return 0;
        }

        public HSteamNetConnection ConnectToHostedDedicatedServer(IntPtr identityTarget, int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("ConnectToHostedDedicatedServer");
            return 0;
        }

        public int GetHostedDedicatedServerPort()
        {
            Write("GetHostedDedicatedServerPort");
            return 0;
        }

        public uint GetHostedDedicatedServerPOPID()
        {
            Write("GetHostedDedicatedServerPOPID");
            return 0;
        }

        public int GetHostedDedicatedServerAddress(IntPtr pRouting)
        {
            Write("GetHostedDedicatedServerAddress");
            return 0;
        }

        public HSteamListenSocket CreateHostedDedicatedServerListenSocket(int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("CreateHostedDedicatedServerListenSocket");
            return 0;
        }

        public int GetGameCoordinatorServerLogin(IntPtr pLoginInfo, int pcbSignedBlob, IntPtr pBlob)
        {
            Write("GetGameCoordinatorServerLogin");
            // SteamDatagramGameCoordinatorServerLogin pLoginInfo
            return default;
        }

        public HSteamNetConnection ConnectP2PCustomSignaling(IntPtr pSignaling, IntPtr pPeerIdentity, int nOptions, IntPtr pOptions)
        {
            Write("ConnectP2PCustomSignaling");
            return 0;
        }

        public bool ReceivedP2PCustomSignal(IntPtr pMsg, int cbMsg, IntPtr pContext)
        {
            Write("ReceivedP2PCustomSignal");
            return false;
        }

        public bool GetCertificateRequest(int pcbBlob, IntPtr pBlob, string errMsg)
        {
            Write("GetCertificateRequest");
            return false;
        }

        public bool SetCertificate(IntPtr pCertificate, int cbCertificate, string errMsg)
        {
            Write($"SetCertificate {errMsg}");
            return false;
        }

        public void RunCallbacks(IntPtr pCallbacks)
        {
            Write("RunCallbacks");
        }

        public bool SteamDatagramClient_Init(bool bNoSteamSupport, IntPtr errMsg)
        {
            Write("SteamDatagramClient_Init");
            return true;
        }

        public bool SteamDatagramServer_Init(bool bNoSteamSupport, IntPtr errMsg)
        {
            Write("SteamDatagramServer_Init");
            return true;
        }

        internal void ResetIdentity(IntPtr pIdentity)
        {
            Write("ResetIdentity");
        }

        internal void RunCallbacks()
        {
            Write("RunCallbacks");
        }

        internal bool BeginAsyncRequestFakeIP(int nNumPorts)
        {
            Write("BeginAsyncRequestFakeIP");
            return true;
        }

        internal void GetFakeIP(int idxFirstPort, IntPtr pInfo)
        {
            Write("GetFakeIP");
        }

        internal uint CreateListenSocketP2PFakeIP(int idxFakePort, int nOptions, IntPtr pOptions)
        {
            Write("CreateListenSocketP2PFakeIP");
            return 0;
        }

        internal int GetRemoteFakeIPForConnection(uint hConn, SteamNetworkingIPAddr pOutAddr)
        {
            Write("GetRemoteFakeIPForConnection");
            return (int)EResult.k_EResultOK;
        }

        internal IntPtr CreateFakeUDPPort(int idxFakeServerPort)
        {
            Write("CreateFakeUDPPort");
            return IntPtr.Zero;
        }

        internal class SocketConnection
        {
            public int SocketID { get; set; }
            public ushort Port { get; set; }
            public int VirtualPort { get; set; }
        }
    }
}