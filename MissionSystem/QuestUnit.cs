using UnityEngine;
using System.Collections.Generic;

public class QuestUnit {
    private int mID;
    private string mName;
    private string mDetail;
    private MissionType mType;

    private List<TargetAtom> mTargets;
    private int mNowTarget = -1 ;

    private bool mIsComplete = false;
    private List<RewardAtom> mRewards;

    public int Id {
        get { return mID; }
        set { mID = value; }
    }
    public string Name {
        get { return mName; }
        set { mName = value; }
    }

    public string Detail {
        get { return mDetail; }
        set { mDetail = value; }
    }
    public MissionType Type {
        get { return mType; }
        set { mType = value; }
    }

    public bool IsComplete {
        get { return mIsComplete; } 
    }
    public QuestUnit() {
        mID = -1;
        mName = string.Empty;
        mDetail = string.Empty;
        mType = MissionType.Undefined;
        mTargets = new List<TargetAtom>();
        mRewards = new List<RewardAtom>();
    }
    public QuestUnit(int id, string name, string detail, MissionType type) {
        mID = id;
        mName = name;
        mDetail = detail ;
        mType = type;
        mTargets = new List<TargetAtom>();
        mRewards = new List<RewardAtom>();
    }

    public QuestUnit AddTarget(MissionTargetType type, int id, int number) {
        TargetAtom mt = null ;
        if ( MissionTargetType.Kill == type )
            mt = new TargetAtom(id, number).SetType(MissionTargetType.Kill);
        else if (MissionTargetType.Collection == type)
            mt = new TargetAtom(id, number).SetType(MissionTargetType.Collection);
        else
            mt = new TargetAtom(id, number).SetType(MissionTargetType.UnDefined);

        mTargets.Add(mt);
        Debug.Log("Add One Target: ID = " + id + ", Number = " + number);
        return this;
    }
    public QuestUnit AddReward(MissionRewardType type, float value) {
        RewardAtom mr = new RewardAtom( type, value );
        mRewards.Add(mr);
        return this;
    }
    public TargetAtom NowTarget() {
        if (mNowTarget == -1)
            mNowTarget = 0;

        if (!IsComplete)
            return mTargets[mNowTarget];
        else
            return null;
    }

    public void GoNextTarget() {
        if (mTargets[mNowTarget].ValueCheck()) { 
            mNowTarget++;
            if (mNowTarget == mTargets.Count) {
                mIsComplete = true;
                Debug.Log("Mission Completed!!");
            }
        }
    }
    public void GetReward() {
        foreach(RewardAtom mr in mRewards) {
            mr.GetReward();
        }
    }
    public QuestUnit DeepCopy() {
        QuestUnit othercopy = (QuestUnit)this.MemberwiseClone();
        return othercopy;
    }
}

public enum MissionType {
    Undefined,
    Common,
    MainLineCH1 
}
