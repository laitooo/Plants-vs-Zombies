using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public SceneChanger sceneChanger;
    public string sceneToLoad = "GamePlay";

    public void play() {
        sceneChanger.transitionTo(sceneToLoad);
        Debug.Log("test1");
    }
}
