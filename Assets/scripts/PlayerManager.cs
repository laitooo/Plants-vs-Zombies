using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;    
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one player manager in the scene!");
            return;
        }
        instance = this;
    }

    public Text livesCounter;
    public int startLives = 20;
    public int Lives;
    void Start() {
      Lives = 20;
      updateText();  
    }

    public void looseLife() {
        Lives--;
        updateText();
    }

    void updateText() {
        livesCounter.text = "Lives = " + Lives.ToString();
    }
}
