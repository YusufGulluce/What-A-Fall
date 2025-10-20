using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour
{
    public int[] indexesOfMidSprites = new int[] {2};
    public int[] indexesOfChangables = new int[] {4,5};

    public List<Collider2D> colls;
    public GameObject log;
    private SpriteRenderer logSR;
    private SpriteRenderer sr;
    private SpriteController sc;

    public float bushAreaPercent = 0.15F;
    private float logWidth;
    private float posX;

    void Start()
    {
        logSR = log.GetComponent<SpriteRenderer>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sc = gameObject.GetComponent<SpriteController>();
        logWidth = (log.transform.localScale.x / 100) * logSR.sprite.rect.width;

        BuildBush();
    }

    public void BuildBush()
    {
        
        posX = transform.position.x;

        for (int i = 0; i < colls.Count; i++)
        {
            colls[i].enabled = false;
        }

        SetDirection(posX, sr);
        SuitSprites(logWidth, bushAreaPercent, posX);
        SuitCollider();

    }

    void SetDirection(float targetX, SpriteRenderer targetSR)
    {
        
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y , transform.localScale.z);
        if (targetX > 0)
        {
                transform.localScale -= new Vector3(2 * transform.localScale.x, 0, 0);
        }
    }

    void SuitSprites(float areaWidth, float percent, float targetX)
    {
        float distanceToOrigin = ( areaWidth * percent ) / 2;
        if ( targetX > -distanceToOrigin
            && targetX < distanceToOrigin )
        {
            sc.selectGalleryFrom( indexesOfMidSprites );
        }
        else
        {
            sc.randomGallery();
        }
        
    }

    void SuitCollider()
    {
        colls[sc.getSelectedIndex()].enabled = true;
    }

    public void isGrabbed()
    {
        sc.isGrabbed(indexesOfChangables);
    }

    public void isNotGrabbed()
    {
        sc.isNotGrabbed();
    }
}
