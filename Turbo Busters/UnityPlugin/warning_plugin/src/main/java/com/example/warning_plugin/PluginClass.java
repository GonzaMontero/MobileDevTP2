package com.example.warning_plugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

public class PluginClass {

    private static  final String LOGTAG ="UnityPlugin";
    private static Activity unityActivity;

    AlertDialog.Builder builder;

    public static void recieveUnityActivity(Activity tActivity){
        unityActivity = tActivity;
    }

    public void CreateAlert(PluginCallback alertCallback){
        builder=new AlertDialog.Builder(unityActivity);
        builder.setMessage("Are you sure you want to delete the logs?");
        builder.setCancelable((true));
        builder.setPositiveButton("Yes",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        alertCallback.onPositive("Clicked Yes");
                        dialog.cancel();
                    }
                });
        builder.setNegativeButton("No",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        alertCallback.onNegative("Clicked No");
                        dialog.cancel();
                    }
                });

    }

    public void ShowAlert(){
        AlertDialog alert = builder.create();
        alert.show();
    }
}