using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public List<Gallery> galleries = new List<Gallery>();
    private SpriteRenderer sr;
    private int selectedIndex = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void randomGallery()
    {
        int randomIndex = Random.Range(0, galleries.Capacity);
        sr.sprite = galleries[randomIndex].list[0];
        selectedIndex = randomIndex;
    }

    public void selectGallery(int index)
    {
        sr.sprite = galleries[index].list[0];
        selectedIndex = index;
    }

    public void deleteSelectedGalleries(int[] indexList)
    {
        for(int i = 0; i < indexList.Length; i++)
        {
            galleries.RemoveAt(indexList[i]);
        }
    }

    public void selectGalleryFrom(int[] indexList)
    {
        int randomIndex = Random.Range(0, indexList.Length);
        randomIndex = indexList[randomIndex];
        sr.sprite = galleries[randomIndex].list[0];
        selectedIndex = randomIndex;
    }

    public void isGrabbed(int[] canChange)
    {
        foreach (int i in canChange)
        {
            if (i == selectedIndex)
            {
                return;
            }
        }

        Debug.Log("return did not work");
        sr.sprite = galleries[selectedIndex].list[1];
    }

    public void isNotGrabbed()
    {
        sr.sprite = galleries[selectedIndex].list[0];
    }

    public int getSelectedIndex()
    {
        return selectedIndex;
    }
}
