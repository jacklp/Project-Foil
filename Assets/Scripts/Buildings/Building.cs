using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public int HP;
    public int Armour;
    public GameObject GameController;
    
    public Vector3 RallyPosition;
    public bool isRally;

    public bool isView;
    public GameObject View; 

    public void GeneratePerson(GameObject person)
    {

        if (isRally)
        {
            // get rally point;
        } else
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;

            if (mesh == null)
            {
                Debug.Log("No Mesh");
            }

            // get current width and height of mesh.
            Bounds bounds = mesh.bounds;
            float width = bounds.size.x;
            float depth = bounds.size.z;

            // get current transform.
            float x = transform.position.x;
            float z = transform.position.z;

            //set new person position;
            float personX = x - width / 2;
            float personZ = z - depth / 2;

            //instantiate person and add to game controller
            GameController.GetComponent<GameController>().People.Add(Instantiate(person, new Vector3(personX, 0.5F, personZ), Quaternion.identity) as GameObject);

        }
    }

    public void DeleteRallyPosition()
    {

    }

    public void SetRallyPosition()
    {

    }

    void OnMouseDown()
    {
        //Display Corresponding View IF Exists
        if (isView)
        {
            GameObject view = Instantiate(View, Vector3.zero, Quaternion.identity) as GameObject;
            view.transform.SetParent(transform.parent, false);
            //view.transform.parent = transform;
        }
    }
}
