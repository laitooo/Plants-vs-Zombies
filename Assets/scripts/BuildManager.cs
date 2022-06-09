using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private PlantBlueprint toBuild;
    private MoneyManager moneyManager;
    [HideInInspector]
    public bool isRemoveToolSelected;
    [HideInInspector]
    public bool isUpgrading;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            Debug.LogError("More than one build manage in the scene!");
        } else {
            instance = this;
        }
    }
    
    void Start() {
        isRemoveToolSelected = false;
        isUpgrading = false;
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
        isRemoveToolSelected = false;
        isUpgrading = plantBlueprint == null ? false : plantBlueprint.isUpgradePlant;
        AudioManager.instance.play("Select");
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
        node.isPlantUpgradeable = toBuild.isUpgradeable;
        selectPlantToBuild(null);
        AudioManager.instance.play("Plant");
    }

    public void upgradePlantOn(Node node) {
        // TODO : remove duplicate code
        if (moneyManager.Money < toBuild.cost) {
            selectPlantToBuild(null);  
            Debug.Log("Not enough money");
            return;
        }

        if (!node.isPlantUpgradeable) {
            selectPlantToBuild(null);  
            Debug.Log("Not upgradeable plant");
            return;
        }
        
        moneyManager.useMoney(toBuild.cost);
        GameObject plant = (GameObject) Instantiate(toBuild.prefab, node.transform.position, node.transform.rotation);
        Destroy(node.plant);
        node.plant = plant;
        node.isPlantUpgradeable = toBuild.isUpgradeable;
        selectPlantToBuild(null);
        AudioManager.instance.play("Plant");
    }

    public void removeToolClicked() {
        isRemoveToolSelected = !isRemoveToolSelected;
        if (isRemoveToolSelected) {
            toBuild = null;
            isUpgrading = false;
        }
        AudioManager.instance.play("Select");
    }
}
