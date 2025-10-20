using UnityEngine;

public class logController : MonoBehaviour
{
    private SpriteController sc;

    void Start()
    {
        sc = gameObject.GetComponent<SpriteController>();
        SetSprite();
    }

    public void SetSprite()
    {
        sc.randomGallery();
    }
}
