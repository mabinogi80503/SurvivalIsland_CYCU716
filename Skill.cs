using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill : MonoBehaviour {
    private string mName ;
    private char mType ;
    private int mLevel ;
    private int mIDofSkill ;
    private bool mUse;
    public Skill() {
        mLevel = 1;
        mIDofSkill = 0;
        mUse = false;
        mEXP = 0;
        //mEffectChain = new List<Effect>();
    }

    public int ID { 
        get { return mIDofSkill ; } 
        set { mIDofSkill = value ; }
    }

    public string Name { 
        get { return mName ; }
        set { mName = value ; }
    }

    public int Level {
        get { return mLevel; }
        set { mLevel = value;  }
    }

    public char Type {
        // A = active
        // P = passive
        get { return mType; }
        set { mType = value; }
    }
    public bool CanUse { 
        get { return mUse; }
        set { mUse = value; }
    }

    //----------------------------------------------EXP-----------------------------------------------
    private int mEXP;
    private int mEXP_MAX;                           //此為"目前"等級要到下等級所需的EXP量
    private void EXP_check() {                      //確認EXP是否到達可升級EXP量
        if (mEXP >= mEXP_MAX) {
            mEXP -= mEXP_MAX;
            mLevel++;
        }
    }
    public int EXP_now { get { return mEXP; } }
    public int EXP_add { set { mEXP += value; } }
    public int EXP_MAX {
        get { return mEXP_MAX; } 
        set { mEXP_MAX = mLevel * 100 ; }           //公式可修改，此為"目前"等級要到下等級所需的EXP量
    }
    public int EXP_last { get { return mEXP_MAX - mEXP; } }
    //-----------------------------------basic value set END------------------------------------------

    //List<Effect> mEffectChain;

    public void SetEffect() {

    }
    public void Do(GameObject target) {
        
    }
}
