using UnityEngine;

public class LevelSelector : MonoBehaviour {
    public SceneChanger sceneChanger;

    void Start() {
        if (AudioManager.instance.isPlaying("GamePlayBackground")) {
            AudioManager.instance.stop("GamePlayBackground");
            AudioManager.instance.play("MenuBackground");
        }
    }

    public void selectLevel(string levelName) {
        sceneChanger.transitionTo(levelName);
    }
}
