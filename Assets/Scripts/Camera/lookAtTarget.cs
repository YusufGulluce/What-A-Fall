using UnityEngine;

public class lookAtTarget : MonoBehaviour
{

    [SerializeField]
    protected Transform trackingTarget;

    public float yOffset = -1;
    public float xOffset = 0;
    public float followSpeed = 1;
    private float yTarget;
    private float yNew;
    private float minY = 0;
    private float minminY;

    public void setMinY(float minY)
    {
        this.minminY = minY + 2;
        this.minY = this.minminY;
    }

    void Update()
    {
        yTarget = trackingTarget.position.y + yOffset;
        
        if( yTarget + 2 > minY )
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(transform.position.x, yNew, transform.position.z);
        }  
    }

    public void updateMinY(float newMinY)
    {
        if(minY < newMinY && minminY < newMinY)
        {
            minY = newMinY;
        }
        
    }
}
