using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string sceneToLoad = "GamePlay";

    public void play() {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Update() {
        
    }
}
