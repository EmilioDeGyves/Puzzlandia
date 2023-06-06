using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Flower : MonoBehaviour
{
    public int petalCount;
    public Sprite[] flowerSprites;
    private Image flowerImage;
    public FlowerController controller;

    void Start()
    {
        flowerImage = GetComponent<Image>();
        ResetFlower();
    }

    public void PluckPetal()
    {
        if (petalCount > 1)
        {
            petalCount--;
        }
        else
        {
            petalCount = flowerSprites.Length - 1;
        }
        flowerImage.sprite = flowerSprites[petalCount];
    }




    public int GetPetalCount()
    {
        return (int)petalCount;
    }

    public void ResetFlower()
    {
        petalCount = flowerSprites.Length - 1;
        flowerImage.sprite = flowerSprites[petalCount];
    }
}