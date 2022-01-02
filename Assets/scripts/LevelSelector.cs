using UnityEngine;

public class LevelSelector : MonoBehaviour {
    public SceneChanger sceneChanger;

    public void selectLevel(string levelName) {
        sceneChanger.transitionTo(levelName);
    }
}
