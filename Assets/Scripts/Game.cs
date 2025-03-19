using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game 
{
   public string word;
   public List<string> playerInput;

   public Game(string word)
   {
        this.word = word ;
        playerInput = new List<string>();
   }
}
