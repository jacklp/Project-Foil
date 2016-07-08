using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewModel : MonoBehaviour {

    public GameObject BuildPlaceHolderPrefab;
    private GameObject BuildPlaceHolder;

    // LIST OF OBJECTS
    private List<GameObject> wallList = new List<GameObject>();

    //MOUSE POSITION
    private Vector3 pos;
    private Vector2 mousePos;

    RaycastHit hit;
    Ray ray;

    void Start()
    {

    }

    void Update()
    {
        //CHECK THAT WE HAVE INSTANTIATED OUR PLACEHOLDER BUILDING
        if (BuildPlaceHolder != null)
        {
            //RAYCAST SO THAT WE CAN GET OUR 2D MOUSE POSITION IN 3D SPACE
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //MOVE BUILDING PLACEHOLDER TO FOLLOW MOUSE POSITION
                BuildPlaceHolder.transform.position = new Vector3(hit.point.x, 1F, hit.point.z);
            }

            //IF USER CLICKS BUILD WHICH EVER TYPE OF BUILDING HE WANTS MADE
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
    }

    public void onBuildWallClick()
    {
        BuildPlaceHolder = Instantiate(BuildPlaceHolderPrefab, new Vector3(pos.x, 0.1F, pos.z), Quaternion.identity) as GameObject;
    }

    
}
