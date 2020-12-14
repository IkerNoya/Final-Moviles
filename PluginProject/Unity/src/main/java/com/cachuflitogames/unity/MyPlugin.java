package com.cachuflitogames.unity;

import android.util.Log;

public class MyPlugin {
    private static final MyPlugin instance = new MyPlugin();
    private static final String LOGTAG = "Cachuflito";

    public static MyPlugin getInstance(){return instance;}

    private long startTime;

    private MyPlugin(){
        Log.i(LOGTAG, "Created MyPlugin");
        startTime = System.currentTimeMillis();
    }
    public double getElapsedTime()
    {
        return (System.currentTimeMillis()-startTime)/1000.0f;
    }
}
