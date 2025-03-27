using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlockLetter : MonoBehaviour
{
 
    [SerializeField] private TextMeshProUGUI text;

 
    public void Init(string display) {
        text.text = display;
    }

    public void OnClick(){
        GetComponent<AudioSource>().Play() ;
        GetComponent<Animator>().enabled = true ;
        GameManager.instance.OnPlay(text.text);
    }

}
