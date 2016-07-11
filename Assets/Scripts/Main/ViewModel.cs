using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewModel : MonoBehaviour {

    //PREFABS
    public GameObject BuildPlaceHolderPrefab;
    public GameObject BarracksPrefab;
    public GameObject WallPrefab;
    public GameObject ToBuild;

    //PLACEHOLDER & BUILDING TYPE VARIABLES
    private GameObject BuildingType;
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
        BuildingType = null;
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
                //IF USER CLICKS BUILD WHICH EVER TYPE OF BUILDING HE WANTS MADE
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(BuildPlaceHolder);
                    GameObject go = new GameObject(BuildingType.name);
                    ToBuild = Instantiate(BuildingType, new Vector3(hit.point.x, 0.1F, hit.point.z), Quaternion.identity) as GameObject;
                    ToBuild.transform.SetParent(go.transform, true);
                }
            }            
        }
    }

    public void onClick()
    {

        BuildPlaceHolder = Instantiate(BuildPlaceHolderPrefab, new Vector3(pos.x, 0.1F, pos.z), Quaternion.identity) as GameObject;
        //Single instance of placeholder to exist
        //Appears upon build wall click, disappears upon construction    
    }

    public void onBarracksIconClick()
    {
        BuildingType = BarracksPrefab;
        onClick();
    }

    public void onWallIconClick()
    {
        BuildingType = WallPrefab;
        onClick();
    }    
}
