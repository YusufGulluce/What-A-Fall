using System.Collections.Generic;
using UnityEngine;

public class treeGenerator : MonoBehaviour
{
    //init variables
    public GameObject wood;
    public GameObject rock;
    public GameObject root;

    private float woodLong;
    private float rockLong;
    private float rootLong;

    public float floorCount = 0;
    public float nextFloorToRock = 1;
    public int loadedFloorCount = 6;
    private List<FloorObjects> loadedObjects;

    private SpriteRenderer rockSR;
    private SpriteRenderer woodSR;
    private SpriteRenderer rootSR;

    void Start()
    {
        //set variables
        loadedObjects = new List<FloorObjects>();

        woodSR = wood.GetComponent<SpriteRenderer>();
        rockSR = rock.GetComponent<SpriteRenderer>();
        rootSR = root.GetComponent<SpriteRenderer>();

        woodLong = woodSR.sprite.rect.height / 100 * woodSR.transform.localScale.y;
        rockLong = rockSR.sprite.rect.width / 100 * rockSR.transform.localScale.y;
        rootLong = rootSR.sprite.rect.height / 100 * rootSR.transform.localScale.y;

        //Initialize first loaded floors
        for (int i = -1; i < loadedFloorCount + 1; i++)
        {
            if(i < loadedFloorCount)
            {
                GetNewFloor();

             //Set next objects
                if (i > 0)
                {
                    loadedObjects[i - 1].setNextObjects(loadedObjects[i]);
                    loadedObjects[i - 1].getWood().GetComponent<youAreAway>().SetFloorObjects(loadedObjects[i - 1]);
                }
            }
            else if(i == loadedFloorCount)
            {
                loadedObjects[i - 1].setNextObjects(loadedObjects[0]);
                loadedObjects[i - 1].getWood().GetComponent<youAreAway>().SetFloorObjects(loadedObjects[i - 1]);
            }
        }
    }

    //Initialize and set everything at a floor
    void GetNewFloor()
    {
        //Init variables
        GameObject replacment = wood;
        Vector3 placment = WoodPlacment();

        //The root(very first) floor
        if (floorCount == 1)
        {
            replacment = root;
            placment = new Vector3(0, woodLong / 2 - rootLong / 2, 19);
            Instantiate(replacment, placment, transform.rotation);
        }

        //Set log & rock and add it to Floor Objects List
        else
        {
            GameObject log = Instantiate(replacment, placment, transform.rotation);
            log.GetComponent<youAreAway>().enabled = floorCount == 2;

            FloorObjects floorObjects = new FloorObjects();
            floorObjects.setWood(log);
            floorObjects.setRock(GetNewRock());
            loadedObjects.Add(floorObjects);
        }
    }

    //Set first rocks
    GameObject GetNewRock()
    {
        GameObject bush = Instantiate(rock, RandomRockPlacement(), transform.rotation);
        return bush;
    }

    //Replace methods
    //
    public void ReplaceWood(GameObject log)
    {
        log.transform.position = WoodPlacment();
        log.GetComponent<logController>().SetSprite();
    }

    public void ReplaceRock(GameObject rock)
    {
        rock.transform.position = RandomRockPlacement();
        rock.GetComponent<BushController>().BuildBush();
    }

    public void ReplaceObjects(FloorObjects floorObjects)
    {
        ReplaceWood(floorObjects.getWood());
        ReplaceRock(floorObjects.getRock());
    }

    //Random place finder methods
    //
    private Vector3 RandomRockPlacement()
    {
        float rockX = Random.value * (woodLong - (rockLong / 6)) + (rockLong / 12) - (woodLong / 2);
        float rockY = Random.value * ((woodLong / 2) - (rockLong / 3)) - rockLong / 4;

        Vector3 placement = new Vector3(rockX, woodLong * (floorCount - 1) + rockY, 21);
        Debug.Log("rockY: " + rockY + "\nFloor: " + floorCount + "\n");
        return placement;
    }

    private Vector3 WoodPlacment()
    {
        floorCount++;
        Vector3 placment = new Vector3(0, (floorCount - 1) * woodLong, 22);
        return placment;
    }
}


//
// Opened a class to declare & manage everything in a floor
//
public class FloorObjects
{
    private GameObject wood;
    private GameObject rock;
    private FloorObjects nextObjects;

    // Wood & Rock
    public void setWood(GameObject wood)
    {
        this.wood = wood;
    }
    public GameObject getWood()
    {
        return wood;
    }

    public void setRock(GameObject rock)
    {
        this.rock = rock;
    }
    public GameObject getRock()
    {
        return rock;
    }

    // Next Floor Objects
    public void setNextObjects(FloorObjects nextObjects)
    {
        this.nextObjects = nextObjects;
    }
    public FloorObjects getNextObjects()
    {
        return nextObjects;
    }
}