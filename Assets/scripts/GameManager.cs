using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool isGameEnded = false;
    void Start() {
        
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
        isGameEnded = true;
        Debug.Log("Game over!");
    }
}
