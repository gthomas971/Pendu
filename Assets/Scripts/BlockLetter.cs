using UnityEngine;
using TMPro;

public class BlockLetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private TextMeshPro text;
    public void Init(string display, string color =  "#e0c158") {
        text.text = display;
        ColorUtility.TryParseHtmlString("#e0c158", out Color defaultColor);
        sprite.color = defaultColor;
    }

    public void Disable() {
        ColorUtility.TryParseHtmlString("#d4cebc", out Color defaultColor);
        sprite.color = defaultColor;
        text.text = "";
    }

    void OnMouseDown()
    {
        Debug.Log("Prefab cliqué !"+ text.text);
        GameManager gm = FindFirstObjectByType<GameManager>();
        gm.OnPlay(text.text);
        Disable();
    }
 

}
