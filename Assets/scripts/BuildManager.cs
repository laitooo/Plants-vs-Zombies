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

    public GameObject defaultPlant;

    void Start() {
        toBuild = defaultPlant;
    }
    private GameObject toBuild;
    public GameObject getPlantToBuild() {
        return toBuild;
    }
}
