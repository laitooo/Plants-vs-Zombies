using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one build manage in the scene!");
            return;
        }
        instance = this;
    }

    public GameObject plant1;
    private GameObject toBuild;

    public GameObject getPlantToBuild() {
        return toBuild;
    }

    public void setPlantToBuild(GameObject gameObject) {
        toBuild = gameObject;
    }
}
