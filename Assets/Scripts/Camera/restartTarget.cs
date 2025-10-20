using UnityEngine;
using UnityEngine.SceneManagement;

public class restartTarget : MonoBehaviour
{
    
    public float xOffset = 1;
    public float followSpeed = 1;

    private soundController sc;

    private void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<soundController>();

        if (sc.getOnOff())
        {
            this.followSpeed = 0.5F;
        }
        else
        {
            this.followSpeed = 3f;
        }
    }

    
    
    void Update()
    {
        float xTarget = xOffset - 40;
        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        transform.position = new Vector3( xNew, transform.position.y, transform.position.z );

        if(transform.position.x <= xOffset - 26 ){
            DataPersistanceManager.instance.SaveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
