using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public TextMeshProUGUI gameOverText;
    public Button replayButton;

    void Start()
    {
        gameObject.SetActive(false); 
        replayButton.onClick.AddListener(RestartGame); 
    }

    public void ShowGameOver(string message)
    {
        gameObject.SetActive(true);
        gameOverText.text = message;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
