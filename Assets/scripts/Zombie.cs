using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float defaultSpeed = 5f;
    public int defaultHealth = 20;
    [HideInInspector]
    public int health;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float slownessTimer = 0f;
    private bool isDead;

    void Start() {
        isDead = false;
        health = defaultHealth;
        speed = defaultSpeed;
    }

    public void takeDamage(int amount) {
        health -= amount;
        if (health < 1 && !isDead) {
            die();
        }
    }

    void die() {
        isDead = true;
        WaveSpawner.zombiesAlive--;
        Destroy(gameObject);
    }

    public void slowAndDamge(int amount, float slownessTime) {
        takeDamage(amount);
        if (health > 0) {
            speed = defaultSpeed / 2;
            slownessTimer = slownessTime;
        }
    }
}
