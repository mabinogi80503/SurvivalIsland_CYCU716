using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvNode : MonoBehaviour {
    private Item mItem;

    private Sprite uiSprite;
    private Text uiNum;

    public InvNode (Item item) {
        mItem = item;
        Init();
    }

    private void Init () {
        Image picture = this.GetComponent<Image>();
        picture.sprite = null;

        Text num = this.GetComponentInChildren<Text>();
        num.text = mItem.Num + "";
    }
}
