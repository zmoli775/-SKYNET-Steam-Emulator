﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SKYNET.Callback;
using SKYNET.Helper;
using SKYNET.Steamworks;
using Steamworks;
using SteamAPICall_t = System.UInt64;

namespace SKYNET.Managers
{
    public unsafe class CallbackManager
    {
        public static ConcurrentDictionary<CallbackType, SteamCallback> SteamCallbacks;
        public static ConcurrentDictionary<SteamAPICall_t, CallbackMessage> CallbackResults { get; set; }
        public static List<CallbackMessage> Callbacks { get; set; }

        public static SteamAPICall_t CurrentCall;

        private const int CallbackTimeOut = 20;

        static CallbackManager()
        {
            CurrentCall = 1000000000;

            SteamCallbacks = new ConcurrentDictionary<CallbackType, SteamCallback>();
            CallbackResults = new ConcurrentDictionary<SteamAPICall_t, CallbackMessage>();
            Callbacks = new List<CallbackMessage>();
        }

        public static void RegisterCallback(SteamCallback sCallback)
        {
            //if (sCallback.SteamAPICall == (ulong)new SteamAPICallCompleted_t().CallbackType)
            //{
            //    Write("Completeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeed");
            //}

            sCallback.Register();
            CallbackType callType = (CallbackType)sCallback.CallbackType;

            MutexHelper.Wait("SteamCallbacks", delegate
            {
                if (SteamCallbacks.ContainsKey(callType))
                {
                    Write($"RegisterCallback: SteamCallbacks contains key {callType}");
                    SteamCallbacks[callType] = sCallback;
                }
                else
                {
                    Write($"RegisterCallback: Creating new SteamCallbacks with key {callType}");
                    SteamCallbacks.TryAdd(callType, sCallback);
                }
            });
        }

        public static void RegisterCallResult(SteamCallback steamCallback)
        {
            MutexHelper.Wait("RegisterCallResult", delegate
            {
                try
                {
                    CallbackType callType = (CallbackType)steamCallback.CallbackBase.m_iCallback;

                    MutexHelper.Wait("SteamCallbacks", delegate
                    {
                        if (SteamCallbacks.ContainsKey(callType))
                        {
                            Write($"RegisterCallResult: SteamCallbacks contains key {callType}");
                            SteamCallbacks[callType] = steamCallback;
                        }
                        else
                        {
                            Write($"RegisterCallResult: Creating new SteamCallbacks with key {callType}");
                            SteamCallbacks.TryAdd(callType, steamCallback);
                        }
                    });

                }
                catch (Exception ex)
                {
                    Write($"Error in RegisterCallResult, {ex}");
                }
            });
        }

        public static SteamAPICall_t AddCallbackResult(ICallbackData data, bool readyToCall = true)
        {
            CurrentCall++;

            MutexHelper.Wait("CallbackResults", delegate
            {
                CallbackResults.TryAdd(CurrentCall, new CallbackMessage(data, readyToCall));
            });

            Write($"Added CallbackResult {CurrentCall} {((int)data.CallbackType).GetCallbackType()} {data.CallbackType} ");

            return CurrentCall;
        }

        public static void AddCallback(ICallbackData data, bool readyToCall = true)
        {
            MutexHelper.Wait("Callbacks", delegate
            {
                Callbacks.Add(new CallbackMessage(data, readyToCall));
            });

            Write($"Added Callback {CurrentCall} {((int)data.CallbackType).GetCallbackType()} {data.CallbackType} ");
        }

        public static void RunCallbacks()
        {
            MutexHelper.Wait("CallbackResults", delegate
            {
                foreach (var KV in CallbackResults)
                {
                    try
                    {
                        SteamAPICall_t APICall = KV.Key;
                        ICallbackData callbackData = KV.Value.Data;

                        if (!KV.Value.ReadyToCall)
                        {
                            goto Skip;
                        }

                        if (KV.Value.Called)
                        {
                            CallbackResults.TryRemove(APICall, out _);
                        }
                        else
                        {
                            MutexHelper.Wait("SteamCallbacks", delegate
                            {
                                if (SteamCallbacks.ContainsKey(callbackData.CallbackType))
                                {
                                    SteamEmulator.Debug($"Found callback {callbackData.CallbackType}");

                                    SteamCallback Callback = SteamCallbacks[callbackData.CallbackType];
                                    if (true)
                                    {

                                    }
                                    Callback.Run(callbackData, false, APICall);
                                    KV.Value.Called = true;
                                    Write($"Called function (IntPtr, bool, SteamAPICall_t) in {callbackData.CallbackType} callback");
                                }
                                else
                                {
                                    var Callback = SteamCallbacks.Where(c => c.Value.CallbackType == callbackData.CallbackType).Select(c => c.Value).FirstOrDefault();
                                    if (Callback != null)
                                    {
                                        Callback.Run(callbackData, false, APICall);
                                        KV.Value.Called = true;
                                        Write($"Called function (IntPtr, bool, SteamAPICall_t) in {callbackData.CallbackType} callback");

                                    }
                                    else
                                    {
                                        //SteamEmulator.Debug($"not found callback for {callbackData.CallbackType}", ConsoleColor.Green);
                                    }
                                }
                            });
                        }

                        Skip:;
                    }
                    catch (Exception ex)
                    {
                        Write("" + ex);
                    }
                }
            });

            MutexHelper.Wait("Callbacks", delegate
            {
                for (int i = 0; i < Callbacks.Count; i++)
                {
                    var callbackMessage = Callbacks[i];
                    if (callbackMessage.Called)
                    {
                        Callbacks.RemoveAt(i);
                    }
                    else
                    {
                        if (!callbackMessage.ReadyToCall)
                        {
                            goto Skip;
                        }

                        var data = callbackMessage.Data;
                        try
                        {
                            var Callback = SteamCallbacks.Where(c => c.Value.CallbackType == data.CallbackType).Select(c => c.Value).FirstOrDefault();
                            if (Callback != null)
                            {
                                Callback.Run(data);
                                callbackMessage.Called = true;
                                Write($"Called function Run(IntPtr) in {data.CallbackType} callback");
                            }
                            else
                            {
                                //SteamEmulator.Debug($"not found callback for {data.CallbackType}", ConsoleColor.Green);
                            }
                        }
                        catch (Exception ex)
                        {
                            Write("" + ex);
                        }

                        Skip:;
                    }
                }
            });
        }

        public static bool UnregisterCallResult(SteamCallback pCallback, ulong hAPICall)
        {
            return CallbackResults.TryRemove(hAPICall, out _);
        }

        public static bool IsCompleted(ulong hSteamAPICall)
        {
            bool Result = false;
            MutexHelper.Wait("SteamCallbacks", delegate
            {
                foreach (var callback in SteamCallbacks)
                {
                    if (callback.Value.SteamAPICall == hSteamAPICall)
                    {
                        Result = true;
                    }
                }
            });
            return Result;
        }

        public static bool UnregisterCallback(SteamCallback pCallback)
        {
            var Type = pCallback.CallbackType;
            return SteamCallbacks.TryRemove(Type, out _);
        }

        private static void Write(string v)
        {
            SteamEmulator.Write("CallbackManager", v);
        }
    }
}


