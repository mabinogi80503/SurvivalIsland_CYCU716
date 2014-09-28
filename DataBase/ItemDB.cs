using UnityEngine ;
using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON ;

public class ItemDB {
	public List<Item> itemDB ;

	public ItemDB() {
        itemDB = new List<Item>();
        CreateDB();
        Debug.Log("CreateDB finished!");
	}

	private string ReadJSON() {
        return ((TextAsset)Resources.Load("Data/ItemData")).text ;
	}

    private void CreateDB() {
        var dict = Json.Deserialize(ReadJSON()) as Dictionary<string,object> ;
        List<object> itemList = dict["Item"] as List<object> ;
        foreach ( var i in itemList) {
            Dictionary<string, object> itemDetails = i as Dictionary<string, object>;
            Item item = new Item();
            item.ID = Int32.Parse((string)itemDetails["id"]) ;
            item.Name = (string)itemDetails["name"] ;
            item.Icon = (string)itemDetails["icon"] ;
            item.Detail = (string)itemDetails["detail"] ;
            item.CanDuplication = TranslateDupl((string)itemDetails["dupl"]) ;
            item.Type = SearchForType.SearchItemType((string)itemDetails["type"]) ;
            item.Effect = TranslateEffect((string)itemDetails["effect"]) ;

            itemDB.Add(item) ;
        }
    }

    private bool TranslateDupl( string dupl ) {
        return dupl.Equals("true") ;
    }

    private List<int> TranslateEffect( string eff ) {
        List<int> list = new List<int>() ;
        string[] splits = eff.Split(new Char[] {',','\t','\r','\n'}) ;
        for( int i = 0 ; i < splits.Length ; ++i ) {
            list.Add(Int32.Parse(splits[i])) ;
        }
        return list ;
    }

    public Item GenerateItem( int id, int num ) {
        Item item = itemDB.Find( x => x.ID == id ) ;
        if (item != null) {
            item.ID = id;
            item.Num = num;
        }
        return item;
    }
}
