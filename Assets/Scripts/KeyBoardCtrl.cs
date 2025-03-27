using System.Collections.Generic;
using UnityEngine;

public class KeyBoardCtrl : MonoBehaviour
{
     private string[] letters = new string[]{
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
        
   [SerializeField] private GameObject blockLetter;

    [SerializeField] private List<BlockLetter> btnList; 

    void Start()
    {
        btnList = new List<BlockLetter>();
        SetBtns();
    }

   private void SetBtns(){
        foreach (string letter in letters)
        {
            BlockLetter elt = SetBtn(letter);
            elt.transform.SetParent(this.transform);
            btnList.Add(elt);
        }
    }

    private BlockLetter SetBtn(string letter){
        GameObject btnInst = Instantiate(blockLetter);
        BlockLetter btnCtrl = btnInst.GetComponent<BlockLetter>();
        btnCtrl.Init(letter);
        return btnCtrl;
    }
}
