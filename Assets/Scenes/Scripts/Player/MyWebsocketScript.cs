using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;
using System.IO;
using static MyWebsocketScript;

public class MyWebsocketScript : MonoBehaviour
{
    WebSocket websocket;
    OSC osc;

    ArrayList newMessages;

    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class TrackedBody
    {
        public Position positionTracked;
        public string trackedGesture;
        public Dictionary<string, Position> trackedSkeleton;
        public List<GestureStat> gestureStat;
        public string bodyId;
    }

    [System.Serializable]
    public class GestureStat
    {
        public string gesture;
        public float stat;
    }

    [System.Serializable]
    public class KinectData
    {
        public string ID;
        public string IP;
        public List<TrackedBody> trackedBodies;
        public List<string> trackingGestureNames;
        public float kinectPitch;
    }

    [System.Serializable]
    public class TranslatedBody
    {
        public float x;
        public float y;
        public float z;
        public string fromKinect;
        public string trackedGesture;
    }

    [System.Serializable]
    public class KinectPosition
    {
        public int x;
        public int y;
        public int rotation;
    }

    [System.Serializable]
    public class RootObject
    {
        public KinectData data;
        public string sourceIP;
        public string ID;
        public List<TranslatedBody> translatedBodies;
        public KinectPosition kinectPosition;
        public int trackingBodiesCount;
    }

    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("start socket");
        websocket = new WebSocket("ws://127.0.0.1:9997");



        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {
            Debug.Log("OnMessage!");
            Debug.Log(bytes.Length);
            ArrayList newMessages = OSC.PacketToOscMessages(bytes, bytes.Length);
            //Debug.Log("OnMessage! " + newMessages[0]);
            byte[] receivedData = bytes;
            string jsonString = System.Text.Encoding.UTF8.GetString(receivedData);
            //RootObject rootObject = JsonUtility.FromJson<RootObject>(jsonString);
            GestureStat gesture = JsonUtility.FromJson<GestureStat>(jsonString);
            TrackedBody trackedBody = JsonUtility.FromJson<TrackedBody>(jsonString);

            // Now you can access the data using the generated C# classes, for example:
            Debug.Log("TrackedBody ID: " + trackedBody.bodyId);
            Debug.Log("GestureStat Gesture: " + gesture.gesture);
            //Debug.Log("Rootobject ID: " + rootObject.ID);
        };
        // waiting for messages
        await websocket.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif


    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }

}