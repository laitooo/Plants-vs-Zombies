using UnityEngine;

public class Node : MonoBehaviour {
    public Color hover;
    private Color startColor;
    private Renderer rend;
    private GameObject plant;

    void Start() {
        rend =  GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter() {
        rend.material.color = hover;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {
        if (plant != null) {
            // TODO : display on screen
            Debug.Log("can't build here");
            return;
        }

        GameObject toBuild = BuildManager.instance.getPlantToBuild();
        plant = (GameObject) Instantiate(toBuild, transform.position, transform.rotation);
    }
}
