using System ;

public class SpecAttr : BaseStat {

	private SpecAttr mAnother ;

	public SpecAttr another {
		set { mAnother = value ; }
		get{ return mAnother ; } 
	} 

	private const float MAX = 100f ;

	public SpecAttr( float value ) {
		baseValue = value ;
	} 

	public void IncreaseValue( int increase ) {
		if ( baseValue + increase >= 100 ) 
			IncreaseBaseValue( MAX - baseValue ) ;
		else
			IncreaseBaseValue( increase ) ;

		mAnother.ReduceValue( increase ) ;
	}

	public void ReduceValue( int reduce ) {
		if ( baseValue - reduce < 0 ) 
			ReduceBaseValue( baseValue ) ;
		else
			ReduceBaseValue( reduce ) ;
	}
}

public enum SpecAttrName {
	AngelLike,
	DevilLike
}
