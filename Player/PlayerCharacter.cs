using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class PlayerCharacter : MonoBehaviour {
    private Dictionary<String, VitalAttr> mVitalAttrDic ;
    private Dictionary<String, HideAttr> mHideAttrDic;
    private Dictionary<String, SpecAttr> mSpecAttrDic;

	private int mExp ;

	public int EXP {
		get { return mExp ;} 
		set { mExp = value ;}
	}

	public void AddExp( int exp ) {
		mExp += exp ;
	}

	// Use this for initialization
	void Start () {
        mVitalAttrDic = new Dictionary<string, VitalAttr>();
        mHideAttrDic = new Dictionary<string, HideAttr>();
        mSpecAttrDic = new Dictionary<string, SpecAttr>();
        
		SetVitalAttr() ;
		SetHideAttr() ;
		SetSpecAttr() ;
		Debug.Log("Initial end! PlayerCharacter!!");
	}
	
	// Update is called once per frame
	void Update () {
	}

    public VitalAttr GetVitalAttr (String tag) {
        if(true == mVitalAttrDic.ContainsKey( tag )) return mVitalAttrDic[tag];
        else return null;
    }

    public HideAttr GetHideAttr (String tag) {
        if(true == mHideAttrDic.ContainsKey( tag )) return mHideAttrDic[tag];
        else return null;
    }

    public SpecAttr GetSpecAttr (String tag) {
        if(true == mSpecAttrDic.ContainsKey( tag )) return mSpecAttrDic[tag];
        else return null;
    }

	private void SetVitalAttr() {
        VitalAttr hp = new VitalAttr( 1200f );
        hp.ratio = 1.2f;
        VitalAttr stamina = new VitalAttr( 600f );
        stamina.ratio = 1.1f;
		VitalAttr mental  = new VitalAttr(100f) ;
        mental.ratio = 1.1f;
        mVitalAttrDic.Add( Enum.GetNames( typeof( VitalAttrName ) )[0], hp );
        mVitalAttrDic.Add( Enum.GetNames( typeof( VitalAttrName ) )[1], stamina );
        mVitalAttrDic.Add( Enum.GetNames( typeof( VitalAttrName ) )[2], mental );
	}

	private void SetHideAttr() {
        mHideAttrDic.Add( Enum.GetNames( typeof( HideAttrName ) )[0], new HideAttr( 5f ) );
        mHideAttrDic.Add( Enum.GetNames( typeof( HideAttrName ) )[1], new HideAttr( 4f ) );
        mHideAttrDic.Add( Enum.GetNames( typeof( HideAttrName ) )[2], new HideAttr( 1f ) );
	}

	private void SetSpecAttr() {
        SpecAttr g1 = new SpecAttr( 50f );
        SpecAttr g2 = new SpecAttr( 50f );
		g1.another = g2 ;
		g2.another = g1 ;

        mSpecAttrDic.Add( Enum.GetNames( typeof( SpecAttrName ) )[0], g1 );
        mSpecAttrDic.Add( Enum.GetNames( typeof( SpecAttrName ) )[0], g2 );
	}
}
