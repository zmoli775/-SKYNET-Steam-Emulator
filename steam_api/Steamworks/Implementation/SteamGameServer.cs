﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Core.Interface;
using SKYNET.Helper;
using SKYNET.Interface;
using Steamworks;

//[Map("SteamGameServer")]
public class SteamGameServer : IBaseInterface, ISteamGameServer
{
    public HSteamUser GetHSteamUser()
    {
        return (HSteamUser)1;
    }

    public HSteamPipe GetHSteamPipe()
    {
        return (HSteamPipe)1;
    }

    public void RunCallbacks()
    {

    }
}
