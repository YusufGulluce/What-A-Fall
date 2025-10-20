using UnityEngine;

public class handScript : MonoBehaviour
{
    private HingeJoint2D joint;
    private SpriteRenderer sr;
    public Sprite[] spriteArray;
    public GameObject floor;
    private lookAtTarget camScript;
    private BoxCollider2D floorCol;
    private Rigidbody2D rb;
    private soundController soundManager;
    private GameObject currentBush;

    public GameObject head;
    private Rigidbody2D headRB;

    private JointMotor2D motorRef;
    private bool okToHold = false;
    private static int bothHandsCheck = 0;
    public float motorPower = 1000f;
    public float maxMotorPower = 200f;

    void Start()
    {
        
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<lookAtTarget>();
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<soundController>();
        headRB = head.GetComponent<Rigidbody2D>();

        //joint settings
        joint = gameObject.GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        joint.enabled = false;

        //motor settings
        setMotorSettings(1);

        joint.useMotor = true;

        //sprite settings
        sr = GetComponent<SpriteRenderer>();
        
        floorCol = floor.GetComponent<BoxCollider2D>();
    }


    void Update(){

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            sr.sprite = spriteArray[1];
            if (okToHold && !joint.enabled && bothHandsCheck < 1)
            {
                soundManager.Play("grab");
                bothHandsCheck++;
                joint.enabled = true;
                floorCol.isTrigger = true;

                if(currentBush.tag == "rock")
                    currentBush.GetComponent<BushController>().isGrabbed();


                
                if (rb.angularVelocity < 0)
                {
                    setMotorSettings(-1);
                }
                else
                {
                    setMotorSettings(1);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            sr.sprite = spriteArray[0];
            if (joint.enabled) {
                soundManager.Play("jump");
                if (currentBush != null && currentBush.tag == "rock")
                    currentBush.GetComponent<BushController>().isNotGrabbed();
                currentBush = null;
                bothHandsCheck--;
                joint.enabled = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "rock" || hitInfo.tag == "Root")
        {
            okToHold = true;
            currentBush = hitInfo.gameObject;
            if(camScript.enabled == true)
            {
                camScript.updateMinY(transform.position.y);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "rock" || hitInfo.tag == "Root")
        {
            okToHold = false;
        }
    }

    void setMotorSettings(int motorDirection){

        motorPower *= motorDirection;

        if(gameObject.name == "Left Hand"){
            motorPower *= 1;
        }
        else if(gameObject.name == "Right Hand"){
            motorPower *= -1;
        }
        

        motorRef = new JointMotor2D{ motorSpeed = motorPower, maxMotorTorque = maxMotorPower };
        joint.motor = motorRef;
    }
}

