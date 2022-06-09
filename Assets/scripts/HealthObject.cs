using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthObject : MonoBehaviour
{

    public float health = 5f;
    private float currentHealth;
    public UnityEvent objectDiedCallback;

    void Start() {
        currentHealth = health;
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Zombie") {
            // Debug.Log("Zombie approached an object");
        } else if (other.gameObject.tag == "ZombieArm") {
            currentHealth -= 1f;
            checkDeath();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Zombie") {
            Debug.Log("Zombie disappeared");
        }
    }

    private void checkDeath() {
        if (currentHealth == 0) {
            Destroy(gameObject);
            if (objectDiedCallback != null) {
                objectDiedCallback.Invoke();
            }
        }
    }
}
