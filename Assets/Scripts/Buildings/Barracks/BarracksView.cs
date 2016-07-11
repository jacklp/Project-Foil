using UnityEngine;
using System.Collections;

public class BarracksView : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseView()
    {
        Debug.Log("Clicked close");
        Destroy(this);
    }

    public void BuildPerson()
    {

    }
}
