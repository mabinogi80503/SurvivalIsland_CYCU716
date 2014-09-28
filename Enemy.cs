using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    EnemyBase eb;
	void Start () {
        eb = new EnemyBase(10, 0, 0, 0, 0);
	}
    public void HPF(int num) {
        eb.SHP(num);
    }

	void Update () {
	}

    void OnTriggerEnter( Collider c ) {
        if (c.gameObject.tag == "Player") {
            QuestManager mc = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestManager>() ;
            if (mc.GetMissionCount() != 0) {
                mc.UpdateFromEnemy(0, 1);
            }
        }
    }
}
