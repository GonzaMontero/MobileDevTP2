using UnityEngine;

public class AndroidLoggerManager
{
    const string PACK_NAME = "com.example.logger_plugin";

    const string LOGGER_CLASS_NAME = "PluginClass";

    static AndroidJavaClass JLoggerClass = null;

    static AndroidJavaObject JLoggerInstance = null;

    public System.Action<string> OnAndroidCall;

    public AndroidLoggerManager()
    {
        InitializePlugin();
    }

    protected void InitializePlugin()
    {
        JLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        JLoggerInstance = JLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        Application.logMessageReceived += HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        AndroidLog(logString);
    }

    public void AndroidLog(string log)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        JLoggerInstance.Call("SendLog", log);
        OnAndroidCall?.Invoke(log);
    }
}