using UnityEngine;
using System.Collections;

public class RewardAtom {
    private MissionRewardType mType;
    private float mValue;


    public MissionRewardType Type {
        get { return mType; }
        private set { mType = value; }
    }

    public float Value {
        get { return mValue; }
        private set { mValue = value; }
    }

    public RewardAtom (MissionRewardType type, float value) {
        Type = type;
        Value = value;
    }

    public void GetReward() {
        PlayerCharacter pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        if (pc != null) {
            switch (Type) {
                case MissionRewardType.AddExp :
                    pc.AddExp((int)mValue);
                    break;
                case MissionRewardType.AddHealth:
                    pc.GetVitalAttr( "Health" ).IncreaseCurValue( mValue );
                    break;
                case MissionRewardType.AddStamina:
                    pc.GetVitalAttr( "Stamina" ).IncreaseCurValue( mValue );
                    break;
                case MissionRewardType.AddMental:
                    pc.GetVitalAttr( "Mental" ).IncreaseCurValue( mValue );
                    break;
                default:
                    break;
            }
        }
    }
}

public enum MissionRewardType {
    AddExp,
    AddHealth,
    AddStamina,
    AddMental
}
