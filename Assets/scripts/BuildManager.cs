using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private PlantBlueprint toBuild;
    
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one build manage in the scene!");
            return;
        }
        instance = this;
    }

    public bool canBuild() {
        return toBuild != null;
    }

    public void selectPlantToBuild(PlantBlueprint plantBlueprint) {
        toBuild = plantBlueprint;
    }

    public void buildPlantOn(Node node) {
        if (PlayerStats.Money < toBuild.cost) {
            selectPlantToBuild(null);  
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= toBuild.cost;
        GameObject plant = (GameObject) Instantiate(toBuild.prefab, node.transform.position, node.transform.rotation);
        node.plant = plant;
        selectPlantToBuild(null);
        Debug.Log("Built plant! money left = " + PlayerStats.Money);
    }
}
