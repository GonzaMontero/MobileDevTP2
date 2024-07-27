using Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AndroidPluginCallback : AndroidJavaProxy
{
    public AndroidPluginCallback() : base("com.example.warning_plugin.PluginCallback") { }

    public bool OnPositive(string message)
    {
        return true;
    }

    public bool OnNegative(string message)
    {
        return false;

    }
}

public class AlertDialogueManager : Singleton<AlertDialogueManager>
{
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject pluginInstance;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlugins("com.example.warning_plugin.PluginClass");
        CreateAlert();
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
        pluginInstance.Call("CreateAlert", new AndroidPluginCallback());
    }

    public void ShowAlert()
    {
        pluginInstance.Call("ShowAlert");
    }
}
