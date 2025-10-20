using UnityEngine;

public class youAreAway : MonoBehaviour
{
    //Initialize variables
    private GameObject cam;
    private treeGenerator tree;
    private FloorObjects floorObjects;

    void Start()
    {
        //Set variables
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        tree = GameObject.FindGameObjectWithTag("tree").GetComponent<treeGenerator>();
    }

    void Update()
    {
        //If object is out of range do the methods
        if( cam.transform.position.y - 36 > transform.position.y ){
            Next(floorObjects.getNextObjects());
        }
    }

    //Set next and current objects state after a new floor
    public void Next(FloorObjects nextObjects)
    {
        tree.ReplaceObjects(GetFloorObjects());
        nextObjects.getWood().GetComponent<youAreAway>().enabled = true;
        this.enabled = false;
    }

    public void SetFloorObjects(FloorObjects floorObjects)
    {
        this.floorObjects = floorObjects;
    }
    public FloorObjects GetFloorObjects()
    {
        return floorObjects;
    }
}
