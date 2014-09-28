using System;

public class HideAttr : BaseStat {
	private float mCurValue ;
	private float mAttrRadio ;			//The Radio to incress
	private float mAttrLastRadio ;		//Eat food or using equipments to incress

	public float attrRadio {
		get{ return mAttrRadio ; }
		set{ mAttrRadio = value ; }
	}

	public float attrLastRadio {
		get{ return mAttrLastRadio ; }
		set{ mAttrLastRadio = value ; } 
	}

	public float curValue {
		get{ return mCurValue ; }
	}

	public HideAttr( float value ) {
		level = 1 ;
		ratio = 1.4f ;
		baseValue = value ;
		attrRadio = 0f ;
		attrLastRadio = 0f ;

		mCurValue = baseValue ; 
	}

	private float CalculateLastRadio() {
		return 1 - level * attrRadio - attrLastRadio ; 
	}

	private float NowValue() {
		if ( mCurValue != baseValue * CalculateLastRadio() ) {
			mCurValue = baseValue * CalculateLastRadio() ;
		}
		return mCurValue ;
	}

	public void AddAttrLastRadio( float percent ) {
		mAttrLastRadio += percent ;
	}

	public void DecreaseAttrLastRadio( float percent ) {
		if ( mAttrLastRadio < percent ) mAttrLastRadio = 0.0f ;
		else mAttrLastRadio -= percent ;
	}
} 

public enum HideAttrName {
	ColletionSpeed,
	AnalysisSpeed,
	Intelligence
}