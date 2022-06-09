using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;    
    [HideInInspector]
    public int rounds;
    void Start() {
        if (instance != null) {
            Destroy(gameObject);
            Debug.LogError("More than one player manager in the scene!");
        } else {
            instance = this;
        }
        rounds = 0;
    }
}
