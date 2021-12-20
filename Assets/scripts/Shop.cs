using UnityEngine;

public class Shop : MonoBehaviour {
    public PlantBlueprint plant1;
    public PlantBlueprint plant2;
    public PlantBlueprint plant3;
    private BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
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
