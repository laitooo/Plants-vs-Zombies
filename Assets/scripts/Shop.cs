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
}
