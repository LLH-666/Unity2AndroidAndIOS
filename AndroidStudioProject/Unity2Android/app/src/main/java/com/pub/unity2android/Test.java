package com.pub.unity2android;

import android.util.Log;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;

public class Test {
    public static String MyLog;

    public String Name;

    public static void SetLog(String log){
        MyLog=log;

        UnityPlayer.UnitySendMessage("Main","OnClickGetLogButton","");

        Log.d(MyLog,"SetLog:"+log);
    }

    public static String GetLog(){
        Log.d(MyLog,"GetLog:"+MyLog);
        return MyLog;
    }

    public void SetName(String name){
        Name=name;

        UnityPlayer.UnitySendMessage("Main","OnClickGetNameButton","");

        Log.d(Name,"SetName:"+name);
    }

    public String GetName(){
        Log.d(Name,"GetName:"+Name);
        return Name;
    }

    public void ShowToast(String message){
        Toast.makeText(UnityPlayer.currentActivity,message,Toast.LENGTH_LONG).show();
    }
}
