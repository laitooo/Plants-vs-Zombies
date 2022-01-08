using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public SceneChanger sceneChanger;
    public string sceneToLoad = "GamePlay";

    void Start() {
        if (AudioManager.instance.isPlaying("GamePlayBackground")) {
            AudioManager.instance.stop("GamePlayBackground");
        }
        AudioManager.instance.play("MenuBackground");
    }

    public void play() {
        sceneChanger.transitionTo(sceneToLoad);
        Debug.Log("test1");
    }
}
