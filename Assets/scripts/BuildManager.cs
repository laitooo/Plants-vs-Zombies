using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private PlantBlueprint toBuild;
    private MoneyManager moneyManager;
    
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one build manage in the scene!");
            return;
        }
        instance = this;
    }

    void Start() {
        moneyManager = MoneyManager.instance;
    }

    public bool canBuild() {
        return toBuild != null;
    }

    public bool hasMoney() {
        return moneyManager.Money >= toBuild.cost;
    }

    public void selectPlantToBuild(PlantBlueprint plantBlueprint) {
        toBuild = plantBlueprint;
    }

    public void buildPlantOn(Node node) {
        if (moneyManager.Money < toBuild.cost) {
            selectPlantToBuild(null);  
            Debug.Log("Not enough money");
            return;
        }

        moneyManager.useMoney(toBuild.cost);
        GameObject plant = (GameObject) Instantiate(toBuild.prefab, node.transform.position, node.transform.rotation);
        node.plant = plant;
        selectPlantToBuild(null);
    }
}
