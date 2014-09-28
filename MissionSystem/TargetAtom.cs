using UnityEngine;
using System.Collections;

public class TargetAtom {
    private MissionTargetType mTargetType;
    private int mTargetID;
    private int mNumber;
    private int mNowNumber;

    public MissionTargetType Type {
        get { return mTargetType; }
    }
    public int Number {
        get { return (Type != MissionTargetType.UnDefined)? mNumber : -1 ; }
        private set { mNumber = value; }
    }
    public int TargetID {
        get { return mTargetID; }
        private set { mTargetID = value; }
    }

    public int NowNumber {
        get { return mNowNumber; }
    }

    public TargetAtom(int id, int number) {
        mNowNumber = 0;
        TargetID = id;
        mNumber = number;
        mTargetType = MissionTargetType.UnDefined;
        Debug.Log("ID = " + id + ", Number = " + number);
    }
    public TargetAtom SetType(MissionTargetType type) {
        mTargetType = type;
        return this;
    }
    public bool ValueCheck() {
        return NowNumber == mNumber;
    }

    public void AddNum( int id, int num ) {
        if (TargetID == id) {
            mNowNumber += num ;
        }
    }
}

public enum MissionTargetType {
    UnDefined,
    Kill,
    Collection
}