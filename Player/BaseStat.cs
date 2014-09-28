public class BaseStat {
	private float mBaseValue ;			// Basic Attribute value 

	private int mLevel ;				// Statement level
	private int mNextExp ;				// Next level your exp needed
	private float mRatio ;				// exp grow mulit number

	public BaseStat() {
		mBaseValue = 0f ;
		mLevel = 1 ;
		mNextExp = 100 ;
		mRatio = 1f ; 

	}

	public float baseValue {
		get{ return mBaseValue ; }
		set{ mBaseValue = value ; }
	}

	public int level {
		get { return mLevel ; }
		set { mLevel = value ; }
	}

	public int nextExp {
		get { return mNextExp ; }
	}

	public float ratio {
		get { return mRatio ; }
		set { mRatio = value ; }
	}
	
	public void LevelUp() {
		mLevel += 1 ;
		mNextExp = CalculateNextExp() ;
	}

	private int CalculateNextExp() {
		return (int)(mNextExp * mRatio) ;
	}

	public bool CanLevelUp( int exp ) {
		return mNextExp <= exp ;
	} 

	public void IncreaseBaseValue( float increase ) {
		mBaseValue += increase ;
	}

	public void ReduceBaseValue( float reduce ) {
		mBaseValue -= reduce ;
	}
}
