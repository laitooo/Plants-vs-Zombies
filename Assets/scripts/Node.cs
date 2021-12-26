using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Color noMoneyColor;
    private Color startColor;
    private Renderer rend;
    [Header("Optional")]
    public GameObject plant;
    private BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
        rend =  GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter() {
        if (!buildManager.canBuild()) {
            return;
        }

        if (buildManager.hasMoney()) {
            rend.material.color = hoverColor;
        } else {
            rend.material.color = noMoneyColor;
        }
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {
        if (!buildManager.canBuild()) {
            Debug.Log("plant is null");
            return;
        }

        if (plant != null) {
            // TODO : display on screen
            Debug.Log("can't build here");
            return;
        }

        buildManager.buildPlantOn(this);
        rend.material.color = startColor;
    }
}
