using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public PlantBlueprint plant1;
    public PlantBlueprint plant2;
    public PlantBlueprint plant3;
    public PlantBlueprint plant4;
    private BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
        plant1.costText.text = plant1.cost.ToString() + "$";
        plant2.costText.text = plant2.cost.ToString() + "$";
        if (plant3.costText != null) {
            plant3.costText.text = plant3.cost.ToString() + "$";
        }

        if (plant4.costText != null) {
            plant4.costText.text = plant4.cost.ToString() + "$";
        }
    }

    public void purchasePlant1() {
        Debug.Log("purchased plant 1");
        buildManager.selectPlantToBuild(plant1);
    }

    public void purchasePlant2() {
        Debug.Log("purchased plant 2");
        buildManager.selectPlantToBuild(plant2);
    }

    public void purchasePlant3() {
        Debug.Log("purchased plant 3");
        buildManager.selectPlantToBuild(plant3);
    }

    public void purchasePlant4() {
        Debug.Log("purchased plant 4");
        buildManager.selectPlantToBuild(plant4);
    }
}
