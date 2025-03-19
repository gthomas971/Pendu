using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    
    public void SetWord(string word)
    {
        Debug.Log("word is" + word);
        gameObject.GetComponent<TextMeshProUGUI>().text= word;
    }

}
