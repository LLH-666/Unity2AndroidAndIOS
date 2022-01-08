package com.pub.unity2android;

import android.os.Bundle;
import android.util.Log;

import com.unity3d.player.UnityPlayerActivity;

public class TestActivity extends UnityPlayerActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Log.d("sf","TestActivity:onCreate");
    }

    @Override
    protected void onPause() {
        super.onPause();

        Log.d("sf","TestActivity:onPause");
    }

    @Override
    protected void onResume() {
        super.onResume();

        Log.d("sf","TestActivity:onResume");
    }
}

