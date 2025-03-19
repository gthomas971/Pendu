using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Game game;
    private int validInputcount = 0;
    private int wrongInput = 0;

    private WordDisplay wordDisplay;
    private ImgPenduScript imgPenduScript;
    [SerializeField] private BlockLetter blockLetter;

     public GameOverUI gameOverUI;

    public string word; 

    private WordList words;
   
    void Start()
    {
        LoadWords();
        SetLetters();
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
                    gameOverUI.ShowGameOver("Game Over !");
                }else{
                    imgPenduScript.NextSprite(wrongInput);
                    Debug.Log("Perdu");
                }
            }
            if(validInputcount == game.word.Length){
                Debug.Log("Bravo c'est gagné!");
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

    private void SetLetters(){
        string[] letters = new string[]{
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
        Camera cam = Camera.main;
        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector2(1, 1));
        float minX = bottomLeft.x;
        float minY = bottomLeft.y; 
        float maxX = topRight.x;
        float intervalX = Mathf.Abs(maxX - minX);
        int maxSpaceCount = Mathf.FloorToInt(intervalX / 1.1f);
        int rowCount =  Mathf.CeilToInt(26f / maxSpaceCount);
        int spaceCount = Mathf.CeilToInt(26 / rowCount);

      
       int numberRow = 1;
       float marginX =(( intervalX - ( ( spaceCount * 1.1f ) - 0.1f ) ) / 2f ) +0.5f;
        for (int i = 0; i < letters.Length; i++)
        {
            if( i != 0 && i % spaceCount == 0){
                numberRow++;
            }
            float x, y;
            x = minX + ( i - ( numberRow - 1 )  * spaceCount ) * 1.1f + marginX;
            y = minY + ( rowCount - numberRow ) * 1.1f + 0.6f;
            var block = Instantiate(blockLetter, new Vector2(x,y), Quaternion.identity);
            block.Init(letters[i]);    
        }
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
