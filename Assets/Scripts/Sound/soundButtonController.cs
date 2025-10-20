using UnityEngine;
using UnityEngine.UI;

public class soundButtonController : MonoBehaviour
{
    private bool OnOff;

    //
    // Set components and objects
    //
    public Sprite on;
    public Sprite off;
    public Image image;
    private Sprite selectedSprite;
    private soundController sc;
    private RectTransform rectTransform;

    //
    // Layout components
    //
    [Header("Layout")]
    [SerializeField] private float aspectWidth = 0.15F;               // To set a better layout these are percenteces of screen
    private float aspectHeight; //this will be caculated later by originated from aspectWidth
    private float aspectCorner;

    [SerializeField] private float distanceToCorner = 0.03F;   

    private float minEdgeLong;

    private void Start()
    {
        SetComponentsAndObjects();
        AutoLayout();
    }

    private void SetComponentsAndObjects()
    {
        rectTransform = GetComponent<RectTransform>();
        sc = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<soundController>();
    }

    public void OnButtonPress()
    {
        //
        // Change the sprite of the sound on/off button & set new on/off
        //
        if (OnOff)
        {
            selectedSprite = off;
            OnOff = false;
        }
        else
        {
            selectedSprite = on;
            OnOff = true;
        }

        if(sc != null)
            sc.changeOnOff(OnOff);

        Build(selectedSprite);
    }


    public void setFirstOnOff(bool OnOff)
    {
        this.OnOff = !OnOff;
        OnButtonPress();
    }

    private void Build(Sprite sprite)
    {
        this.image.sprite = sprite;
    }

    private void AutoLayout()
    {

        float tempW = Screen.width;
        float tempH = Screen.height;
        float tempAspect = tempW / tempH;

        aspectCorner = distanceToCorner * tempAspect;
        aspectHeight = aspectWidth * tempAspect;
        rectTransform.anchorMin = new Vector2(1 - aspectWidth, 0.96F - aspectHeight);
        rectTransform.anchorMax = new Vector2(1 - distanceToCorner, 0.96F - aspectCorner);

    }
}
