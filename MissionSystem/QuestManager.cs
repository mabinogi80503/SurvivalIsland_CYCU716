using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class QuestManager : MonoBehaviour {
    private MissionDB db ;
    private List<QuestUnit> missionList;

    void Awake() {
        db = new MissionDB();
        missionList = new List<QuestUnit>();
    }
    public bool Add(int id) {
        if (Exist(id)) return false;
        missionList.Add(db.GetMission(id));
        return true;
    }  
    public bool Exist( int id ) {
        return missionList.Find( x => x.Id == id ) != null ;
    }
    public int GetMissionCount() {
        return missionList.Count;
    }

    public QuestUnit GetMission( int loc ) {
        if ( loc < GetMissionCount() )
            return missionList[loc];
        return null;
    }
    public void GetReward( int loc ) {
        QuestUnit m = GetMission(loc);
        if (m != null) {
            m.GetReward();
            missionList.Remove(m);
        }
    }

    public void UpdateFromEnemy( int id, int num ) {
        IEnumerable<QuestUnit> quests = from m in missionList where !m.IsComplete && m.NowTarget().Type == MissionTargetType.Kill select m ;
        Debug.Log(quests.Count<QuestUnit>());

        if (quests != null) {
            foreach (QuestUnit mission in quests) {
                if (!mission.IsComplete) {
                    mission.NowTarget().AddNum(id, num);
                    if (mission.NowTarget().ValueCheck()) {
                        mission.GoNextTarget();
                    }
                }           
            }
        }
    }
    public void UpdateFromCollection(int id, int num) {
        IEnumerable<QuestUnit> quests = from m in missionList where !m.IsComplete && m.NowTarget().Type == MissionTargetType.Collection select m;

        if (quests != null) {
            foreach (QuestUnit mission in quests) {
                mission.NowTarget().AddNum(id, num);
            }
        }
    }
}
