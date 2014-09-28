using System ;
using System.Collections.Generic;

public class ItemBase {
	private string mName ;
	private int mID ;
	private int mNum ;
	private string mIcon ;
	private ItemType mType ;
	private string mDetail ;
	private List<int> mEffect ;
	private bool mCanDuplication ;

	public const int ITEM_MAX = 99 ;

	public string Name{ 
		get{ return mName;} 
		set{ mName = value ;}
	} 

	public int ID {
		get { return mID; }
		set { mID = value; }
	}

	public string Icon { 
		get {return mIcon ; }
		set { mIcon = value ; }
	} 

	public int Num {
		get { return mNum; }
		set { mNum = value;}
	}

	public ItemType Type {
		get{ return mType ; }
		set{ mType = value ; }
	}

	public string Detail {
		get { return mDetail ; }
		set { mDetail = value ; }
	}
	public List<int> Effect {
		get{ return mEffect ; }
		set{ mEffect = value ; }
	}

	public bool CanDuplication {
		get { return mCanDuplication ; }
		set { mCanDuplication = value ; }
	}

	public ItemBase() {
		mName = string.Empty ;
		mIcon = string.Empty ;
		mID = 0 ;
		mNum = 0 ;
		mCanDuplication = true ;
		mType = ItemType.Undefined;
		mDetail = string.Empty ;
		mEffect = null ;
	}

	public void ModNum( int num ) {
		mNum += num ;
	}
}

public enum ItemType {
	Undefined = 0,
	OriMeterial = 1,
	Food = 2,
	Weapon = 3,
	Equiment = 4,
	Mission = 5
}

public static class SearchForType {

	public static ItemType SearchItemType( string type ) {
		if ( Enum.IsDefined( typeof(ItemType), type ) ) {
            return (ItemType)Enum.Parse(typeof(ItemType), type ) ;
        }
        return ItemType.Undefined ;
	}

	public static MissionType SearchMissionType( string type ) {
		if ( Enum.IsDefined( typeof(MissionType), type ) ) {
            return (MissionType)Enum.Parse(typeof(MissionType), type ) ;
        }
        return MissionType.Undefined ;
	}
}