using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic ;
using MiniJSON;

public class MissionDB {
    private List<QuestUnit> mMissionList ;

    public MissionDB() {
        mMissionList = new List<QuestUnit>();
        QuestUnit m = new QuestUnit(0, "觸碰柱子", "請碰一下柱子吧！", MissionType.Common );
        m.AddTarget(MissionTargetType.Kill, 0, 1).AddReward(MissionRewardType.AddHealth, 500f);
        mMissionList.Add(m);
        Debug.Log("CreateDB: MissionDB finished!");
	}

    private string ReadJSON() {
        return ((TextAsset)Resources.Load("Data/MissionDB")).text;
    }

    public QuestUnit GetMission( int id ) {
        QuestUnit m = mMissionList.Find(x => x.Id == id);
        return m != null ? m.DeepCopy() : null;
    }
}
