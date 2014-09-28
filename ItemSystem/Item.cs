using UnityEngine ;
using System.Collections.Generic;

public class Item : ItemBase {
    public Item() {
        Name = string.Empty;
        Icon = string.Empty;
        ID = -1;
        Num = 0;
        CanDuplication = false;
        Effect = null;
        Detail = string.Empty;
        Type = ItemType.Undefined;
    }

	public Item Give( int n ) {
		if ( Num == ITEM_MAX )
			Debug.Log( "Item[" + Name + "] is full." ) ;
		else if ( Num + n > ITEM_MAX ) {
			Debug.Log( "Item[" + Name + "] is out of max(99)" ) ;
			Num = 99 ;
		} else ModNum(n) ;

		return this ;
	}

	public Item Discard( int n ) {
		if ( Type == ItemType.Mission ) {
			Debug.Log( "Item[" + Name + "] is a mission item." ) ;
		} else {
			if ( Num < n ) Num = 0 ;
			else ModNum(-n) ;
		}
		return this ;
	}

	public Item Use( GameObject obj ) {
		Effect action = new Effect( obj ) ;

		for( int i = 0 ; i < Effect.Count ; i += 2 ) {
			switch( Effect[i] ) {
				case 0 :
					action.ModifiedHP( Effect[i+1] ) ;
					break;
				case 1 :
					action.ModifiedHP( -1 * Effect[i+1] ) ;
					break;
				case 2 :
					action.ModifiedStamina( Effect[i+1] ) ;
					break;
				case 3 :
					action.ModifiedStamina( -1 * Effect[i+1] ) ;
					break;
				case 4 :
					action.ModifiedMental( Effect[i+1] ) ;
					break;
				case 5 :
					action.ModifiedMental( -1 * Effect[i+1] ) ;
					break;
				case 6 :
					action.GiveExp( Effect[i+1] ) ;
					break;
				case 7 :
					action.AnalysisSpeedUp( Effect[i+1] ) ;
					break;
				case 8 :
					action.AnalysisSpeedUp( Effect[i+1] ) ;
					break;
				default :
					break;
			}
		}
		return this ;
	}

    public Item DeepCopy() {
        Item othercopy = (Item)this.MemberwiseClone();
        return othercopy;
    }
}
