using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class InvController : MonoBehaviour {
	private ItemDB itemDB ;
	private List<Item> bagList ;

	void Awake() {
		itemDB = new ItemDB() ;
	}
	void Start() {
		bagList = new List<Item>() ;
	}
	
	void Update() {
	}
	
	public Item Find( int ID ) {
		return bagList.Find (x => x.ID == ID);
	}

    public int Count () {
        return bagList.Count;
    }
	
	public void AddItem( int ID, int num ) {
		Item temp = Find(ID);
		if (temp != null) temp.Give(num) ;
		else {
			temp = itemDB.GenerateItem( ID, num ) ;
			bagList.Add(temp);
		}
	}

	public void Discard( int ID, int num) {
		Item temp = Find (ID);
		if ( temp == null ) return ;
		temp.Discard (num);
		if (temp.Num == 0)
			bagList.Remove (temp);
	}

	public void Delete(int ID ) {
		Item temp = Find (ID);
		bagList.Remove (temp);
	}
}
