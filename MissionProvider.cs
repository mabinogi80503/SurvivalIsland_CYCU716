using UnityEngine;
using System.Collections;

public class MissionProvider : MonoBehaviour {
    private QuestManager mc;
	void Start () {
        GameObject.FindGameObjectWithTag( "Player" ).GetComponent<PlayerCharacter>().GetVitalAttr( "Health" ).DecreaseCurValue( 1000f );
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestManager>();
        mc.Add(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        if (mc.GetMission(0) != null) {
            GUI.Label(new Rect(10, 500, 200, 35), "Mission[" + mc.GetMission(0).Name + "]" );
            GUI.Label(new Rect(10, 535, 200, 35), "Detail ["+ mc.GetMission(0).Detail + "]" );
            if (mc.GetMission(0).IsComplete)
                GUI.Label(new Rect(10, 570, 200, 35), "任務完成!!!");
            else
                GUI.Label(new Rect(10, 570, 200, 35), "任務未完成!!!");
        } 
    }
}
