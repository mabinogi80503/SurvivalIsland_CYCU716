using UnityEngine;
using System.Collections;
using System;
public class EnemyBase {
    private int mHealth, mStamina;
    private int mAtk, mDef, mSpeed;
    private int mExp;

    public int Health {
        get { return mHealth; }
        protected set { mHealth = value; }
    }
    public int Stamina {
        get { return mStamina; }
        protected set { mStamina = value; }
    }

    public int Atk {
        get { return mAtk; }
        protected set { mAtk = value; }
    }
    public int Def {
        get { return mDef; }
        protected set { mDef = value; }
    }
    public int Exp {
        get { return mExp; }
        protected set { mExp = value; }
    }

    public EnemyBase(int health, int stamina, int atk, int def, int exp) {
        Health = health;
        Stamina = stamina;
        Atk = atk;
        Def = def;
        Exp = exp;
    }

    public void SHP(int num) {
        mHealth -= num;
    }
}
