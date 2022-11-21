package com.example.logger_plugin;

import android.app.Activity;
import android.util.Log;


public class PluginClass {

    private static final String LOGTAG = "UnityAndroidPlugin=>";

    public  static  final PluginClass _instance = new PluginClass();

    public  static  PluginClass GetInstance(){
        return _instance;
    }

    public  void SendLog(String msg){
        Log.d( LOGTAG, msg);
    }

}
