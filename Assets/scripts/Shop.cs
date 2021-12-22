using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public PlantBlueprint plant1;
    public PlantBlueprint plant2;
    public PlantBlueprint plant3;
    private BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
        plant1.costText.text = plant1.cost.ToString() + "$";
        plant2.costText.text = plant2.cost.ToString() + "$";
        plant3.costText.text = plant3.cost.ToString() + "$";
    }

    public void purchasePlant1() {
        Debug.Log("purchased plant1");
        buildManager.selectPlantToBuild(plant1);
    }

    public void purchasePlant2() {
        Debug.Log("purchased plant2");
        buildManager.selectPlantToBuild(plant2);
    }

    public void purchasePlant3() {
        Debug.Log("purchased plant3");
        buildManager.selectPlantToBuild(plant3);
    }
}
