package com.example.log_reader_plugin;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.util.Log;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.OutputStreamWriter;
import java.io.InputStreamReader;
import java.io.InputStream;
import java.io.IOException;

public class PluginClass extends Application {

    private static final String LOGTAG = "UnityAndroidPlugin=>";

    public  static  final PluginClass _instance = new PluginClass();

    public  static  PluginClass GetInstance(){
        return _instance;
    }

    private static Activity unityActivity;

    public static void receiveUnityActivity(Activity tActivity){
        unityActivity = tActivity;
    }


    public static void WriteFile(String a){
        Context mycontext = unityActivity.getApplicationContext();
        try {
            OutputStreamWriter outputStreamWriter= new OutputStreamWriter(mycontext.openFileOutput("logs", Context.MODE_APPEND));

            outputStreamWriter.write(a + "\n");
            outputStreamWriter.close();

            Log.d(LOGTAG, "File Written Succesfully");
        }
        catch (IOException e) {
            Log.e(LOGTAG, "error: " +e.toString());
        }
    }

    public static String ReadFile(String a){
        Context context = unityActivity.getApplicationContext();

        String ret = "";

        try {
            InputStream inputStream = context.openFileInput("logs");

            if ( inputStream != null ) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString = "";
                StringBuilder stringBuilder = new StringBuilder();

                while ( (receiveString = bufferedReader.readLine()) != null ) {
                    stringBuilder.append("\n").append(receiveString);
                }

                inputStream.close();
                ret = stringBuilder.toString();
            }

            Log.d(LOGTAG, "Se lee el archive");
        }
        catch (FileNotFoundException e) {
            Log.e(LOGTAG, "Error: " + e.toString());
        } catch (IOException e) {
            Log.e(LOGTAG, "Error: " + e.toString());
        }

        return ret;
    }

    public static void ClearFile(String a){
        Context context = unityActivity.getApplicationContext();
        context.deleteFile("logs");
        WriteFile("");
    }

}