using UnityEngine;

public class LogReaderManager
{
    const string PACK_NAME = "com.pomelovolador.native_plugin";

    const string FILEMANAGER_CLASS_NAME = "FileManagerClass";

    static AndroidJavaClass FileManagerClass = null;

    static AndroidJavaObject FileManagerInstance = null;

    static AndroidJavaClass androidClass;

    static AndroidJavaObject unityActivity;

    public LogReaderManager()
    {
        InitializePlugin();
    }

    void InitializePlugin()
    {
        androidClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = androidClass.GetStatic<AndroidJavaObject>("currentActivity");
        FileManagerClass = new AndroidJavaClass(PACK_NAME + "." + FILEMANAGER_CLASS_NAME);
        FileManagerInstance = FileManagerClass.CallStatic<AndroidJavaObject>("GetInstance");
        FileManagerInstance.CallStatic("receiveUnityActivity", unityActivity);
    }

    public void WriteFile(string msg)
    {
        FileManagerInstance.CallStatic("WriteFile", msg);
    }
    public string ReadFile()
    {
        return FileManagerInstance.CallStatic<string>("ReadFile", " ");
    }
    public void ClearFile()
    {
        FileManagerInstance.CallStatic("ClearFile", " ");
    }
}
