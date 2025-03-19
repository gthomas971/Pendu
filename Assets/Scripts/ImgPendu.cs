using UnityEngine;
using UnityEngine.UI;


public class ImgPenduScript : MonoBehaviour
{
    [SerializeField] Sprite[] penduImages;
     [SerializeField] Sprite newImage;

    void Start()
    {
       newImage = penduImages[0];
       gameObject.GetComponent<Image>().sprite = newImage;
    }

    public void NextSprite(int indexImage)
    {
        newImage = penduImages[indexImage];
        gameObject.GetComponent<Image>().sprite = newImage;
    }
}
