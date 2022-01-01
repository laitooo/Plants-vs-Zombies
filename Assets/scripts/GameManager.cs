using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public string menuScene = "MainMenu";
    public GameObject gameOverUi;
    public GameObject pauseMenuUi;
    public Text roundsText;
    public SceneChanger sceneChanger;
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
        Time.timeScale = 0f;
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
        sceneChanger.transitionTo(SceneManager.GetActiveScene().name);
    }

    public void menu() {
        Time.timeScale = 1f;
        sceneChanger.transitionTo(menuScene);
    }
}
