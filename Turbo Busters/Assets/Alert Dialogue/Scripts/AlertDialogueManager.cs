using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDialogueManager : SingletonBase<AlertDialogueManager>
{
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject pluginInstance;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlugins("package com.example.warning_plugin.PluginClass");
        CreateAlert();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializePlugins(string pluginName)
    {
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        pluginInstance = new AndroidJavaObject(pluginName);
        if(pluginInstance==null)
        {
            Debug.LogError("Plugin Instance is Null");
            return;
        }
        pluginInstance.CallStatic("recieveUnityActivity", unityActivity);
    }

    private void CreateAlert()
    {
        pluginInstance.Call("CreateAlert");
    }

    public void ShowAlert()
    {
        pluginInstance.Call("ShowAlert");
    }
}
