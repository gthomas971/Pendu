using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Game game;

   
    public static GameManager instance;
    private int validInputcount = 0;
    private int wrongInput = 0;

    private WordDisplay wordDisplay;
    private ImgPenduScript imgPenduScript;
    

     public GameOverUI gameOverUI;

    public string word; 

    private WordList words;
    public bool gameIsOver = false;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadWords();
        int index = Random.Range(0, words.words.Length);
        word = words.words[index];
        game = new Game(word); 
        GameObject screen = GameObject.Find("WordPendu");
        wordDisplay = screen.GetComponent<WordDisplay>();
        GameObject image = GameObject.Find("ImagePendu");
        imgPenduScript = image.GetComponent<ImgPenduScript>();
        SetUpdateScreen();
    }

    public void OnPlay(string inputValue)
    {
         Debug.Log("3333333333333333"+ inputValue);
        if( game.playerInput.Contains(inputValue)){
              Debug.Log("Vous avez déjà joué cette lettre");
        }else{
            game.playerInput.Add(inputValue);
            int count = game.word.ToUpper().Count(c => c == char.ToUpper(inputValue[0]));
            if( count > 0 ){
                Debug.Log("Bien joué");
                validInputcount += count;
            }else{
                wrongInput++;
                if(wrongInput >= 8){
                     Debug.Log("GAME OVER");
                       gameIsOver = true;
                    gameOverUI.ShowGameOver("Game Over !");
                }else{
                    imgPenduScript.NextSprite(wrongInput);
                    Debug.Log("Perdu");
                }
            }
            if(validInputcount == game.word.Length){
                Debug.Log("Bravo c'est gagné!");
                gameIsOver = true;
                gameOverUI.ShowGameOver("Bravo c'est gagné!");
            }
           
        }
        SetUpdateScreen();
    }

    public void SetUpdateScreen(){
        string screenDisplay = "";
         foreach (char c in word)
        {
            if(!game.playerInput.Contains(c.ToString().ToUpper())){
                screenDisplay += "_ ";
            }else{
                screenDisplay += c + " ";
            }
           
        }
        wordDisplay.SetWord(screenDisplay);
    }

   
     void LoadWords()
    {
        
        TextAsset jsonFile = Resources.Load<TextAsset>("words");
        
        if (jsonFile != null)
        {
            words = JsonUtility.FromJson<WordList>(jsonFile.text);
        }
        else
        {
            Debug.LogError("Impossible de charger le fichier words.json !");
        }
    }

    
}
