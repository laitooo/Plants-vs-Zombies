using UnityEngine;

public class Node : MonoBehaviour {
    public Color hover;
    private Color startColor;
    private Renderer rend;
    private GameObject plant;
    private BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
        rend =  GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter() {
        if (buildManager.getPlantToBuild() == null) {
            return;
        }
        rend.material.color = hover;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {
        if (buildManager.getPlantToBuild() == null) {
            Debug.Log("plant is null");
            return;
        }

        if (plant != null) {
            // TODO : display on screen
            Debug.Log("can't build here");
            return;
        }

        GameObject toBuild = buildManager.getPlantToBuild();
        plant = (GameObject) Instantiate(toBuild, transform.position, transform.rotation);
        BuildManager.instance.setPlantToBuild(null);
    }
}
