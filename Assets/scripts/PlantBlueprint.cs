using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlantBlueprint {
    public GameObject prefab;
    public int cost;
    public Text costText;
    public bool isUpgradePlant = false;
    public bool isUpgradeable = false;
}
