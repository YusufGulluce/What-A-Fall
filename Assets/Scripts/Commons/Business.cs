using UnityEngine;
using UnityEngine.UIElements;

public class Business : MonoBehaviour{
    private GameObject cam;
    public Sprite background;
    private soundController soundManager;
    private bool once = true;

    [SerializeField]
    protected VisualElement ve;
    [SerializeField]
    protected Transform trackingTarget;
    void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<soundController>();
        Application.targetFrameRate = 60;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        if(trackingTarget.position.y + 20 < cam.transform.position.y && once){
            soundManager.Play("fall");
            cam.GetComponent<lookAtTarget>().enabled = false;
            cam.GetComponent<restartTarget>().enabled = true;
            once = false;
        }
    }
}
