using UnityEngine;
using System.Collections;

public class BuildingView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BuildPerson(GameObject person)
    {
        // get parent then child gameobject

        //prefer this way so I can have whatever name for my building I want:
        // either get child by index if I can supply the index previously to a class var

        //or get child by name if i can be sure of a naming convention.
        GameObject Building = transform.parent.GetChild(0).gameObject;
        Building buildingScript = Building.GetComponent<Building>();
        buildingScript.GeneratePerson(person);
    }
}
