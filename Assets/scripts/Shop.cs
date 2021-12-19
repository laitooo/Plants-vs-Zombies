using UnityEngine;

public class Shop : MonoBehaviour {
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void purchasePlant1() {
        Debug.Log("purchased plant1");
        buildManager.setPlantToBuild(buildManager.plant1);
    }

    public void purchasePlant2() {
        Debug.Log("purchased plant2");
        buildManager.setPlantToBuild(buildManager.plant2);
    }

    public void purchasePlant3() {
        Debug.Log("purchased plant3");
        buildManager.setPlantToBuild(buildManager.plant3);
    }
}
