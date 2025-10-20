using UnityEngine;

public class comeToTarget : MonoBehaviour
{

    public float xOffset = 0;
    public float followSpeed = 2;

    private lookAtTarget otherCamera;
    private GameObject floor;
    private float xTarget;
    private float bottomY;

    void Start(){
        xTarget = xOffset;
        otherCamera = GetComponent<lookAtTarget>();
        otherCamera.enabled = false;

        float camHalfHeight = GetComponent<Camera>().orthographicSize;

        floor = GameObject.FindGameObjectWithTag("Floor");
        SpriteRenderer floorSr = floor.GetComponent<SpriteRenderer>();
        float floorHalfHeight = (floorSr.sprite.rect.height / 200) * floor.transform.localScale.y;

        bottomY = floor.transform.position.y - floorHalfHeight + camHalfHeight;

        transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
    }
    void Update()
    {
        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        transform.position = new Vector3( xNew, transform.position.y, transform.position.z );

        if(transform.position.x <= xTarget + 0.2){
            otherCamera.setMinY( bottomY );
            otherCamera.enabled = true;
            this.enabled = false;
        }
    }
}
