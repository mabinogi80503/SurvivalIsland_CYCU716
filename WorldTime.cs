using UnityEngine;
using System.Collections;

public class WorldTime : MonoBehaviour {
    public int Counter { get { return mCounter; } }
    public int SecPerDay = 600;
    private int mTrueTime;
    private int mCounter = 0;

    void Start() {
        mTrueTime = 86400 / SecPerDay;
        InvokeRepeating( "Timer", 0f, 1f );
    }

    public int CurrentDay { get{ return mCountDay;} }
    private int mCountDay = 1;
    void Timer() {
        if( mCounter >= 86400 ) { 
            mCountDay += 1;
            mCounter -= 86400;
            Debug.Log("Now Day is: "+mCountDay);
        }
        
        //Debug.Log(mCounter + ",  " + mCountDay);
        mCounter += mTrueTime;
    }
}
