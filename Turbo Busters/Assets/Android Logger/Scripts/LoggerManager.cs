using System;
using UnityEngine;
using UnityEngine.Events;

public class LoggerManager : SingletonBase<LoggerManager>
{
    private AndroidLoggerManager androidLogs;
    private LogReaderManager fileManagerAndroid;

    public void MyStart()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        androidLogs = new AndroidLoggerManager();
        fileManagerAndroid = new LogReaderManager();
        androidLogs.OnAndroidCall += fileManagerAndroid.WriteFile;
    }
    private void WriteFile(string msg)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        fileManagerAndroid.WriteFile(msg + '\n');
    }
    public void SendLog(string msg)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        androidLogs.AndroidLog(msg);
        WriteFile(msg);
    }
    public void CallClear()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        fileManagerAndroid.ClearFile();
    }
    public string GetFile()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return "";
        }
        return fileManagerAndroid.ReadFile();
    }
}
