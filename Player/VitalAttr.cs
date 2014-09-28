using System ;

public class VitalAttr : BaseStat {
	private float mCurValue ;
	private float mInnateRadio ;
	private float mAcquiredRadio ;

	public float innateRadio {
		get{ return mInnateRadio ; }
		set{ mInnateRadio = value ; } 
	}

	public float acquiredRadio {
		get{ return mAcquiredRadio ; }
		set{ mAcquiredRadio = value ; } 
	}

	public float curValue {
		get{ return mCurValue ; }
		set{ mCurValue = value ;}
	}

	public VitalAttr( float value ) {
		level = 1 ;
		ratio = 1.3f ;
		baseValue = value ;
		innateRadio = 1f ;
		acquiredRadio = 0f ;

		mCurValue = baseValue ;
	}

	public void IncreaseCurValue( float value ) {
		mCurValue += value ;
	}

	public void DecreaseCurValue( float value ) {
		if ( mCurValue - value < 0 ) {
			mCurValue = 0 ;
		} else mCurValue -= value ;
	}

	public void NatureRestore() {
		float value = baseValue * ( innateRadio + acquiredRadio ) ;
		IncreaseCurValue( ( curValue + value <= baseValue ) ? value : baseValue - curValue ) ;
	}
}

public enum VitalAttrName {
	Health,
	Stamina,
	Mental
}
