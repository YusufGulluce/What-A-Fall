using UnityEngine;

public class autoLayOutBackground : MonoBehaviour
{
    private GameObject cam;
    private SpriteRenderer sr;
    private float scale;
    private float varb1;
    private float WorH;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        sr = GetComponent<SpriteRenderer>();

        if (Camera.main.aspect < 0.5)
        {
            varb1 = 1;
            WorH = sr.sprite.rect.height;
            Debug.Log("aspect is bigger than 2");
        }
        else
        {
            varb1 = Camera.main.aspect;
            WorH = sr.sprite.rect.width;
            Debug.Log("aspect is lesser than 2");
        }
        scale = ( cam.GetComponent<Camera>().orthographicSize * 200 * varb1) / WorH;
        transform.localScale = new Vector3(scale ,scale ,1);
        
    }
}
