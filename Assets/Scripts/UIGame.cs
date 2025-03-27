using UnityEngine;

public class UIGame : MonoBehaviour
{
     private AudioSource audioSource;
    public void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public void MuteSound(){
       audioSource.mute = !audioSource.mute;
    }
}
