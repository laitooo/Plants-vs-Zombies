using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject gameOverUi;
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
    }

    void endGame() {
        gameOverUi.SetActive(true);
        isGameEnded = true;
        Debug.Log("Game over!");
    }
}
