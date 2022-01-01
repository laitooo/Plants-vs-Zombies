using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverUi;
    public GameObject pauseMenuUi;
    public Text roundsText;
    [HideInInspector]
    public static bool isGameEnded;

    void Start() {
        isGameEnded = false;
    }

    void Update() {
        if (isGameEnded) {
            return;
        }
        
        if (PlayerManager.instance.Lives < 1) {
            endGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            toggle();
        }
   }

    void endGame() {
        gameOverUi.SetActive(true);
        roundsText.text = PlayerManager.instance.rounds.ToString();
        isGameEnded = true;
        Debug.Log("Game over!");
    }

    public void toggle() {
        pauseMenuUi.SetActive(!pauseMenuUi.activeSelf);

        if (pauseMenuUi.activeSelf) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }

    public void retry() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu() {
        Debug.Log("Go to menu"); 
    }
}
