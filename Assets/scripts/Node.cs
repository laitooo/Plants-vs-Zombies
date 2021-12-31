using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Color errorColor;
    private Color startColor;
    private Renderer rend;
    [Header("HideInInspector")]
    public GameObject plant;
    [Header("HideInInspector")]
    public bool isPlantUpgradeable;
    private BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
        rend =  GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter() {
        if (buildManager.isRemoveToolSelected) {
            if (plant == null) {
                rend.material.color = errorColor;
            } else {
                rend.material.color = hoverColor;
            }
            return;
        }

        if (!buildManager.canBuild()) {
            return;
        }

        if (buildManager.hasMoney()) {
            if (buildManager.isUpgrading) {
                if (plant == null || !isPlantUpgradeable) {
                    // TODO : check type of plant to upgrade
                    rend.material.color = errorColor;
                } else {
                    rend.material.color = hoverColor;
                }
            } else {
                if (plant != null) {
                    rend.material.color = errorColor;
                } else {
                    rend.material.color = hoverColor;
                }
            }
        } else {
            rend.material.color = errorColor;
        }
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {
        if (buildManager.isRemoveToolSelected) {
            if (plant != null) {
                Destroy(plant);
                isPlantUpgradeable = false;
            } 
            buildManager.removeToolClicked();
            rend.material.color = startColor;
        }

        if (!buildManager.canBuild()) {
            Debug.Log("plant is null");
            return;
        }

        if (buildManager.isUpgrading) {
            if (plant == null) {
                // TODO : display on screen
                Debug.Log("No plants to upgrade");
            } else {
                // TODO : make sure this is the correct plant
                buildManager.upgradePlantOn(this);
                rend.material.color = startColor;
            }
        } else {
            if (plant != null) {
                // TODO : display on screen
                Debug.Log("can't build here");
            } else {
                buildManager.buildPlantOn(this);
                rend.material.color = startColor;
            }
        }

    }
}
