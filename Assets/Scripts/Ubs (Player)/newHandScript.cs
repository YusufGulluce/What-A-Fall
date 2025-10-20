using UnityEngine;

public class HandScript1 : MonoBehaviour
{
    //Init variables
    //
    private Rigidbody2D RB;
    private GameObject grabbedObject;

    // Motor variables
    private HingeJoint2D joint;
    public float motorPower = 800f;
    public float maxMotorPower = 100f;

    // In script variables
    private bool isCollided;
    private int preTouchCount = 0;

    private void SetVariables()
    {
        RB = GetComponent<Rigidbody2D>();
        grabbedObject = null;

        joint = GetComponent<HingeJoint2D>();
    }

    // Function for when grabs
    private void handGrab()
    {

    }

    private void handFree()
    {

    }

    private void SetMotorSpeed()
    {

        if (RB.angularVelocity < 0)
        {
            motorPower *= -1;
        }
        else
        {
            motorPower *= 1;
        }

        if (gameObject.name == "Left Hand")
        {
            motorPower *= 1;
        }
        else if (gameObject.name == "Right Hand")
        {
            motorPower *= -1;
        }


    }

    private void Update()
    {
        if (isCollided)
        {
            if (Input.touchCount > 0)
            {
                if (preTouchCount < 1)
                {
                    handGrab();
                }
                preTouchCount = Input.touchCount;
            }
            else if (preTouchCount > 0)
            {
                handFree();
                preTouchCount = Input.touchCount;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollided = true;
        grabbedObject = collision.gameObject;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollided = false;
        grabbedObject = null;
    }
}
