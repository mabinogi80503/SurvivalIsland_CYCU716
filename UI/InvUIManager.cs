using UnityEngine;
using System.Collections;

public class InvUIManager : MonoBehaviour {
    private Canvas cancas;

    void Start () {
        cancas = this.GetComponent<Canvas>();
        cancas.enabled = false;
    }

    void Update () {
    }

    public void Show () {
        cancas.enabled = !cancas.enabled;
    }

    public void Dismiss () {
        cancas.enabled = false;
    }


}
